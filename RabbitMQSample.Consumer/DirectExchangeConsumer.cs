using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSample.Consumer
{
    public static class DirectExchangeConsumer
    {
        public static void Consumer(IModel channel)
        {
            // Direct exchange used here.
            channel.ExchangeDeclare("mini-direct-exchange", ExchangeType.Direct);
            channel.QueueDeclare("mini-direct-queue",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
            channel.QueueBind("mini-direct-exchange", "mini-direct-exchange", "account.init");
            channel.BasicQos(prefetchSize: 0 , prefetchCount: 10 , global: false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var messeage = Encoding.UTF8.GetString(body);
                Console.WriteLine(messeage);

            };

            channel.BasicConsume("mini-direct-exchange", true, consumer);
            Console.WriteLine("Consumer started");
            Console.ReadLine();
        }
    }
}
