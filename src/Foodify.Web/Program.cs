using Foodify.Application;
using Foodify.Domain;
using Foodify.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseInfrastructure();

app.Run();