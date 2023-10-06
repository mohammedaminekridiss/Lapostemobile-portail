using LaPosteMobile_CommonConfiguration;
using Lapostemobile_MailService;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri(AppConfig.RabbitMQUri);
factory.ClientProvidedName = AppConfig.ClientProvidedName;
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(AppConfig.ExchangeName, ExchangeType.Direct);
    channel.QueueDeclare(queue: AppConfig.MailQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
    channel.QueueBind(AppConfig.MailQueue, AppConfig.ExchangeName, AppConfig.MailroutingKey, null);
    channel.BasicQos(0, 1, false);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("Received message: " + message);
        var data = JsonConvert.DeserializeAnonymousType(message, new { Email = "", Nom = "", Prenom = "" });
        if (data != null)
            MailService.sendMail(data.Nom, data.Prenom, data.Email);
        channel.BasicAck(ea.DeliveryTag, false);
    };

    string consumerTag = channel.BasicConsume(queue: AppConfig.MailQueue, false, consumer: consumer);
    Console.WriteLine("Waiting for messages. Press [Enter] to exit.");
    Console.ReadLine();
    channel.BasicCancel(consumerTag);



}
