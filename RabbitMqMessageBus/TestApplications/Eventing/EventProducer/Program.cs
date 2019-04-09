using System;
using TestEvents;
using static System.Console;
using static RabbitMqEventBus.RabbitMqServerConfiguration;

namespace EventProducer
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
            var eventBus = new RabbitMqEventBus.RabbitMqEventBus(LocalhostRabbitMqServerConfiguration);
            
            WriteLine("Press enter to send a event");

            var number = 0;
            while (true)
            {
                ReadLine();
                var e = new TestEvent(topicName, ++number);
                eventBus.Broadcast(e);
                WriteLine($"Event broad casted: {e}");
            }
        }
    }
}