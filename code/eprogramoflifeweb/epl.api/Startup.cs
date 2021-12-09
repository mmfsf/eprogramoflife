using epl.api.Filters;
using epl.core.Domain;
using epl.core.Interfaces;
using epl.infrastructure.RavenDb.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Raven.Client.Documents;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace epl.api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvcCore(_ =>
            {
                _.EnableEndpointRouting = false;
                _.Filters.Add(typeof(CustomExceptionFilterAttribute));
            })
            .AddDataAnnotations()
            .AddAuthorization()
            .AddNewtonsoftJson()
            .AddApiExplorer();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(Configuration.GetSection("URLs").GetValue<string>("UI"))
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });

            Authentication(services);
            ConfigureRavenDB(services);
            ConfigureSwagger(services);

            IoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(_ =>
            {
                _.SwaggerEndpoint("/swagger/v1/swagger.json", "MassTime API V1");
            });

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvcWithDefaultRoute();
        }

        private void Authentication(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Authority = Configuration.GetSection("IdentityServer").GetValue<string>("URI");
                        options.RequireHttpsMetadata = false;

                        options.Audience = "epl.api";
                    });

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = Configuration.GetSection("IdentityServer").GetValue<string>("URI");
                options.RequireHttpsMetadata = false;

                options.ClientId = Configuration.GetSection("IdentityServer").GetValue<string>("client_id");
                options.ClientSecret = Configuration.GetSection("IdentityServer").GetValue<string>("client_secret");
                options.ResponseType = "code";

                options.SaveTokens = true;
            });
        }

        private void IoC(IServiceCollection services)
        {
            services.AddScoped<IAsyncRepository<Account>, AccountRavenRepository>();
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(_ =>
            {
                _.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Program of Life API",
                    Version = "v1",
                    Description = string.Empty,
                    Contact = new OpenApiContact
                    {
                        Name = "Marcos Farias",
                        Email = string.Empty,
                        Url = new Uri("http://github.com/mmfsf/"),
                    }
                });

                _.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey
                });
            });
        }

        private void ConfigureRavenDB(IServiceCollection services)
        {
            var store = new DocumentStore
            {
                Urls = Configuration.GetSection("Database").GetSection("Urls").Get<string[]>(),
                Database = Configuration.GetSection("Database").GetValue<string>("Name")
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
    }
}
