// ECommerce.Application/Features/Auth/Commands/Login/LoginCommand.cs

using MediatR;

namespace ECommerce.Application.Features.Auth.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<LoginResponse>;

public record LoginResponse(string Token, string Email, string Name, string Role);