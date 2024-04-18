using Foodify.Domain.Common;
using Foodify.Domain.Common.Interfaces;
using Foodify.Domain.Orders;
using Foodify.Domain.Subscriptions;

namespace Foodify.Domain.Users;

public sealed class User : AggregateRoot
{
    public Guid SubscriptionId { get; init; }
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string Phone { get; init; } = null!;
    public string Address { get; init; } = null!;
    public IReadOnlyCollection<UserRoles> Roles { get; init; } = null!;

    public Subscription? Subscription { get; set; }
    public IReadOnlyCollection<Order> Orders { get; set; } = null!;

    public bool IsCorrectPasswordHash(string password, string hashPassword, IPasswordHasher passwordHasher)
    {
        return passwordHasher.IsCorrectPassword(password, hashPassword);
    }
}