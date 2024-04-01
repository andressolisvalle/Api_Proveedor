using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;
namespace Infrastructure.Extensions.OpenApi;


public static class OpenApiExtensions
{
    public static IServiceCollection AddOpenApi(this IServiceCollection services)
    {
        services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1.0.0", new OpenApiInfo
            {
                Version = "v1.0.0",
                Title = "Supplier management API",
                Description = "API for supplier management in the mongo database",
                Contact = new OpenApiContact
                {
                    Name = "Andres Solis",
                    Email = "solisvalleandres@gmail.com"
                },
            });


            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description =
                    "JWT Authorization usa el header con el esquema Bearer. Ejemplo: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Api.xml"));
            c.ExampleFilters();
        });
        return services;
    }

    public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        // if (!env.IsDevelopment()) return app;    
        app.UseSwagger();
        app.UseSwaggerUI(
            c => c.SwaggerEndpoint("/swagger/v1.0.0/swagger.json", "Supplier API v1"));
        return app;
    }
}
