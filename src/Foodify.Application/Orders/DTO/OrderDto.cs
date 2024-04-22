using Foodify.Domain.Orders;

namespace Foodify.Application.Orders.DTO;

public sealed record OrderDto
{
    public Guid Id { get; init; }
    public decimal TotalPrice { get; init; }
    public DateTime PlacedTime { get; init; }
    public DateTime? CompletedTime { get; init; }
    public OrderStatus Status { get; init; }
    public IReadOnlyCollection<OrderItemDto>? OrderItems { get; init; } = null!;
}