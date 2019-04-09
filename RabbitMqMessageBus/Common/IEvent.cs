namespace Common
{
    public interface IEvent : IMessage
    {
        string TopicName { get; }
    }
}