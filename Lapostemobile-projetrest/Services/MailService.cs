using LaPosteMobile_CommonConfiguration;
using Lapostemobile_portail.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Lapostemobile_projetrest.Services
{
    public class MailService
    {
        public void sendMail(Prospect prospect)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(AppConfig.RabbitMQUri);
            factory.ClientProvidedName = AppConfig.ClientProvidedName;
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {

                channel.ExchangeDeclare(AppConfig.ExchangeName, ExchangeType.Direct);
                channel.QueueDeclare(queue: AppConfig.MailQueue, durable: false, exclusive: false,  autoDelete: false,  arguments: null);
                channel.QueueBind(AppConfig.MailQueue, AppConfig.ExchangeName, AppConfig.MailroutingKey, null);
                prospect.IdCoordonneesBancaires = null;
                var jsonMessage = JsonConvert.SerializeObject(new { prospect.Email, prospect.Nom, prospect.Prenom });
                var body = Encoding.UTF8.GetBytes(jsonMessage);
                channel.BasicPublish(exchange: AppConfig.ExchangeName, AppConfig.MailroutingKey, basicProperties: null, body: body);
                Console.WriteLine($"Sent: {prospect}");

            }

        }
    }
}
