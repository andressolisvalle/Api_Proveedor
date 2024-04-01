
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Common.Exceptions;


public class ValidationException : Exception
{
    public ValidationException() : base()
    {
        Errors = new List<string>();
    }

    public List<string> Errors { get; }

    public ValidationException(IEnumerable<string> failures) : this()
    {
        Errors = failures.ToList();
    }

    public async Task HandleError(HttpContext context, Response<string> response)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        response.Errors = Errors;
    }
}