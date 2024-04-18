using Foodify.Application.Users.DTO;
using Foodify.Application.Users.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Foodify.Infrastructure.DAL.Users.Services;

internal class CurrentUserProvider : ICurrentUserProvider
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public CurrentUserDto GetCurrentUser()
    {
        if (httpContextAccessor.HttpContext is null)
        {
            throw new InvalidOperationException("HttpContext is null");
        }

        const string idClaim = "id";
        Guid id = GetClaimValues(idClaim).Select(Guid.Parse).FirstOrDefault();

        IReadOnlyList<string> roles = GetClaimValues(ClaimTypes.Role);

        return new CurrentUserDto(id, roles);
    }

    private IReadOnlyList<string> GetClaimValues(string claimType)
    {
        return httpContextAccessor.HttpContext!.User.Claims
            .Where(claim => claim.Type == claimType)
            .Select(claim => claim.Value)
            .ToList();
    }
}