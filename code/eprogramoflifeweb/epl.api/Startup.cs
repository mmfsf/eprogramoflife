using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using epl.infrastructure;
using Microsoft.EntityFrameworkCore;

namespace epl.api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services
          .AddMvcCore()
          .AddAuthorization()
          .AddJsonFormatters()
          .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services
          .AddAuthentication("Bearer")
          .AddIdentityServerAuthentication(options =>
          {
            options.Authority = "https://localhost:5001";
            options.RequireHttpsMetadata = false;
            options.ApiName = "epl.api";
          });

      services.AddCors(options =>
      {
        options.AddPolicy("Devlopment",
                  builder => builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
      });

      services.AddDbContext<CommitmentsContext>(options => options.UseInMemoryDatabase("epldatabase"));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseCors("Devlopment");
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseAuthentication();
      app.UseMvc();
    }
  }
}
