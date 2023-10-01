using Lapostemobile_portail.Models;
using System.Net;
using System.Net.Mail;

namespace Lapostemobile_MailService
{
    public static class MailService
    {
        public static void sendMail(Prospect p)
        {
            string fromMail = "mohammedamine.kridiss@esprit.tn";
            string fromPassword = "rmvi rpqd zdmm azpg";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = $"Salut Mr/Mme {p.Prenom} {p.Nom}";
            message.To.Add(new MailAddress(p.Email));
            message.Body = "<html> Votre inscription est validée , veuillez continuer à valider les autres étapes pour terminer la souscription  </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            try
            {
                smtpClient.Send(message);
                
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
