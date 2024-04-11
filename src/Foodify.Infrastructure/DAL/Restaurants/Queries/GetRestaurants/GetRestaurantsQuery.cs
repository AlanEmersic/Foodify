using ErrorOr;
using Foodify.Application.Restaurants.DTO;
using MediatR;

namespace Foodify.Infrastructure.DAL.Restaurants.Queries.GetRestaurants;

public sealed record GetRestaurantsQuery : IRequest<ErrorOr<IReadOnlyList<RestaurantDto>>>;