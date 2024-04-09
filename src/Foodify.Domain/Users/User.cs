using Foodify.Domain.Common;
using Foodify.Domain.Orders;
using Foodify.Domain.Subscriptions;

namespace Foodify.Domain.Users;

public sealed class User : AggregateRoot
{
    public Guid SubscriptionId { get; init; }
    public string Username { get; init; } = null!;

    public Subscription? Subscription { get; set; }
    public IReadOnlyCollection<Order> Orders { get; set; } = null!;
}