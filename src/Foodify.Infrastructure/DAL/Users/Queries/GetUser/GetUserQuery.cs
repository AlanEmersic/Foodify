using ErrorOr;
using Foodify.Application.Authorization;
using Foodify.Application.Users.DTO;
using MediatR;

namespace Foodify.Infrastructure.DAL.Users.Queries.GetUser;

[Authorize(Roles = Roles.Customer)]
public sealed record GetUserQuery(string Email) : IRequest<ErrorOr<UserDto>>;