using System;
using static System.Console;
using static RabbitMqEventBus.RabbitMqServerConfiguration;

namespace EventConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidateInput(args);
            new Program().Run(args[0], args[1]);
        }

        private static void ValidateInput(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException("You should provide topic name and consumer name as arguments");
            }
        }
        
        private void Run(string topicName, string consumerName)
        {
            using (var eventBus = new RabbitMqEventBus.RabbitMqEventBus(LocalhostRabbitMqServerConfiguration))
            {
                eventBus.SubscribeTo(topicName, consumerName, e => WriteLine($"Event received: {e}"));
            
                WriteLine("Press enter to exit from application");
                ReadLine();
            }
        }
    }
}