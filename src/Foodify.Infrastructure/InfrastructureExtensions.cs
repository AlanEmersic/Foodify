using Foodify.Domain.Common.Interfaces;
using Foodify.Infrastructure.DAL;
using Foodify.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Foodify.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        services.AddServices();

        services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddProblemDetails();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().WithOrigins("https://localhost:3000"));
        app.UseExceptionHandler();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseEndpoints(builder =>
        {
            builder.MapControllers();

            builder.MapFallbackToFile("index.html");
        });

        return app;
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining(typeof(InfrastructureExtensions)));
        services.AddScoped<IDateTimeProvider, SystemDateTimeProvider>();
    }
}