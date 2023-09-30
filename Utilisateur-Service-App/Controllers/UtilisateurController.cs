using Lapostemobile_portail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Utilisateur_Service_App.Models;

namespace Utilisateur_Service_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : Controller
    {
        private readonly PortailContext context;

        public UtilisateurController(PortailContext context)
        {
            this.context = context;
        }
        [HttpPost("Inscription")]
        public async Task<IActionResult> Register(RequeteInscriptionUtilisateur requete)
        {
            if (context.Utilisateurs.Any(u => u.Email == requete.Email))
            {
                return BadRequest("Utilisateur existe déjà.");
            }

            creationmotdepassehash(requete.MotDePasse,out byte[] mdphash,out byte[] mdpsel);

            var utilisateur = new Utilisateur
            {
                Email = requete.Email,
                MotdepasseHash = mdphash,
                MotdepasseSel = mdpsel,
                VerificationToken = CreateRandomToken()
            };

            context.Utilisateurs.Add(utilisateur);
            await context.SaveChangesAsync();

            return Ok("Utilisateur crée!");
        }
        private void creationmotdepassehash(string motdepasse, out byte[] mdphash, out byte[] mdpsel)
        {
            using (var hmac = new HMACSHA512())
            {
                mdpsel = hmac.Key;
                mdphash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(motdepasse));
            }
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
        [HttpPost("connecter")]
        public async Task<IActionResult> Login(requeteconnexionutilisateur requete)
        {
            var utilisateur = await context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == requete.Email);
            if (utilisateur == null)
            {
                return BadRequest("utilisateur n'existe pas.");
            }

            if (!VerifierMotdepasseHash(requete.MotDePasse, utilisateur.MotdepasseHash, utilisateur.MotdepasseSel))
            {
                return BadRequest("mot de passe incorrecte !");
            }

            if (utilisateur.VerificationAt == null)
            {
                return BadRequest("non verifié!");
            }

            return Ok($"Bienvenue de nouveau, {utilisateur.Email}! :)");
        }
        private bool VerifierMotdepasseHash(string MotDePasse, byte[] MotdepasseHash, byte[] MotdepasseSel)
        {
            using (var hmac = new HMACSHA512(MotdepasseSel))
            {
                var computedHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(MotDePasse));
                return computedHash.SequenceEqual(MotdepasseHash);
            }
        }
        [HttpPost("verifier")]
        public async Task<IActionResult> Verify(string token)
        {
            var uilistateur = await context.Utilisateurs.FirstOrDefaultAsync(u => u.VerificationToken == token);
            if (uilistateur == null)
            {
                return BadRequest("token non valide.");
            }

            uilistateur.VerificationAt = DateTime.Now;
            await context.SaveChangesAsync();

            return Ok("utilisateur verifié! :)");
        }


        [HttpPost("mdp-oublie")]
        public async Task<IActionResult> MdpOublier(string email)
        {
            var utilisateur = await context.Utilisateurs.FirstOrDefaultAsync(u => u.Email == email);
            if (utilisateur == null)
            {
                return BadRequest("Utilisateur n'existe pas.");
            }

            utilisateur.MotdepassereinitialiseToken = CreateRandomToken();
            utilisateur.ReinitialiseTokenExpire = DateTime.Now.AddDays(1);
            await context.SaveChangesAsync();

            return Ok("tu dois reinitialiser ta mot de passe ");
        }

        [HttpPost("reinitialiser-mdp")]
        public async Task<IActionResult> reinitialisermdp(Requeteinitialisermdp requete)
        {
            var utilisateur = await context.Utilisateurs.FirstOrDefaultAsync(u => u.MotdepassereinitialiseToken == requete.Token);
            if (utilisateur == null || utilisateur.ReinitialiseTokenExpire < DateTime.Now)
            {
                return BadRequest("tokennonvalide.");
            }
            creationmotdepassehash(requete.Mdp, out byte[] mdphash, out byte[] mdpsel);

 
            utilisateur.MotdepasseHash = mdphash;
            utilisateur.MotdepasseSel = mdpsel;
            utilisateur.MotdepassereinitialiseToken = null;
            utilisateur.ReinitialiseTokenExpire = null;

            await context.SaveChangesAsync();

            return Ok("mot de passe correctement reinitialisé.");
        }
    }
  
}
