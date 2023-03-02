using Auth.Domain.Contract.Services;
using Auth.Domain.Contract.Services.View;
using Auth.Domain.Services.Services;
using Auth.Domain.Services.Services.View;
using Auth.Infrastruture.CrossCutting.Handle;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastruture.CrossCutting.IOC.DependenceInjection;

public class ConfigureService
{
    public static void ConfigureDependenceService(IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<INotificationHandle, NotificationHandle>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<ITokenGeneratorService, TokenGeneratorService>();
        services.AddTransient<IUserManagerService, UserManagerService>();
        services.AddTransient<IUserService, UserService>();

        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IUserRoleService, UserRoleService>();
        services.AddTransient<ITwilioService, TwilioService>();
        services.AddTransient<ISendGridService, SendGridService>();

        // View 
        services.AddTransient<IViewUserService, ViewUserService>();
    }
}