using Foodify.Application.Authentication.Commands.Register;
using Foodify.Domain.Users;

namespace Foodify.Application.Authentication.Mappings;

internal static class AuthenticationMappingExtensions
{
    public static User MapToDomain(this RegisterCommand command, string hashPassword, Guid subscriptionId)
    {
        return new User
        {
            Email = command.Email,
            Password = hashPassword,
            Phone = command.Phone,
            Address = command.Address,
            SubscriptionId = subscriptionId,
            Roles = new List<UserRoles> { UserRoles.Customer }
        };
    }
}