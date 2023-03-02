using Auth.Domain.Entities.Mock;
using Auth.Domain.Entities.Users;
using Auth.Domain.View.User;
using Auth.Infrastructure.Data.Mappings;
using Auth.Infrastructure.Data.Mappings.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auth.Infrastructure.Data.Context;
public class EFContext : DbContext
{
    public EFContext()
    { }

    public EFContext(DbContextOptions<EFContext> options) : base(options)
    { }

    public virtual DbSet<Claims> Claims { get; set; }
    public virtual DbSet<Role> Role { get; set; }
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<UserRole> UserRole { get; set; }
    public virtual DbSet<UserCodeReset> UserCodeReset { get; set; }
    public virtual DbSet<SendManssageMock> SendManssageMock { get; set; }

    // Views
    public virtual DbSet<ViewUserList> ViewUserList { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ClaimsMap());
        builder.ApplyConfiguration(new RoleMap());
        builder.ApplyConfiguration(new UserMap());
        builder.ApplyConfiguration(new UserRoleMap());
        builder.ApplyConfiguration(new UserCodeResetMap());
        builder.ApplyConfiguration(new SendManssageMockMap());

        // View
        builder.ApplyConfiguration(new ViewUserListMap());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        base.OnConfiguring(optionsBuilder);
    }

    public static readonly Microsoft.Extensions.Logging.LoggerFactory _loggerFactory = new LoggerFactory(new[] {
        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    });

}