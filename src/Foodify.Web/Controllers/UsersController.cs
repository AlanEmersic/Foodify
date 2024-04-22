using ErrorOr;
using Foodify.Application.Authorization;
using Foodify.Application.Users.DTO;
using Foodify.Infrastructure.DAL.Users.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Foodify.Web.Controllers;

[Route("api/[controller]")]
public sealed class UsersController : ApiController
{
    private readonly ISender mediator;

    public UsersController(ISender mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("{email}")]
    [Authorize(Roles = Roles.Customer)]
    public async Task<IActionResult> GetUser(string email)
    {
        GetUserQuery query = new(email);
        ErrorOr<UserDto> result = await mediator.Send(query);

        return result.Match(Ok, Problem);
    }
}