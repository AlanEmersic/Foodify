using ErrorOr;
using Foodify.Application.Authorization;
using MediatR;

namespace Foodify.Application.Restaurants.Commands.DeleteProduct;

[Authorize(Roles = Roles.Admin)]
public sealed record DeleteProductCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;