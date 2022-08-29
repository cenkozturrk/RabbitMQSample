using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSample.Consumer
{
    public static class FanoutExchangeConsumer
    {
        public static void Consume(IModel channel)
        {
            channel.ExchangeDeclare("mini-fanout-exchange", ExchangeType.Fanout);
            channel.QueueDeclare("mini-fanout-exchange",
                durable: true,  
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var header = new Dictionary<string, object>()
            {
                {"account", "new" }
            };


            channel.QueueBind("mini-fanout-exchange", "mini-fanout-exchange", string.Empty , header);
            channel.BasicQos(0, 10, false);

           
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("mini-fanout-exchange", true, consumer);
            Console.WriteLine("Consumer started.");
            Console.ReadLine(); 

        }
    }
}
