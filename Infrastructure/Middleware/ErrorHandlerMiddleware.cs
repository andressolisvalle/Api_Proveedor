using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

using Aplication.Common.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infrastructure.Middleware;

//Este middleware intercepta las solicitudes HTTP y captura cualquier excepción
//que se produzca durante su procesamiento, proporcionando una respuesta JSON
//adecuada en caso de error.
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var modelResponse = new Response<string>() { Succeded = false, Message = error.Message };

            switch (error)
            {
                case ValidationException e:
                    await e.HandleError(context, modelResponse);
                    break;
                case CustomException e:
                    await e.HandleError(context);
                    break;
                case CoreBusinessException e:
                    await e.HandleError(context);
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(modelResponse);
            await response.WriteAsync(result);
        }
    }
}