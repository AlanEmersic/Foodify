namespace Foodify.Application.Restaurants.DTO;

public sealed record SalesDto
{
    public string Month { get; init; } = null!;
    public int Quantity { get; init; }
}