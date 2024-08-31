namespace Foodify.Application.Restaurants.DTO;

public sealed record RestaurantSummary
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public List<ProductSummaryDto> Summary { get; init; } = null!;
}