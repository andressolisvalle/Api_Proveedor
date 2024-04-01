using System.Text;
using Domain.Ports;
using Infrastructure.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Collections.Specialized.BitVector32;
namespace Infrastructure.Extensions.Jwt;

//Este método se utiliza para configurar y agregar la autenticación JWT(JSON Web Token)
//en ASP.NET Core, utilizando las configuraciones definidas en la sección "JwtSettings"
//del archivo de configuración.
public static class JwtExtensions
{
    public static IServiceCollection AddJwtSettings(this IServiceCollection svc, IConfiguration configuration)
    {
        svc.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        svc.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = false;
            o.SaveToken = false;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:key"]))
            };
            o.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = c =>
                {
                    c.NoResult();
                    c.Response.StatusCode = 500;
                    c.Response.ContentType = "text/plain";
                    return c.Response.WriteAsync((c.Exception.ToString()));
                },
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";
                    var result = JsonConvert.SerializeObject("Usted no esta autorizado");
                    return context.Response.WriteAsync(result);
                }
            };
        });

        svc.AddScoped<IJwtServices, JwtService>();


        return svc;
    }
}