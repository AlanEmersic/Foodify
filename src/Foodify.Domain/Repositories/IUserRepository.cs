using Foodify.Domain.Subscriptions;
using Foodify.Domain.Users;

namespace Foodify.Domain.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<bool> ExistsByEmailAsync(string email);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(Guid userId);
    Task UpdateAsync(User user);
    Task<IReadOnlyCollection<Subscription>> GetSubscriptionsAsync();
}