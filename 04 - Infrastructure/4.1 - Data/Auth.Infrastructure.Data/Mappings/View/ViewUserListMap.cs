using Auth.Domain.View.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Infrastructure.Data.Mappings.View;
public class ViewUserListMap : IEntityTypeConfiguration<ViewUserList>
{
    public void Configure(EntityTypeBuilder<ViewUserList> builder)
    {
        builder.ToView("ViewUserList");
        builder.HasKey(x => x.Id);
    }
}
