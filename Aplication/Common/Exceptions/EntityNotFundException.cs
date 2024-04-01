using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Common.Exceptions
{
    public class EntityNotFundException : CustomException
    {
        public EntityNotFundException() : base()
        {
        }

        public EntityNotFundException(string message)
            : base(message, null)
        {
        }

        public async override Task HandleError(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
    }
}
