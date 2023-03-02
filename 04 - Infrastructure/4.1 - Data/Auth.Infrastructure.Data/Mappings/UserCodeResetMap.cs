using Auth.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Infrastructure.Data.Mappings;
public class UserCodeResetMap : IEntityTypeConfiguration<UserCodeReset>
{
    public void Configure(EntityTypeBuilder<UserCodeReset> builder)
    {
        builder.ToTable("UserCodeReset");
        builder.HasKey(x => x.Id);
    }
}