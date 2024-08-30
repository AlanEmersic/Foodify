using ErrorOr;
using Foodify.Application.Orders.DTO;
using Foodify.Application.Orders.Mappings;
using Foodify.Application.Users.DTO;
using Foodify.Application.Users.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Orders.Queries.GetOrders;

internal sealed class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, ErrorOr<IReadOnlyList<OrderDto>>>
{
    private readonly FoodifyDbContext context;
    private readonly ICurrentUserProvider currentUserProvider;

    public GetOrdersQueryHandler(FoodifyDbContext context, ICurrentUserProvider currentUserProvider)
    {
        this.context = context;
        this.currentUserProvider = currentUserProvider;
    }

    public async Task<ErrorOr<IReadOnlyList<OrderDto>>> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        CurrentUserDto currentUser = currentUserProvider.GetCurrentUser();

        List<OrderDto> orders = await context
            .Orders
            .AsNoTracking()
            .Where(user => user.UserId == currentUser.Id)
            .OrderByDescending(x => x.CompletedTime)
            .Select(x => x.MapToDto())
            .ToListAsync(cancellationToken: cancellationToken);

        return orders;
    }
}