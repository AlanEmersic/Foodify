using ErrorOr;
using Foodify.Application.Authorization;
using MediatR;

namespace Foodify.Application.Restaurants.Commands.CreateRestaurant;

[Authorize(Roles = Roles.Admin)]
public sealed record CreateRestaurantCommand(string Name, string Description, string Address, string Email, string ImageUrl) : IRequest<ErrorOr<Created>>;