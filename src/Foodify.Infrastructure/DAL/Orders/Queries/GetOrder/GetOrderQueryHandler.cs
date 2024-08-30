using ErrorOr;
using Foodify.Application.Orders.DTO;
using Foodify.Application.Orders.Mappings;
using Foodify.Application.Users.DTO;
using Foodify.Application.Users.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Orders.Queries.GetOrder;

internal sealed class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, ErrorOr<OrderDto>>
{
    private readonly FoodifyDbContext context;
    private readonly ICurrentUserProvider currentUserProvider;

    public GetOrderQueryHandler(FoodifyDbContext context, ICurrentUserProvider currentUserProvider)
    {
        this.context = context;
        this.currentUserProvider = currentUserProvider;
    }

    public async Task<ErrorOr<OrderDto>> Handle(GetOrderQuery query, CancellationToken cancellationToken)
    {
        CurrentUserDto currentUser = currentUserProvider.GetCurrentUser();

        OrderDto? order = await context
            .Orders
            .AsNoTracking()
            .Include(x => x.OrderItems)
            .ThenInclude(x => x.Product)
            .Where(x => x.Id == query.Id && x.UserId == currentUser.Id)
            .Select(x => x.MapToDto())
            .SingleOrDefaultAsync(cancellationToken: cancellationToken);

        if (order is null)
        {
            return Error.NotFound(description: "Order not found");
        }

        return order;
    }
}