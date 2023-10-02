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

            // RabbitMQ connection string
            
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new  Uri("amqp://guest:guest@localhost:5672");
            factory.ClientProvidedName = "sender app";
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Declare the queue to consume messages from
                string queueName = "mail-queue"; // Replace with the actual queue name
                string exchangeName = "MailExchange";
                string routingKey = "mail-routing-key";

                channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                channel.QueueBind(queueName, exchangeName, routingKey, null);
                prospect.IdCoordonneesBancaires = null; 
                var jsonMessage = JsonConvert.SerializeObject(new { prospect.Email , prospect.Nom , prospect.Prenom });
                var body = Encoding.UTF8.GetBytes(jsonMessage);
                channel.BasicPublish(exchange: exchangeName, routingKey: routingKey, basicProperties: null, body: body);
                Console.WriteLine($"Sent: {prospect}");
                  
            }

        }
    }
}
