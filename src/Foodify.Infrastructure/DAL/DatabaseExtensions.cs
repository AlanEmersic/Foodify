using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodify.Infrastructure.DAL;

internal static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        const string sectionName = "Database";
        string connectionString = configuration.GetConnectionString(sectionName)!;

        services.AddDbContext<FoodifyDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddHostedService<DatabaseInitializer>();

        return services;
    }
}