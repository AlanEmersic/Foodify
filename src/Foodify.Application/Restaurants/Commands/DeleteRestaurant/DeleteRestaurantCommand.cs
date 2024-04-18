using ErrorOr;
using Foodify.Application.Authorization;
using MediatR;

namespace Foodify.Application.Restaurants.Commands.DeleteRestaurant;

[Authorize(Roles = Roles.Admin)]
public sealed record DeleteRestaurantCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;