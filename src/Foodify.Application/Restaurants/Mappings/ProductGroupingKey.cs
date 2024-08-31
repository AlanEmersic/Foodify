namespace Foodify.Application.Restaurants.Mappings;

public sealed record ProductGroupingKey
{
    public Guid ProductId { get; init; }
    public string Name { get; init; } = null!;
}