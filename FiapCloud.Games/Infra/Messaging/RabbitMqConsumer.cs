using FiapCloud.Games.App.Dtos.Events;
using FiapCloud.Games.App.Features.AddOwnedGame;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace FiapCloud.Games.Infra.Messaging;

public class RabbitMqConsumer : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IServiceScopeFactory _scopeFactory;

    public RabbitMqConsumer(IServiceScopeFactory scopeFactory, IConfiguration configuration)
    {
        _scopeFactory = scopeFactory;

        var factory = new ConnectionFactory
        {
            Uri = new Uri(configuration["Rabbit:Connection"])
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare("fcg.exchange", "topic", durable: true);

        _channel.QueueDeclare(
            queue: "games-service.queue",
            durable: true,
            exclusive: false,
            autoDelete: false);

        _channel.QueueBind("games-service.queue", "fcg.exchange", "payment.succeeded");
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (sender, args) =>
        {
            var json = Encoding.UTF8.GetString(args.Body.ToArray());
            var routingKey = args.RoutingKey;

            await DispatchEventWithScope(routingKey, json);
        };

        _channel.BasicConsume(
            queue: "games-service.queue",
            autoAck: true,
            consumer: consumer
        );

        return Task.CompletedTask;
    }

    private async Task DispatchEventWithScope(string routingKey, string message)
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

        switch (routingKey)
        {
            case "payment.succeeded":
                var evt = JsonConvert.DeserializeObject<PaymentSucceededEvent>(message);
                await mediator.Send(new AddOwnedGameCommand(evt.UserId, evt.GameId));
                break;
        }
    }

    public override void Dispose()
    {
        _channel.Close();
        _connection.Close();
        base.Dispose();
    }
}
