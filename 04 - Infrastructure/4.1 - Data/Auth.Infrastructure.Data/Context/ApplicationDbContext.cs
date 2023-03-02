using Auth.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetDevPack.Security.JwtSigningCredentials;
using NetDevPack.Security.JwtSigningCredentials.Store.EntityFrameworkCore;

namespace Auth.Infrastructure.Data.Context;
public class ApplicationDbContext : IdentityDbContext<UserModel, RoleModel, int>, ISecurityKeyContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public virtual DbSet<UserModel> UserModel { get; set; }
    public virtual DbSet<RoleModel> RoleModel { get; set; }
    public virtual DbSet<UserRoleModel> UserRoleModel { get; set; }
    public virtual DbSet<SecurityKeyWithPrivate> SecurityKeys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);
        base.OnConfiguring(optionsBuilder);
    }

    public static readonly Microsoft.Extensions.Logging.LoggerFactory _loggerFactory = new LoggerFactory(new[] {
        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
    });

}