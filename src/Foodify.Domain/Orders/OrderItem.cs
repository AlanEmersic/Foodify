using Foodify.Domain.Common;
using Foodify.Domain.Restaurants;

namespace Foodify.Domain.Orders;

public sealed class OrderItem : Entity
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Order? Order { get; set; }
    public Product? Product { get; set; }
}