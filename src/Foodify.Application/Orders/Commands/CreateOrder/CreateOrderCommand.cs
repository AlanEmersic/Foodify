using ErrorOr;
using Foodify.Application.Authorization;
using MediatR;

namespace Foodify.Application.Orders.Commands.CreateOrder;

[Authorize(Roles = Roles.Customer)]
public sealed record CreateOrderCommand(IReadOnlyList<CreateOrderItemCommand> OrderItems) : IRequest<ErrorOr<Created>>;