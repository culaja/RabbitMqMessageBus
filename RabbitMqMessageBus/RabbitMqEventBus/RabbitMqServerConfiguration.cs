namespace RabbitMqEventBus
{
    public sealed class RabbitMqServerConfiguration
    {
        public static readonly RabbitMqServerConfiguration LocalhostRabbitMqServerConfiguration = new RabbitMqServerConfiguration("localhost"); 
        
        public string HostName { get; }

        public RabbitMqServerConfiguration(
            string hostName)
        {
            HostName = hostName;
        }
    }
}