using System;
using System.Text;
using System.Threading.Channels;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

// RabbitMQ connection string
var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost:5672", // Replace with your RabbitMQ server address
    UserName = "guest",
    Password = "guest"
};

using (var connection = connectionFactory.CreateConnection())
using (var channel = connection.CreateModel())
{
    // Declare the queue to consume messages from
    string queueName = "mail-queue"; // Replace with the actual queue name
    string exchangeName = "MailExchange";
    string routingKey =  "mail-routing-key";

    channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
    channel.QueueDeclare(queue: queueName,
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
    channel.QueueBind(queueName, exchangeName, routingKey,null);
    channel.BasicQos(0, 1, false);

    // Set up a consumer to receive messages
    var consumer = new EventingBasicConsumer(channel);

    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("Received message: " + message);

        // Add your processing logic here
        channel.BasicAck(ea.DeliveryTag, false);
    };

    // Start consuming messages
    string consumerTag = channel.BasicConsume(queue: queueName,
                         false, // Set to true if you want messages to be automatically acknowledged
                         consumer: consumer);
    
    Console.WriteLine("Waiting for messages. Press [Enter] to exit.");
    Console.ReadLine();
    channel.BasicCancel(consumerTag);
}
