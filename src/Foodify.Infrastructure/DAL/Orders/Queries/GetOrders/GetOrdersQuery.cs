using ErrorOr;
using Foodify.Application.Authorization;
using Foodify.Application.Orders.DTO;
using MediatR;

namespace Foodify.Infrastructure.DAL.Orders.Queries.GetOrders;

[Authorize(Roles = Roles.Customer)]
public sealed record GetOrdersQuery : IRequest<ErrorOr<IReadOnlyList<OrderDto>>>;