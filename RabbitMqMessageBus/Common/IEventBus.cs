using System;

namespace Common
{
    public interface IEventBus
    {
        void Broadcast(IEvent e);

        void SubscribeTo(string topicName, Action<IEvent> e);
    }
}