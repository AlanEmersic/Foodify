namespace Foodify.Application.Restaurants.DTO;

public sealed record RestaurantDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public string Address { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string ImageUrl { get; init; } = null!;
    public IReadOnlyCollection<ProductDto>? Products { get; init; }
}