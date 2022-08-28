using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQSample.Producer
{
    public static class QueueProducer
    {        
        public static void Publish(IModel channel)
        {    
            channel.QueueDeclare("demo-queue",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

            var count = 0;

            while (true)
            {
                var message = new { Name = "Producer", Message = $"Im Here Count: {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("", "demo-queue", null, body);
                count++;
                Thread.Sleep(1000); 
            }        
                      
        }
     
    }
}
