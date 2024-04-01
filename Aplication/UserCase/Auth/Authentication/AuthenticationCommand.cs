using Application.UseCases.Auth.Dto;
using MediatR;

namespace Application.UseCases.Auth.Commands.Authentication;

public record AuthenticationCommand(
    string UserName,
    string Password
) : IRequest<AuthenticationDto>;