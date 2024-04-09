using Foodify.Domain.Common;
using Foodify.Domain.Users;

namespace Foodify.Domain.Orders;

public sealed class Order : AggregateRoot
{
    public Guid UserId { get; init; }
    public int Quantity { get; init; }
    public decimal TotalPrice { get; init; }
    public DateTime PlacedTime { get; init; }
    public DateTime? CompletedTime { get; init; }
    public OrderStatus Status { get; init; }

    public User? User { get; set; }
    public IReadOnlyCollection<OrderItem> OrderItems { get; set; } = null!;
}