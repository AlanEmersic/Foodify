using Foodify.Domain.Repositories;
using Foodify.Domain.Restaurants;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Restaurants.Repositories;

internal sealed class RestaurantsRepository : IRestaurantsRepository
{
    private readonly FoodifyDbContext context;

    public RestaurantsRepository(FoodifyDbContext context)
    {
        this.context = context;
    }

    public async Task<Restaurant?> GetByIdAsync(Guid id)
    {
        return await context.Restaurants.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task AddAsync(Restaurant restaurant)
    {
        context.Restaurants.Add(restaurant);

        return Task.CompletedTask;
    }

    public Task UpdateAsync(Restaurant restaurant)
    {
        context.Restaurants.Update(restaurant);

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Restaurant restaurant)
    {
        context.Restaurants.Remove(restaurant);

        return Task.CompletedTask;
    }
}