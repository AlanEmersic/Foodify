using Foodify.Domain.Common;
using Foodify.Domain.Users;

namespace Foodify.Domain.Subscriptions;

public sealed class Subscription : AggregateRoot
{
    public SubscriptionType SubscriptionType { get; init; }
    public float DiscountRate { get; init; }

    public IReadOnlyCollection<User> Users { get; set; } = null!;
}