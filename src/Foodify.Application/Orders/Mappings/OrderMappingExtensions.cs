using Foodify.Application.Orders.Commands.CreateOrder;
using Foodify.Application.Orders.DTO;
using Foodify.Application.Restaurants.Mappings;
using Foodify.Domain.Orders;

namespace Foodify.Application.Orders.Mappings;

public static class OrderMappingExtensions
{
    public static OrderDto MapToDto(this Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            TotalPrice = order.TotalPrice,
            PlacedTime = order.PlacedTime,
            CompletedTime = order.CompletedTime,
            Status = order.Status,
            OrderItems = order.OrderItems?.Select(x => x.MapToDto()).ToList()
        };
    }

    public static OrderItemDto MapToDto(this OrderItem orderItem)
    {
        return new OrderItemDto
        {
            Id = orderItem.Id,
            OrderId = orderItem.OrderId,
            ProductId = orderItem.ProductId,
            Quantity = orderItem.Quantity,
            Price = orderItem.Price,
            Product = orderItem.Product!.MapToDto()
        };
    }

    public static UserOrdersSummaryDto MapToDto(this IGrouping<Guid, Order> orderGroup)
    {
        return new UserOrdersSummaryDto
        {
            UserId = orderGroup.Key,
            Email = orderGroup.First().User?.Email ?? string.Empty,
            TotalAmountSpent = orderGroup.Sum(order => order.TotalPrice),
            MonthlySpendings = orderGroup
                .GroupBy(order => order.PlacedTime.ToString("yyyy-MM"))
                .Select(x => new MonthlySpendingDto
                {
                    Month = x.Key,
                    TotalSpent = x.Sum(order => order.TotalPrice)
                })
                .OrderBy(x => x.Month)
                .ToList()
        };
    }

    public static Order MapToDomain(this CreateOrderCommand command, Guid userId, float subscriptionDiscount, DateTime placedTime, DateTime completedTime, OrderStatus status)
    {
        return new Order
        {
            UserId = userId,
            TotalPrice = command.OrderItems.Sum(x => x.Quantity * x.Price) * (decimal)(1 - subscriptionDiscount / 100),
            PlacedTime = placedTime,
            CompletedTime = completedTime,
            Status = status,
            OrderItems = command.OrderItems.Select(x => x.MapToDomain()).ToList()
        };
    }

    public static OrderItem MapToDomain(this CreateOrderItemCommand command)
    {
        return new OrderItem
        {
            ProductId = command.ProductId,
            Quantity = command.Quantity,
            Price = command.Price
        };
    }
}