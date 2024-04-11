using Microsoft.Extensions.DependencyInjection;

namespace Foodify.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining(typeof(ApplicationExtensions)));

        return services;
    }
}