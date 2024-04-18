using Foodify.Application.Users.DTO;

namespace Foodify.Application.Users.Services;

public interface ICurrentUserProvider
{
    CurrentUserDto GetCurrentUser();
}