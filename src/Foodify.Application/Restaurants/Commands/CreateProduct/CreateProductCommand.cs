using ErrorOr;
using Foodify.Application.Authorization;
using MediatR;

namespace Foodify.Application.Restaurants.Commands.CreateProduct;

[Authorize(Roles = Roles.Admin)]
public sealed record CreateProductCommand(Guid RestaurantId, string Name, string Description, decimal Price, string ImageUrl) : IRequest<ErrorOr<Created>>;