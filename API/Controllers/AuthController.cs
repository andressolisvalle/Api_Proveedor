using Api.Examples.AuthExamples;
using Application.UseCases.Auth.Commands.Authentication;
using Application.UseCases.Auth.Dto;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) => _mediator = mediator;

        [HttpPost("Auth")]
        [SwaggerRequestExample(typeof(AuthenticationCommand), typeof(AuthenticationCommandExample))]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AuthenticationResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status401Unauthorized, typeof(AuthenticationResponseNoValidCredentialExample))]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AuthenticationDto), StatusCodes.Status200OK)]
        public async Task<AuthenticationDto> Authentication(AuthenticationCommand command)
        {
            var auth = await _mediator.Send(command);
            return auth;
        }
    }
}
