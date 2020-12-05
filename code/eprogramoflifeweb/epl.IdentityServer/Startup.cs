using epl.core.Interfaces;
using epl.IdentityServer.Models;
using epl.IdentityServer.Storages;
using epl.IdentityServer.Validation;
using epl.infrastructure.Repositories;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace epl.IdentityServer
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddProfileService<ProfileService>()
                .AddClientStore<ClientStore>();

            ConfigureRavenDB(services);
            IoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(MyAllowSpecificOrigins);
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
        }

        private void ConfigureRavenDB(IServiceCollection services)
        {
            var store = new DocumentStore
            {
                Urls = Configuration.GetSection("Database").GetSection("Urls").Get<string[]>(),
                Database = Configuration.GetSection("Database").GetValue<string>("Name"),
            };

            store.Initialize();

            services.AddSingleton<IDocumentStore>(store);

            services.AddScoped(serviceProvider =>
            {
                return serviceProvider
                    .GetService<IDocumentStore>()
                    .OpenAsyncSession();
            });
        }

        private void IoC(IServiceCollection services)
        {
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();

            services.AddScoped<IAsyncRepository<Account>, RavenRepository<Account>>();
            services.AddScoped<IAsyncRepository<User>, RavenRepository<User>>();
        }
    }
}
