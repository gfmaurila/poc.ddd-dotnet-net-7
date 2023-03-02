using Auth.Domain.Contract.Repositorys;
using Auth.Domain.Contract.Repositorys.Mock;
using Auth.Domain.Contract.Repositorys.View;
using Auth.Infrastruture.Repository.Repositorys;
using Auth.Infrastruture.Repository.Repositorys.Mock;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastruture.CrossCutting.IOC.DependenceInjection;

public class ConfigureRepository
{
    public static void ConfigureDependenceRepository(IServiceCollection services)
    {
        #region IOC Repositorys SQL
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserCodeResetRepository, UserCodeResetRepository>();

        services.AddScoped<ISendManssageMockRepository, SendManssageMockRepository>();

        // View
        services.AddScoped<IViewUserRepository, ViewUserRepository>();
        #endregion
    }
}
