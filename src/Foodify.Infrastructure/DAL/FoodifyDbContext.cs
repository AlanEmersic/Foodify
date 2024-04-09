using Foodify.Domain.Orders;
using Foodify.Domain.Restaurants;
using Foodify.Domain.Subscriptions;
using Foodify.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Foodify.Infrastructure.DAL;

public sealed class FoodifyDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Subscription> Subscriptions { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Restaurant> Restaurants { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;

    public FoodifyDbContext(DbContextOptions<FoodifyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodifyDbContext).Assembly);
    }
}