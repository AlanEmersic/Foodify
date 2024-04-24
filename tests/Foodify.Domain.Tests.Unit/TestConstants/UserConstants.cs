using Foodify.Domain.Users;

namespace Foodify.Domain.Tests.Unit.TestConstants;

internal static class UserConstants
{
    public static readonly Guid Id = Guid.NewGuid();
    public static readonly string Email = "test.email@test.com";
    public static readonly string Password = "testPassword!1";
    public static readonly string Phone = "0123456789";
    public static readonly string Address = "Test Address";
    public static readonly IReadOnlyCollection<UserRoles> CustomerRoles = new List<UserRoles> { UserRoles.Customer };
    public static readonly IReadOnlyCollection<UserRoles> AdminRoles = new List<UserRoles> { UserRoles.Admin, UserRoles.Customer };
}