using ErrorOr;
using Foodify.Application.Authentication.DTO;
using MediatR;

namespace Foodify.Infrastructure.Authentication.Queries;

public sealed record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationDto>>;