using Foodify.Domain.Tests.Unit.TestConstants;
using Foodify.Domain.Users;

namespace Foodify.Domain.Tests.Unit.TestUtils.Users;

internal static class UserFactory
{
    public static User Create(string email, string password, string phone, string address, IReadOnlyCollection<UserRoles> roles, Guid? id = null, Guid? subscriptionId = null)
    {
        return new User
        {
            Id = id ?? UserConstants.Id,
            SubscriptionId = subscriptionId ?? SubscriptionConstants.Id,
            Email = email,
            Password = password,
            Phone = phone,
            Address = address,
            Roles = roles
        };
    }
}