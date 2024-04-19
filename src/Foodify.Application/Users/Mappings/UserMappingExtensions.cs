using Foodify.Application.Users.DTO;
using Foodify.Domain.Users;

namespace Foodify.Application.Users.Mappings;

public static class UserMappingExtensions
{
    public static UserDto MapToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Phone = user.Phone,
            Address = user.Address,
            Roles = user.Roles,
            SubscriptionType = user.Subscription!.SubscriptionType
        };
    }
}