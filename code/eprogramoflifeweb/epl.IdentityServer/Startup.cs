using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace epl.IdentityServer
{
    public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
            services.AddMvcCore();

      services.AddCors(options =>
      {
        options.AddPolicy("Devlopment",
                  builder => builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
      });

      services.AddIdentityServer()
          .AddDeveloperSigningCredential()
          .AddInMemoryIdentityResources(Config.GetIdentityResources())
          .AddInMemoryApiResources(Config.GetApiResources())
          .AddInMemoryClients(Config.GetClients())
          .AddTestUsers(Config.GetUsers());


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseCors("Devlopment");
        app.UseDeveloperExceptionPage();
      }

      app.UseIdentityServer();
    }
  }
}
