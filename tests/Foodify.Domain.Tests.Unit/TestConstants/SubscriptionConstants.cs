using Foodify.Domain.Subscriptions;

namespace Foodify.Domain.Tests.Unit.TestConstants;

internal static class SubscriptionConstants
{
    public static readonly Guid Id = Guid.NewGuid();
    public static readonly SubscriptionType DefaultSubscriptionType = SubscriptionType.Free;
}