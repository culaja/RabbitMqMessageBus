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
            new Program().Run(args[0]);
        }

        private static void ValidateInput(string[] args)
        {
            if (args.Length < 1)
            {
                throw new ArgumentException("You should provide topic name as an argument");
            }
        }
        
        private void Run(string topicName)
        {
            using (var eventBus = new RabbitMqEventBus.RabbitMqEventBus(LocalhostRabbitMqServerConfiguration))
            {
                eventBus.SubscribeTo(topicName, "EventConsumer1", e => WriteLine($"Event received: {e}"));
            
                WriteLine("Press enter to exit from application");
                ReadLine();
            }
        }
    }
}