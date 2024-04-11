using ErrorOr;
using Foodify.Application.Restaurants.DTO;
using Foodify.Application.Restaurants.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Restaurants.Queries.GetRestaurants;

internal sealed class GetRestaurantsQueryHandler : IRequestHandler<GetRestaurantsQuery, ErrorOr<IReadOnlyList<RestaurantDto>>>
{
    private readonly FoodifyDbContext context;

    public GetRestaurantsQueryHandler(FoodifyDbContext context)
    {
        this.context = context;
    }

    public async Task<ErrorOr<IReadOnlyList<RestaurantDto>>> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
    {
        List<RestaurantDto> restaurants = await context
            .Restaurants
            .AsNoTracking()
            .Select(x => x.MapToDto())
            .ToListAsync(cancellationToken: cancellationToken);

        return restaurants;
    }
}