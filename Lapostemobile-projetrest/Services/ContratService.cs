using LaPosteMobile_CommonConfiguration;
using Lapostemobile_portail.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Lapostemobile_projetrest.Services
{
    public class ContratService
    {
 
        public void sendContrat(Souscription nouvellesouscription,LigneArticle nouvelleLigneArticle, Ligne nouvelleLigne)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri(AppConfig.RabbitMQUri);
            factory.ClientProvidedName = AppConfig.ClientProvidedName;
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(AppConfig.ExchangeName, ExchangeType.Direct);
                channel.QueueDeclare(queue: AppConfig.ContratQueue, durable: false,  exclusive: false, autoDelete: false, arguments: null);
                channel.QueueBind(AppConfig.ContratQueue, AppConfig.ExchangeName, AppConfig.ContratRoutingKey, null);
                var jsonMessage = JsonConvert.SerializeObject(new { nouvellesouscription.IdSouscription , nouvelleLigneArticle.IdArticle , nouvelleLigne.IdOffreEngagement });
                var body = Encoding.UTF8.GetBytes(jsonMessage);


                 channel.BasicPublish(exchange: AppConfig.ExchangeName, routingKey: AppConfig.ContratRoutingKey, basicProperties: null, body: body);
                Console.WriteLine($"Sent: {jsonMessage}");

            }

        }
    }
}
