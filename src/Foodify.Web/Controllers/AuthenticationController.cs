using ErrorOr;
using Foodify.Application.Authentication.Commands.Register;
using Foodify.Application.Authentication.DTO;
using Foodify.Infrastructure.Authentication.Errors;
using Foodify.Infrastructure.Authentication.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foodify.Web.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
public sealed class AuthenticationController : ApiController
{
    private readonly ISender mediator;

    public AuthenticationController(ISender mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        ErrorOr<AuthenticationDto> authenticationResult = await mediator.Send(command);

        return authenticationResult.Match(Ok, Problem);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginQuery query)
    {
        ErrorOr<AuthenticationDto> authenticationResult = await mediator.Send(query);

        if (authenticationResult.IsError && authenticationResult.FirstError == AuthenticationErrors.InvalidCredentials)
        {
            return Problem(detail: authenticationResult.FirstError.Description, statusCode: StatusCodes.Status401Unauthorized);
        }

        return authenticationResult.Match(Ok, Problem);
    }
}