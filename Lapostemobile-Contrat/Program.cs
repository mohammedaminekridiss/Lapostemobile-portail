
using LaPosteMobile_CommonConfiguration;
using Lapostemobile_Contrat;
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
    bool confirmation = false;
    channel.ExchangeDeclare(AppConfig.ExchangeName, ExchangeType.Direct);
    channel.QueueDeclare(queue: AppConfig.SapConfirmationQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
    channel.QueueBind(AppConfig.SapConfirmationQueue, AppConfig.ExchangeName, AppConfig.SapConfirmationRoutingKey, null);
    channel.QueueDeclare(queue: AppConfig.ContratQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
    channel.QueueBind(AppConfig.ContratQueue, AppConfig.ExchangeName, AppConfig.ContratRoutingKey, null);
    channel.BasicQos(0, 1, false);

    var consumerConfirmation = new EventingBasicConsumer(channel);
   
    consumerConfirmation.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("Confirmation Received message : " + new DateTime());
        confirmation = true;       
        channel.BasicAck(ea.DeliveryTag, false);
    };

    string consumerConfirmationTag = channel.BasicConsume(queue: AppConfig.SapConfirmationQueue, false, consumer: consumerConfirmation);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
         
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        var data = JsonConvert.DeserializeAnonymousType(message, new { IdSouscription = 0, IdArticle = 0, IdOffreEngagement = 0 });

        if (data != null)
        {
            ContratPDFService.GeneratePDFfromhtml(data.IdSouscription, data.IdArticle, data.IdOffreEngagement);
        }
        Console.WriteLine("Received message Contrat : " + message);

        confirmation = false;
        channel.BasicAck(ea.DeliveryTag, false);
    };

    string consumerTag = channel.BasicConsume(queue: AppConfig.ContratQueue, false, consumer: consumer);

    Console.WriteLine("Waiting for messages. Press [Enter] to exit.");
    Console.ReadLine();
    channel.BasicCancel(consumerTag);
    channel.BasicCancel(consumerConfirmationTag);



}
