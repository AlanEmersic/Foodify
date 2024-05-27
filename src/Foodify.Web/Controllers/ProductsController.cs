using ErrorOr;
using Foodify.Application.Authorization;
using Foodify.Application.Restaurants.Commands.CreateProduct;
using Foodify.Application.Restaurants.Commands.DeleteProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodify.Web.Controllers;

[Route("api/[controller]")]
public sealed class ProductsController : ApiController
{
    private readonly ISender mediator;

    public ProductsController(ISender mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        ErrorOr<Created> result = await mediator.Send(command);

        return result.Match(_ => CreatedAtAction(nameof(CreateProduct), default), Problem);
    }

    [HttpDelete]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        DeleteProductCommand command = new(id);
        ErrorOr<Deleted> result = await mediator.Send(command);

        return result.Match(_ => NoContent(), Problem);
    }
}