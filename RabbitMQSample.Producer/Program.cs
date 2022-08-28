﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            QueueProducer.Publish(channel);
            
        }
    }
}
