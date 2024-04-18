﻿using Foodify.Domain.Common.Interfaces;
using Foodify.Domain.Repositories;
using Foodify.Infrastructure.DAL.Restaurants.Repositories;
using Foodify.Infrastructure.DAL.Users.Repositories;
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

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<FoodifyDbContext>());
        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}