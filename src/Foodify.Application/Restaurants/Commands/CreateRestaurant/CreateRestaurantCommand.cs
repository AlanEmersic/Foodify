using ErrorOr;
using MediatR;

namespace Foodify.Application.Restaurants.Commands.CreateRestaurant;

public sealed record CreateRestaurantCommand(string Name, string Description, string Address, string Email) : IRequest<ErrorOr<Created>>;