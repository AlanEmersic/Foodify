using Foodify.Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodify.Infrastructure.DAL.Configurations;

internal sealed class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
        builder.Property(x => x.Name);
        builder.Property(x => x.Description);
        builder.Property(x => x.Price).HasPrecision(12, 5);
        builder.Property(x => x.ImageUrl);
    }
}