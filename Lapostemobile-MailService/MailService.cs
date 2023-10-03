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
            message.Subject = $"Validation d'inscription de Mr/Mme {nom} {prenom}";
            message.To.Add(new MailAddress(mail));

            string body = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
        .container {
            background-color: #ffffff;
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
        }
        .header {
            background-color: #007acc;
            color: #ffffff;
            text-align: center;
            padding: 10px 0;
        }
        .message {
            padding: 20px 0;
        }
        .signature {
            font-style: italic;
        }
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Validation d'inscription</h1>
        </div>
        <div class='message'>
            <p>Bonjour,</p>
            <p>Nous avons le plaisir de vous informer que votre inscription a été validée avec succès. Nous vous remercions de votre confiance en notre service.</p>
            <p>Veuillez maintenant poursuivre le processus de souscription en suivant les étapes restantes afin de finaliser votre inscription.</p>
            <p>Si vous avez des questions ou besoin d'assistance, n'hésitez pas à nous contacter. Nous sommes là pour vous aider.</p>
        </div>
        <div class='signature'>
            <p>Cordialement,</p>
            <p>[La Poste-mobile]</p>
        </div>
    </div>
</body>
</html>
";

            message.Body = body;
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
