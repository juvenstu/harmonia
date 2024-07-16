using System.Text;
using System.Text.Json;
using PlatformService.Dtos;
using RabbitMQ.Client;

namespace PlatformService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient, IDisposable
    {
        private readonly IConnection? _connection;
        private readonly IModel? _channel;
        private bool _disposed = false;

        public MessageBusClient(IConfiguration configuration)
        {
            var _configuration = configuration;

            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.TryParse(_configuration["RabbitMQPort"], out int port) ? port : 5672
            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
                _connection.ConnectionShutdown += RabbitMQConnectionShutdown;

                Console.WriteLine("info: Connected to the message bus.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"error: Could not connect to the message bus: {e.Message}");
                _connection = null;
                _channel = null;
            }
        }

        private void RabbitMQConnectionShutdown(object? sender, ShutdownEventArgs e)
        {
            Console.WriteLine("info: RabbitMQ connection shutdown");
        }

        public void PublishNewPlatform(PlatformPublishDto platformPublishDto)
        {
            var message = JsonSerializer.Serialize(platformPublishDto);

            if (_connection?.IsOpen == true)
            {
                Console.WriteLine("info: RabbitMQ connection is open, sending messages...");
                SendMessage(message);
            }
            else
            {
                Console.WriteLine("warning: RabbitMQ connection is closed, not sending messages.");
            }
        }

        private void SendMessage(string message)
        {
            if (_channel != null)
            {
                var body = Encoding.UTF8.GetBytes(message);
                _channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);
                Console.WriteLine($"info: We have sent {message}");
            }
            else
            {
                Console.WriteLine("error: Channel is not available to send messages.");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                if (_channel?.IsOpen == true) _channel.Close();
                _connection?.Close();
            }

            _disposed = true;
        }

        ~MessageBusClient()
        {
            Dispose(false);
        }
    }
}