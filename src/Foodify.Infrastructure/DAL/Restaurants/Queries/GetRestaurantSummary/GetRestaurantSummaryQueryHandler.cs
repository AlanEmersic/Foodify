using ErrorOr;
using Foodify.Application.Restaurants.DTO;
using Foodify.Application.Restaurants.Mappings;
using Foodify.Domain.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Restaurants.Queries.GetRestaurantSummary;

internal sealed class GetRestaurantSummaryQueryHandler : IRequestHandler<GetRestaurantSummaryQuery, ErrorOr<RestaurantSummary>>
{
    private readonly FoodifyDbContext context;

    public GetRestaurantSummaryQueryHandler(FoodifyDbContext context)
    {
        this.context = context;
    }

    public async Task<ErrorOr<RestaurantSummary>> Handle(GetRestaurantSummaryQuery query, CancellationToken cancellationToken)
    {
        List<IGrouping<ProductGroupingKey, OrderItem>> orderItems = await context
            .OrderItems
            .Include(x => x.Order)
            .Include(x => x.Product)
            .Where(x => x.Product!.RestaurantId == query.RestaurantId)
            .GroupBy(x => new ProductGroupingKey { ProductId = x.ProductId, Name = x.Product!.Name })
            .ToListAsync(cancellationToken: cancellationToken);

        if (orderItems.Count is 0)
        {
            return Error.NotFound(description: "No sales data found.");
        }

        string restaurantName = await context
            .Restaurants
            .Where(x => x.Id == query.RestaurantId)
            .Select(x => x.Name)
            .FirstAsync(cancellationToken: cancellationToken);

        List<ProductSummaryDto> productSummaries = orderItems.Select(x => x.MapToDto()).ToList();

        RestaurantSummary restaurantSummary = new()
        {
            Id = query.RestaurantId,
            Name = restaurantName,
            Summary = productSummaries
        };

        return restaurantSummary;
    }
}