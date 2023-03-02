using Auth.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Infrastructure.Data.Mappings;
public class ClaimsMap : IEntityTypeConfiguration<Claims>
{
    public void Configure(EntityTypeBuilder<Claims> builder)
    {
        builder.ToTable("AspNetRoleClaims");
        builder.HasKey(x => x.Id);
    }
}