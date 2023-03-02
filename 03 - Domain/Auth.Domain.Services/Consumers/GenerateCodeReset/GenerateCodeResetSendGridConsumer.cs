using Auth.App.Dto.Menssage;
using Auth.Domain.Contract.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Auth.Domain.Services.Consumers.GenerateCodeReset;

public class GenerateCodeResetSendGridConsumer : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IServiceProvider _serviceProvider;

    public GenerateCodeResetSendGridConsumer(IServiceProvider servicesProvider)
    {
        _serviceProvider = servicesProvider;

        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(
            queue: "Email_Generate_Code_Reset",
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
            var infoSendGridBytes = eventArgs.Body.ToArray();
            var infoSendGridJson = Encoding.UTF8.GetString(infoSendGridBytes);
            var infoSendGrid = JsonSerializer.Deserialize<SendGridDto>(infoSendGridJson);
            await SendGridMock(infoSendGrid);
            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };
        _channel.BasicConsume("Email_Generate_Code_Reset", false, consumer);
        return Task.CompletedTask;
    }

    public async Task SendGridMock(SendGridDto dto)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var sendGridService = scope.ServiceProvider.GetRequiredService<ISendGridService>();
            await sendGridService.SendGridMock(dto);
        }
    }
}
