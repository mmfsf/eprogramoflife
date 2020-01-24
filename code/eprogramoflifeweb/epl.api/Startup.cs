using epl.api.Filters;
using epl.core.Domain;
using epl.core.Interfaces;
using epl.infrastructure;
using epl.infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace epl.api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvcCore(_ => {
                    _.EnableEndpointRouting = false;
                    _.Filters.Add(typeof(CustomExceptionFilterAttribute));
                })
                .AddDataAnnotations()
                .AddAuthorization()
                .AddNewtonsoftJson()
                .AddApiExplorer();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = Configuration.GetSection("URLs").GetValue<string>("IdentityServer");
                options.RequireHttpsMetadata = false;

                options.Audience = "epl.api";
            });

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

            IoC(services);
            ConfigureSwagger(services);


            //services.AddScoped<DbContext, CommitmentsContext>();
            //services.AddEntityFrameworkSqlServer()
            //  .AddDbContext<CommitmentsContext>(options =>
            //  {
            //      options.UseSqlServer(Configuration.GetSection("ConnectionString").Value);
            //  },
            //  ServiceLifetime.Scoped);

            //services.AddScoped<IRepository<Commitment>, ContextRepository<Commitment>>();
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

        private void IoC(IServiceCollection services)
        {
            services.AddSingleton<IRepository<Account>, MemoryRepository<Account>>();
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
    }
}
