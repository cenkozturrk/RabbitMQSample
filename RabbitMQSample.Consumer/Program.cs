using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSample.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri =
                new Uri("amqps://jowlimpx:yqG2VkYbFneUvAdZ-fAixHD_ixpgDywz@chimpanzee.rmq.cloudamqp.com/jowlimpx")
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("demo-queue",
                durable: true,
                exclusive: false,
               autoDelete: false,
               arguments: null);

                var consumer = new EventingBasicConsumer(channel); 
                consumer.Received += (sender,e) =>
                {
                    var body = e.Body.ToArray();
                    var messeage = Encoding.UTF8.GetString(body);
                    Console.WriteLine(messeage);

                };

                channel.BasicConsume("demo-queue", true, consumer);
                Console.ReadLine();
            }
        }
    }
}
