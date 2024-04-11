using Foodify.Domain.Restaurants;

namespace Foodify.Domain.Repositories;

public interface IRestaurantsRepository
{
    Task<Restaurant?> GetByIdAsync(Guid id);
    Task AddAsync(Restaurant restaurant);
    Task UpdateAsync(Restaurant restaurant);
    Task DeleteAsync(Restaurant restaurant);
}