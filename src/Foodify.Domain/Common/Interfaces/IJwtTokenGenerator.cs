using Foodify.Domain.Users;

namespace Foodify.Domain.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}