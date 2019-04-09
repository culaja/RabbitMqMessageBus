namespace Common
{
    public interface IEventBus
    {
        void Broadcast(IEvent e);
    }
}