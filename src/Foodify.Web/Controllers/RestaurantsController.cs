using ErrorOr;
using Foodify.Application.Authorization;
using Foodify.Application.Restaurants.Commands.CreateRestaurant;
using Foodify.Application.Restaurants.Commands.DeleteRestaurant;
using Foodify.Application.Restaurants.DTO;
using Foodify.Infrastructure.DAL.Restaurants.Queries.GetRestaurant;
using Foodify.Infrastructure.DAL.Restaurants.Queries.GetRestaurants;
using Foodify.Infrastructure.DAL.Restaurants.Queries.GetRestaurantSummary;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodify.Web.Controllers;

[Route("api/[controller]")]
public sealed class RestaurantsController : ApiController
{
    private readonly ISender mediator;

    public RestaurantsController(ISender mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        GetRestaurantsQuery query = new();
        ErrorOr<IReadOnlyList<RestaurantDto>> result = await mediator.Send(query);

        return result.Match(Ok, Problem);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRestaurant(Guid id)
    {
        GetRestaurantQuery query = new(id);
        ErrorOr<RestaurantDto> result = await mediator.Send(query);

        return result.Match(Ok, Problem);
    }

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
    {
        ErrorOr<Created> result = await mediator.Send(command);

        return result.Match(_ => CreatedAtAction(nameof(CreateRestaurant), default), Problem);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> DeleteRestaurant(Guid id)
    {
        DeleteRestaurantCommand command = new(id);
        ErrorOr<Deleted> result = await mediator.Send(command);

        return result.Match(_ => NoContent(), Problem);
    }

    [HttpGet("{id:guid}/summary")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> GetProductsSummary(Guid id)
    {
        GetRestaurantSummaryQuery query = new(id);
        ErrorOr<RestaurantSummary> result = await mediator.Send(query);

        return result.Match(Ok, Problem);
    }
}