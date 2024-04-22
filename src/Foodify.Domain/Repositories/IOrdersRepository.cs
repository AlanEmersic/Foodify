using Foodify.Domain.Orders;

namespace Foodify.Domain.Repositories;

public interface IOrdersRepository
{
    Task<Order?> GetByIdAsync(Guid id);
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(Order order);
}