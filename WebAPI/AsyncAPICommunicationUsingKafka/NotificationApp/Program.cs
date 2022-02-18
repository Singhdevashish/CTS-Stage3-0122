using System;

using Newtonsoft.Json;
using Confluent.Kafka;
using System.Threading;
namespace NotificationApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = new ConsumerConfig
            {
                GroupId = "NotificationsConsumer",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe("ordercreated");
                var token = new CancellationTokenSource().Token;
                while (true)
                {
                    var result = consumer.Consume(token);
                    var message = result.Message.Value;
                    Console.WriteLine(message);
                }
            }

        }
    }
}
