using ErrorOr;
using Foodify.Application.Orders.DTO;
using Foodify.Application.Orders.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Orders.Queries.GetOrders;

internal sealed class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, ErrorOr<IReadOnlyList<OrderDto>>>
{
    private readonly FoodifyDbContext context;

    public GetOrdersQueryHandler(FoodifyDbContext context)
    {
        this.context = context;
    }

    public async Task<ErrorOr<IReadOnlyList<OrderDto>>> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        List<OrderDto> orders = await context.Orders
            .AsNoTracking()
            .Select(x => x.MapToDto())
            .ToListAsync(cancellationToken: cancellationToken);

        return orders;
    }
}