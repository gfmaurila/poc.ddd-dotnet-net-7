using Auth.Domain.Entities.Mock;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Infrastructure.Data.Mappings;
public class SendManssageMockMap : IEntityTypeConfiguration<SendManssageMock>
{
    public void Configure(EntityTypeBuilder<SendManssageMock> builder)
    {
        builder.ToTable("SendManssageMock");
        builder.HasKey(x => x.Id);
    }
}