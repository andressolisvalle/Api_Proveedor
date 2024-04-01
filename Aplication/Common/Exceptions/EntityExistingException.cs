using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Common.Exceptions
{
    public class EntityExistingException : CustomException
    {
        public EntityExistingException() : base()
        {
        }

        public EntityExistingException(string message)
            : base(message, null)
        {
        }

        public async override Task HandleError(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
        }
    }
}
