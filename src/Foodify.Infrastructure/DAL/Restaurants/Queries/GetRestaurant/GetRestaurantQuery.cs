using ErrorOr;
using Foodify.Application.Restaurants.DTO;
using MediatR;

namespace Foodify.Infrastructure.DAL.Restaurants.Queries.GetRestaurant;

public sealed record GetRestaurantQuery(Guid Id) : IRequest<ErrorOr<RestaurantDto>>;