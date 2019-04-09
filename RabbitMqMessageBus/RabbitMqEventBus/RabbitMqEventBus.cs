using System;
using Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using static RabbitMqEventBus.RabbitMqConnectionProvider;

namespace RabbitMqEventBus
{
    public sealed class RabbitMqEventBus : IEventBus, IDisposable
    {
        private readonly IModel _channel;
        
        public RabbitMqEventBus(RabbitMqServerConfiguration configuration)
        {
            _channel = OpenRabbitMqConnection(configuration).CreateModel();
        }
        
        public void Broadcast(IEvent e)
        {
            _channel.ExchangeDeclare(e.TopicName, "topic", true);
            _channel.BasicPublish(
                e.TopicName,
                string.Empty,
                null,
                e.Serialize());
        }

        public void SubscribeTo(string topicName, string consumerName, Action<IEvent> onNewEventCallback)
        {
            _channel.ExchangeDeclare(topicName, "topic", true);
            _channel.QueueDeclare(consumerName, true, false, false);
            _channel.QueueBind(consumerName, topicName, "");
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var serializedEvent = ea.Body;
                serializedEvent.Deserialize()
                    .OnSuccess(message => onNewEventCallback(message as IEvent))
                    .OnFailure(error => Console.WriteLine($"Failed to deserialize received message: {error}"));
            };

            _channel.BasicConsume(consumerName, true, consumer);
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
    }
}