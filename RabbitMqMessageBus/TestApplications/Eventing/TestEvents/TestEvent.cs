using System;
using Common;

namespace TestEvents
{
    public sealed class TestEvent : IEvent
    {
        public DateTime Timestamp { get; } = DateTime.UtcNow;
        public string TopicName { get; }
        public int Number { get; }

        public TestEvent(string topicName, int number)
        {
            TopicName = topicName;
            Number = number;
        }

        public override string ToString() => $"TopicName: {TopicName}, Number: {Number}";
    }
}