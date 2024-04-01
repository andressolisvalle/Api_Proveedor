using Domain.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.Service;

//se utiliza para registrar servicios relacionados con el dominio
//en el contenedor de dependencias, permitiendo que
//estos servicios estén disponibles para su uso en toda la aplicación.
public static class ServiceExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddTransient<ProveerdorServices>();
        services.AddTransient<Domain.Services.AuthenticationService>();
        return services;
    }
}
