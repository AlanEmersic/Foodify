using Foodify.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Foodify.Infrastructure.DAL.Configurations;

internal sealed class SubscriptionConfigurations : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
        builder.Property(x => x.SubscriptionType).HasConversion(new EnumToStringConverter<SubscriptionType>());
        builder.Property(x => x.DiscountRate);

        builder.HasData(
            new Subscription { Id = Guid.NewGuid(), SubscriptionType = SubscriptionType.Free, DiscountRate = 0 },
            new Subscription { Id = Guid.NewGuid(), SubscriptionType = SubscriptionType.Plus, DiscountRate = 10 }
            );
    }
}