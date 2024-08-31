namespace Foodify.Application.Restaurants.DTO;

public sealed record ProductSummaryDto
{
    public string ProductName { get; init; } = null!;
    public int TotalQuantity { get; init; }
    public IReadOnlyCollection<SalesDto> Sales { get; init; } = null!;
}