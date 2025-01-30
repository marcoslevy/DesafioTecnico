using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace WorkerServiceFaturamento
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConnection _connection;
        private IModel _channel;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

            var factory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://admin:admin@localhost:5672/")
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "Vendas", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                _logger.LogInformation($"[x] Received: {message}");

                //Esse projeto simula um micro serviço
                //Aqui poderia relizar o Faturamento da venda, emissao de documento fiscal....
                string response = $"Processed";

                var responseBytes = Encoding.UTF8.GetBytes(response);
                var props = ea.BasicProperties;
                var replyProps = _channel.CreateBasicProperties();
                replyProps.CorrelationId = props.CorrelationId;

                _channel.BasicPublish(
                    exchange: "",
                    routingKey: props.ReplyTo,
                    basicProperties: replyProps,
                    body: responseBytes
                );

                _logger.LogInformation($"[?] Sent response: {response}");
            };

            _channel.BasicConsume(queue: "Vendas", autoAck: true, consumer: consumer);
            
            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
            base.Dispose();
        }
    }
}
