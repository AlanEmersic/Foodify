using ErrorOr;
using Foodify.Application.Restaurants.DTO;
using Foodify.Application.Restaurants.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Restaurants.Queries.GetRestaurant;

internal sealed class GetRestaurantQueryHandler : IRequestHandler<GetRestaurantQuery, ErrorOr<RestaurantDto>>
{
    private readonly FoodifyDbContext context;

    public GetRestaurantQueryHandler(FoodifyDbContext context)
    {
        this.context = context;
    }

    public async Task<ErrorOr<RestaurantDto>> Handle(GetRestaurantQuery query, CancellationToken cancellationToken)
    {
        RestaurantDto? restaurant = await context
            .Restaurants
            .AsNoTracking()
            .Include(x => x.Products)
            .Where(x => x.Id == query.Id)
            .Select(x => x.MapToDto())
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);

        if (restaurant is null)
        {
            return Error.NotFound(description: "Restaurant not found");
        }

        return restaurant;
    }
}