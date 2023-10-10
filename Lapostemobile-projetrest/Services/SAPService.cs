using LaPosteMobile_CommonConfiguration;
using RabbitMQ.Client;
using System.Text;

namespace Lapostemobile_projetrest.Services
{
    public class SAPService
    {
        public void sendSAP()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(AppConfig.RabbitMQUri);
            factory.ClientProvidedName = AppConfig.ClientProvidedName;
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(AppConfig.ExchangeName, ExchangeType.Direct);
                channel.QueueDeclare(queue: AppConfig.SapQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueBind(AppConfig.SapQueue, AppConfig.ExchangeName, AppConfig.SapRoutingKey, null);
                var body = Encoding.UTF8.GetBytes("Contrat!");
                channel.BasicPublish(exchange: AppConfig.ExchangeName, routingKey: AppConfig.SapRoutingKey, basicProperties: null, body: body);
                Console.WriteLine($"Envoyer: SAP");

            }

        }
    }
}
