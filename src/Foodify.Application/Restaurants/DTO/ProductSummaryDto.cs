namespace Foodify.Application.Restaurants.DTO;

public sealed record ProductSummaryDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public int TotalQuantity { get; init; }
    public IReadOnlyCollection<SalesDto> Sales { get; init; } = null!;
}