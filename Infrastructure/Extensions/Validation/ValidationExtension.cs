using FluentValidation;
using Infrastructure.Adapters;
using Infrastructure.Extensions.Mediator;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.Validation;

public static class ValidationExtension
{
    // Método de extensión para IServiceCollection para configurar la validación.
    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
        // Carga la Assembly donde se encuentran los tipos relacionados con la validación.
        Assembly validationAssembly = Assembly.Load(ApiConstants.ApplicationProject);

        // Registra todos los validadores encontrados en la Assembly cargada.
        services.AddValidatorsFromAssembly(validationAssembly);

        // Registra el comportamiento de validación como un servicio transitorio.
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // Devuelve el IServiceCollection modificado.
        return services;
    }
}