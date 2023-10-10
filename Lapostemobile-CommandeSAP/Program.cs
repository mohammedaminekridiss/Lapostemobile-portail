using LaPosteMobile_CommonConfiguration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri(AppConfig.RabbitMQUri);
factory.ClientProvidedName = AppConfig.ClientProvidedName;
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
 
    var body = Encoding.UTF8.GetBytes(AppConfig.SapConfirmationmessage);
    channel.ExchangeDeclare(AppConfig.ExchangeName, ExchangeType.Direct);
    channel.QueueDeclare(queue: AppConfig.SapConfirmationQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
    channel.QueueDeclare(queue: AppConfig.SapQueue, durable: false, exclusive: false,  autoDelete: false,  arguments: null);
    channel.QueueBind(AppConfig.SapQueue, AppConfig.ExchangeName, AppConfig.SapRoutingKey, null);
    channel.QueueBind(AppConfig.SapConfirmationQueue, AppConfig.ExchangeName, AppConfig.SapConfirmationRoutingKey, null);
    channel.BasicQos(0, 1, false);

     var consumer = new EventingBasicConsumer(channel);

    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("Message reçu  SAP: " + message);
        channel.BasicPublish(exchange: AppConfig.ExchangeName, routingKey: AppConfig.SapConfirmationRoutingKey, basicProperties: null, body: body);
        Console.WriteLine("Message envoyé vers  contrat (queue) : " + message + " -->" + new DateTime());
        channel.BasicAck(ea.DeliveryTag, false);
    };

     string consumerTag = channel.BasicConsume(queue: AppConfig.SapQueue, false, consumer: consumer);

    Console.WriteLine("En attendant les  messages. Cliquer sur [entrer] pour quitter.");
    Console.ReadLine();
    channel.BasicCancel(consumerTag);



}
