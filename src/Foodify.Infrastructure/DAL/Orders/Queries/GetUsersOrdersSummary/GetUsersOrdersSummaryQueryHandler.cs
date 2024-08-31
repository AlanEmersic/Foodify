using ErrorOr;
using Foodify.Application.Orders.DTO;
using Foodify.Application.Orders.Mappings;
using Foodify.Domain.Orders;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Orders.Queries.GetUsersOrdersSummary;

internal sealed class GetUsersOrdersSummaryQueryHandler : IRequestHandler<GetUsersOrdersSummaryQuery, ErrorOr<IReadOnlyList<UserOrdersSummaryDto>>>
{
    private readonly FoodifyDbContext context;

    public GetUsersOrdersSummaryQueryHandler(FoodifyDbContext context)
    {
        this.context = context;
    }

    public async Task<ErrorOr<IReadOnlyList<UserOrdersSummaryDto>>> Handle(GetUsersOrdersSummaryQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<IGrouping<Guid, Order>> orders = await context
            .Orders
            .AsNoTracking()
            .Include(x => x.User)
            .GroupBy(x => x.UserId)
            .ToListAsync(cancellationToken: cancellationToken);

        if (orders.Count is 0)
        {
            return Error.NotFound(description: "No orders found");
        }

        List<UserOrdersSummaryDto> summary = orders.Select(x => x.MapToDto()).ToList();

        return summary;
    }
}