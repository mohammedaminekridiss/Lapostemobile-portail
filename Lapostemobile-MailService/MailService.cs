using Lapostemobile_portail.Models;
using System.Net;
using System.Net.Mail;

namespace Lapostemobile_MailService
{
    public static class MailService
    {
        public static void sendMail(string nom , string prenom , string mail)
        {
            string fromMail = "mohammedamine.kridiss@esprit.tn";
            string fromPassword = "rmvi rpqd zdmm azpg";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = $"Salut Mr/Mme {prenom} {nom}";
            message.To.Add(new MailAddress(mail));
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
