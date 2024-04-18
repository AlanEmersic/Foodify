using Foodify.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Foodify.Infrastructure.DAL.Configurations;

internal sealed class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
        builder.Property(x => x.Email);
        builder.Property(x => x.Password);
        builder.Property(x => x.Phone);
        builder.Property(x => x.Address);
        builder.Property(x => x.Roles)
            .HasConversion(
                type => string.Join(",", type.Select(r => r.ToString())),
                value => value.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Enum.Parse<UserRoles>).ToList()
            );
    }
}