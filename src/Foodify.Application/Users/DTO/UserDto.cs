using Foodify.Domain.Subscriptions;
using Foodify.Domain.Users;

namespace Foodify.Application.Users.DTO;

public sealed record UserDto
{
    public Guid Id { get; init; }
    public string Email { get; init; } = null!;
    public string Phone { get; init; } = null!;
    public string Address { get; init; } = null!;
    public IReadOnlyCollection<UserRoles> Roles { get; init; } = null!;
    public SubscriptionType SubscriptionType { get; init; }
}