using Foodify.Domain.Orders;
using Foodify.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Orders.Repositories;

internal sealed class OrdersRepository : IOrdersRepository
{
    private readonly FoodifyDbContext context;

    public OrdersRepository(FoodifyDbContext context)
    {
        this.context = context;
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await context.Orders.AsNoTracking().Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Order order)
    {
        context.Orders.Add(order);

        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Order order)
    {
        context.Orders.Update(order);

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Order order)
    {
        context.Orders.Remove(order);

        await Task.CompletedTask;
    }
}