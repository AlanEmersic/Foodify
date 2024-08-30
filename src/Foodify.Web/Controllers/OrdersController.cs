using ErrorOr;
using Foodify.Application.Authorization;
using Foodify.Application.Orders.Commands.CreateOrder;
using Foodify.Application.Orders.DTO;
using Foodify.Infrastructure.DAL.Orders.Queries.GetOrder;
using Foodify.Infrastructure.DAL.Orders.Queries.GetOrders;
using Foodify.Infrastructure.DAL.Orders.Queries.GetUsersOrdersSummary;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodify.Web.Controllers;

[Route("api/[controller]")]
public sealed class OrdersController : ApiController
{
    private readonly ISender mediator;

    public OrdersController(ISender mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = Roles.Customer)]
    public async Task<IActionResult> GetOrders()
    {
        GetOrdersQuery query = new();
        ErrorOr<IReadOnlyList<OrderDto>> result = await mediator.Send(query);

        return result.Match(Ok, Problem);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = Roles.Customer)]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        GetOrderQuery query = new(id);
        ErrorOr<OrderDto> result = await mediator.Send(query);

        return result.Match(Ok, Problem);
    }

    [HttpPost]
    [Authorize(Roles = Roles.Customer)]
    public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
    {
        ErrorOr<Created> result = await mediator.Send(command);

        return result.Match(_ => CreatedAtAction(nameof(CreateOrder), default), Problem);
    }

    [HttpGet("summary")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> GetUsersOrdersSummary()
    {
        GetUsersOrdersSummaryQuery query = new();
        ErrorOr<IReadOnlyList<UserOrdersSummaryDto>> result = await mediator.Send(query);

        return result.Match(Ok, Problem);
    }
}