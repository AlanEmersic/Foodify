using ErrorOr;
using Foodify.Application.Authorization;
using Foodify.Application.Orders.DTO;
using MediatR;

namespace Foodify.Infrastructure.DAL.Orders.Queries.GetOrder;

[Authorize(Roles = Roles.Customer)]
public sealed record GetOrderQuery(Guid Id) : IRequest<ErrorOr<OrderDto>>;