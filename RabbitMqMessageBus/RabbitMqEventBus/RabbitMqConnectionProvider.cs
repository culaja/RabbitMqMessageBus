using RabbitMQ.Client;

namespace RabbitMqEventBus
{
    internal static class RabbitMqConnectionProvider
    {
        public static IConnection OpenRabbitMqConnection(RabbitMqServerConfiguration configuration)
        {
            var factory = new ConnectionFactory {HostName = configuration.HostName};
            return factory.CreateConnection();
        }
    }
}