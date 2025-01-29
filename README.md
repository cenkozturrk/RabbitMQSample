# RabbitMQ Example Project

This repository demonstrates the use of **RabbitMQ** for message queuing and communication between producer and consumer applications. RabbitMQ is a powerful message broker that enables asynchronous communication, ensuring scalability and reliability in distributed systems.

## Features

- A small example of how the Rabbitmq library and system works.
- There are RabbitMQ.Client and newtonsoft.json libraries.
- The application was created on a single project. If you want to use the application, run the producer library and open the bin file of the application and run the consumer exe.
- This way you can track both queues and exchanges tabs on cloudampq.

- All exchange types implemented. => As Exchange types
+Fanout
+Topic
+Direct
+header

Queues Output

   ![image](https://user-images.githubusercontent.com/88964984/187240979-22aea214-0bda-494a-9a80-ec1b2f50d412.png)

Excanges Output

   ![image](https://user-images.githubusercontent.com/88964984/187241081-9f9c26e4-b0a6-4682-aee0-e37d9092e9d1.png)

- If you don't have RabbitMQ installed, you can use Docker to quickly set it up:

```bash
docker run -d --hostname rabbitmq-host --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management
