using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSample.Consumer
{
    public static class TopicExchangeConsumer
    {
        public static void Consume(IModel channel)
        {
            channel.ExchangeDeclare("mini-topic-exchange", ExchangeType.Topic);
            channel.QueueDeclare("mini-topic-exchange",
                durable: true,  
                exclusive: false,
                autoDelete: false,
                arguments: null);
            channel.QueueBind("mini-topic-exchange", "mini-topic-exchange", "account.*");
            channel.BasicQos(0, 10, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("mini-topic-exchange", true, consumer);
            Console.WriteLine("Consumer started.");
            Console.ReadLine(); 

        }
    }
}
