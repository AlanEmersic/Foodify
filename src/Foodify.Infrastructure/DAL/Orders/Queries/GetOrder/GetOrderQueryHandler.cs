using ErrorOr;
using Foodify.Application.Orders.DTO;
using Foodify.Application.Orders.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Orders.Queries.GetOrder;

internal sealed class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, ErrorOr<OrderDto>>
{
    private readonly FoodifyDbContext context;

    public GetOrderQueryHandler(FoodifyDbContext context)
    {
        this.context = context;
    }

    public async Task<ErrorOr<OrderDto>> Handle(GetOrderQuery query, CancellationToken cancellationToken)
    {
        OrderDto? order = await context
            .Orders
            .AsNoTracking()
            .Include(x => x.OrderItems)
            .ThenInclude(x => x.Product)
            .Where(x => x.Id == query.Id)
            .Select(x => x.MapToDto())
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);

        if (order is null)
        {
            return Error.NotFound(description: "Order not found");
        }

        return order;
    }
}