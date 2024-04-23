using Foodify.Domain.Repositories;
using Foodify.Domain.Subscriptions;
using Foodify.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Users.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly FoodifyDbContext context;

    public UserRepository(FoodifyDbContext context)
    {
        this.context = context;
    }

    public async Task AddAsync(User user)
    {
        context.Users.Add(user);

        await Task.CompletedTask;
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        return await context.Users.AsNoTracking().AnyAsync(x => x.Email == email);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> GetByIdAsync(Guid userId)
    {
        return await context.Users.AsNoTracking().Include(x => x.Subscription).FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task UpdateAsync(User user)
    {
        context.Users.Update(user);

        await Task.CompletedTask;
    }

    public async Task<IReadOnlyCollection<Subscription>> GetSubscriptionsAsync()
    {
        return await context.Subscriptions.AsNoTracking().ToListAsync();
    }
}