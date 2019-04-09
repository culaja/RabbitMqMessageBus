using System.Collections.Generic;

namespace Common
{
    public interface IEvent : IMessage
    {
        string TopicName { get; }
    }
}