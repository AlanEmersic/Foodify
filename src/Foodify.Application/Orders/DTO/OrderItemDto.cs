namespace Foodify.Application.Orders.DTO;

public sealed record OrderItemDto
{
    public Guid Id { get; init; }
    public Guid OrderId { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}