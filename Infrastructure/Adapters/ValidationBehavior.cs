using Aplication.Common.Exceptions;
using FluentValidation;
using MediatR;
using ValidationException = Aplication.Common.Exceptions.ValidationException;

namespace Infrastructure.Adapters;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    // Constructor que recibe una colección de validadores para el tipo de solicitud especificado.
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    // Método para manejar la solicitud y aplicar la validación antes de pasarla al siguiente manejador en el pipeline.
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // Verifica si existen validadores para la solicitud.
        if (_validators.Any())
        {
            // Crea un contexto de validación con la solicitud.
            var context = new FluentValidation.ValidationContext<TRequest>(request);

            // Ejecuta la validación de forma asíncrona para cada validador en paralelo.
            var validationResults =
                await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            // Obtiene una lista de errores de todas las validaciones.
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            // Si se encontraron errores de validación, lanza una excepción de validación.
            if (failures.Count != 0)
            {
                var errors = failures.Select(x => x.ErrorMessage).ToList();
                throw new ValidationException(errors);
            }
        }

        // Si no hay errores de validación, pasa la solicitud al siguiente manejador en el pipeline.
        return await next();
    }
}