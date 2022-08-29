using RabbitMQ.Client;
using System;

namespace RabbitMQSample.Producer
{
    static class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqps://jowlimpx:yqG2VkYbFneUvAdZ-fAixHD_ixpgDywz@chimpanzee.rmq.cloudamqp.com/jowlimpx")
            };
            using (var connection = factory.CreateConnection()) 
            using (var channel = connection.CreateModel()) 
            TopicExchangePublisher.Publish(channel);
            
        }
    }
}
