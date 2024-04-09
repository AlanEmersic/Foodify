using Foodify.Application;
using Foodify.Domain;
using Foodify.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

WebApplication app = builder.Build();

app.UseInfrastructure();

app.Run();