using Foodify.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Foodify.Infrastructure.DAL.Configurations;

internal sealed class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
        builder.Property(x => x.Status).HasConversion(new EnumToStringConverter<OrderStatus>());
        builder.Property(x => x.Quantity);
        builder.Property(x => x.TotalPrice).HasPrecision(12, 5);
        builder.Property(x => x.PlacedTime);
        builder.Property(x => x.CompletedTime);
    }
}