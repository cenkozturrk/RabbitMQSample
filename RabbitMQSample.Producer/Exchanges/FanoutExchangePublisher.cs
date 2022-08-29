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
    public static class FanoutExchangePublisher
    {
        public static void Publish(IModel channel)
        {
            var ttl = new Dictionary<string, object>
            {
                { "x-message-ttl", 30000 }
            };
            channel.ExchangeDeclare("mini-fanout-exchange", ExchangeType.Fanout, arguments: ttl);
            var count = 0;

            while (true)
            {
                var message = new { Name = "Producer", Message = $"Hello Dude , Count:{count} " };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                var properties = channel.CreateBasicProperties(); // Bu ozellikleri kullanmamıza gerek yok.Opsiyonel
                properties.Headers = new Dictionary<string, object>()
                {
                    {"account", "update" }
                }; 

                channel.BasicPublish("mini-fanout-exchange", "account.new" , properties , body);
                count++;

                Thread.Sleep(1000);
            }
        }
}}
