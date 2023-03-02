using Auth.Domain.Entities.Identity;
using Auth.Infrastructure.Data.Context;
using Auth.Infrastruture.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Security.JwtSigningCredentials;

namespace Auth.Infrastruture.CrossCutting.IOC.DependenceInjection;
public class ConfigureDbContext
{
    public static void ConfigureDependenceDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EFContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        services.AddJwksManager(options => options.Algorithm = Algorithm.ES256)
                .PersistKeysToDatabaseStore<ApplicationDbContext>();

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
        })
                .AddDefaultIdentity<UserModel>()
                .AddRoles<RoleModel>()
                .AddRoleManager<RoleManager<RoleModel>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddErrorDescriber<IdentityMensagensPortugues>();
    }
}
