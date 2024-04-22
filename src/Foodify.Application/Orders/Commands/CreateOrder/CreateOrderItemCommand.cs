using Foodify.Application.Authorization;

namespace Foodify.Application.Orders.Commands.CreateOrder;

[Authorize(Roles = Roles.Customer)]
public sealed record CreateOrderItemCommand(Guid ProductId, int Quantity, decimal Price);