using ErrorOr;
using Foodify.Application.Authorization;
using Foodify.Application.Restaurants.DTO;
using MediatR;

namespace Foodify.Infrastructure.DAL.Restaurants.Queries.GetRestaurantSummary;

[Authorize(Roles = Roles.Admin)]
public sealed record GetRestaurantSummaryQuery(Guid RestaurantId) : IRequest<ErrorOr<RestaurantSummary>>;