using Foodify.Domain.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodify.Infrastructure.DAL.Configurations;

internal sealed class RestaurantConfigurations : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
        builder.Property(x => x.Name);
        builder.Property(x => x.Description);
        builder.Property(x => x.Address);
        builder.Property(x => x.Email);
        builder.Property(x => x.ImageUrl);
    }
}