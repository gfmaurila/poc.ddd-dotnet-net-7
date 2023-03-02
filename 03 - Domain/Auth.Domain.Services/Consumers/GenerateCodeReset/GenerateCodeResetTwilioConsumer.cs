using Auth.App.Dto.Menssage;
using Auth.Domain.Contract.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Auth.Domain.Services.Consumers.GenerateCodeReset;

public class GenerateCodeResetTwilioConsumer : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IServiceProvider _serviceProvider;

    public GenerateCodeResetTwilioConsumer(IServiceProvider servicesProvider)
    {
        _serviceProvider = servicesProvider;

        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(
            queue: "WhatsApp_Generate_Code_Reset",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (sender, eventArgs) =>
        {
            var infoTwilioBytes = eventArgs.Body.ToArray();
            var infoTwilioJson = Encoding.UTF8.GetString(infoTwilioBytes);
            var infoTwilio = JsonSerializer.Deserialize<TwilioDto>(infoTwilioJson);
            await TwilioSendMock(infoTwilio);
            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };
        _channel.BasicConsume("WhatsApp_Generate_Code_Reset", false, consumer);
        return Task.CompletedTask;
    }

    public async Task TwilioSendMock(TwilioDto dto)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var sendTwilioService = scope.ServiceProvider.GetRequiredService<ITwilioService>();
            await sendTwilioService.TwilioSendMock(dto);
        }
    }
}
