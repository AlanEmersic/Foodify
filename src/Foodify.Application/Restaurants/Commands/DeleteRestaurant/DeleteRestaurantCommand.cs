using ErrorOr;
using MediatR;

namespace Foodify.Application.Restaurants.Commands.DeleteRestaurant;

public sealed record DeleteRestaurantCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;