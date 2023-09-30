using Email_SERVICE_APP.Models;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using static Org.BouncyCastle.Math.EC.ECCurve;
using MailKit.Net.Smtp;
using System.Net.Sockets;

namespace Email_SERVICE_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IConfiguration _config;

        public EmailController(IConfiguration config)
        {
            _config = config;
        }


        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

                using var smtp = new SmtpClient();
                smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
                smtp.Send(email);
                smtp.Disconnect(true);
                return Ok();
            }
            catch (SocketException ex)
            {
                // Gérez l'exception ici, par exemple, en journalisant le message d'erreur.
                return StatusCode(500, $"Erreur lors de l'envoi de l'e-mail : {ex.Message}");
            }
        }


    }
}
