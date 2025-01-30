using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Vendas.Core.Services;

namespace Vendas.Infra.Services;

public class MessageBusService : IMessageBusService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _replyQueueName;
    private readonly EventingBasicConsumer _consumer;
    private readonly TaskCompletionSource<string> _responseTask;

    public MessageBusService(string connectionString)
    {
        var factory = new ConnectionFactory() { Uri = new Uri(connectionString) };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _replyQueueName = _channel.QueueDeclare().QueueName;
        _consumer = new EventingBasicConsumer(_channel);
        _responseTask = new TaskCompletionSource<string>();

        _consumer.Received += (model, ea) =>
        {
            var response = Encoding.UTF8.GetString(ea.Body.ToArray());
            _responseTask.SetResult(response);
        };
    }

    public async Task<string> PublishAndWaitForReplyAsync(string queueName, string message)
    {
        var correlationId = Guid.NewGuid().ToString();
        var props = _channel.CreateBasicProperties();
        props.CorrelationId = correlationId;
        props.ReplyTo = _replyQueueName;

        var messageBody = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: props, body: messageBody);

        _channel.BasicConsume(consumer: _consumer, queue: _replyQueueName, autoAck: true);

        return await _responseTask.Task; // Aguarda a resposta
    }
}
