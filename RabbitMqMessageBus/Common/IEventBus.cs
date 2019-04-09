using System;

namespace Common
{
    public interface IEventBus
    {
        void Broadcast(IEvent e);

        void SubscribeTo(string topicName, string consumerName, Action<IEvent> e);
    }
}