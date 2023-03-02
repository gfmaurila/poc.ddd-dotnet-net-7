using Auth.Domain.Contract.MessageBus;
using Auth.Domain.Services.Consumers.GenerateCodeReset;
using Auth.Domain.Services.MessageBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastruture.CrossCutting.IOC.DependenceInjection;

public class ConfigureConsumer
{
    public static void ConfigureConsumerDependence(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.AddScoped<IMessageBusService, MessageBusService>();

        services.AddHostedService<GenerateCodeResetTwilioConsumer>();
        services.AddHostedService<GenerateCodeResetSendGridConsumer>();
    }
}

