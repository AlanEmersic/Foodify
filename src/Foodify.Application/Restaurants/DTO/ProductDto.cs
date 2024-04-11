namespace Foodify.Application.Restaurants.DTO;

public sealed record ProductDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public decimal Price { get; init; }
    public string ImageUrl { get; init; } = null!;
}