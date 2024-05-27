using Foodify.Domain.Repositories;
using Foodify.Domain.Restaurants;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL.Restaurants.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly FoodifyDbContext context;

    public ProductRepository(FoodifyDbContext context)
    {
        this.context = context;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Product product)
    {
        context.Products.Add(product);

        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Product product)
    {
        context.Products.Update(product);

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Product product)
    {
        context.Products.Remove(product);

        await Task.CompletedTask;
    }
}