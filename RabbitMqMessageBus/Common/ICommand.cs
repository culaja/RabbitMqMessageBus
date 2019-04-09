namespace Common
{
    public interface ICommand : IMessage
    {
        string Source { get; }
        
        string Destination { get; }
    }
}