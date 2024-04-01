using Infrastructure.Extensions.Mediator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.Mapper;

//registrar AutoMapper en el contenedor de dependencias de ASP.NET Core y configurar los servicios relacionados.
public static class MapperExtensions
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.Load(ApiConstants.ApplicationProject));
        return services;
    }
}