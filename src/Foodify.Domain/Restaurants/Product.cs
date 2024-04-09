using Foodify.Domain.Common;

namespace Foodify.Domain.Restaurants;

public sealed class Product : Entity
{
    public Guid RestaurantId { get; set; }
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public decimal Price { get; init; }
    public string ImageUrl { get; init; } = null!;

    public Restaurant? Restaurant { get; set; }
}