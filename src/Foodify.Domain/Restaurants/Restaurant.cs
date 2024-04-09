using Foodify.Domain.Common;

namespace Foodify.Domain.Restaurants;

public sealed class Restaurant : AggregateRoot
{
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public string Address { get; init; } = null!;
    public string Email { get; init; } = null!;

    public IReadOnlyCollection<Product> Products { get; set; } = null!;
}