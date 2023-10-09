using Lapostemobile_Contrat;
using Lapostemobile_portail.Models;
using Lapostemobile_projetrest.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SouscriptionController : Controller
    {
        private readonly PortailContext context;
        private readonly ContratService _contratService;


        public SouscriptionController(PortailContext context, ContratService contratService)
        {
            this.context = context;
            this._contratService = contratService;

        }

        // GET: api/Souscription
        [HttpGet]
        public ActionResult<IEnumerable<Souscription>> GetSouscriptions()
        {
            return this.context.Souscriptions.ToList();
        }
        [HttpPost("Commander/{offre}/{articleid}")]
        public IActionResult Commander(int offre, int articleid)
        {
            var nouvelleSouscription = new Souscription
            {
                IdStatutSouscription = 1,
                DateSouscription = DateTime.Now,
                DateModification = DateTime.Now,
            };
            context.Souscriptions.Add(nouvelleSouscription);

            context.SaveChanges();
            var offreEngagement = context.OffreEngagements.FirstOrDefault(o => o.IdOffreEngagement == offre);

            if (offreEngagement == null)
            {
                return NotFound("L'offre d'engagement n'a pas été trouvée.");
            }
            var nouvelleLigne = new Ligne
            {
                IdSouscription = nouvelleSouscription.IdSouscription,
                IdOffreEngagement = offreEngagement.IdOffreEngagement,
                PrixVenteOffre = (double)offreEngagement.Prix,
                DatCre = DateTime.Now,
                DatMod = DateTime.Now
            };
            context.Lignes.Add(nouvelleLigne);
            context.SaveChanges();
            var article = context.Articles.FirstOrDefault(a => a.IdArticle == articleid);

            if (article == null)
            {
                return NotFound("L'article n'a pas été trouvé.");
            }

            var nouvelleLigneArticle = new LigneArticle
            {
                IdLigne = nouvelleLigne.IdLigne,
                IdArticle = article.IdArticle,
                PrixPaye = 0,
                TotalSubvention = 0,
                DatCre = DateTime.Now,
                DatMod = DateTime.Now

            };
            context.LigneArticles.Add(nouvelleLigneArticle);
            context.SaveChanges();
            _contratService.sendContrat(nouvelleSouscription,nouvelleLigneArticle,nouvelleLigne);


            return Ok(nouvelleSouscription.IdSouscription);
        }
 
        // GET: api/Souscription/{id}
        [HttpGet("{id}")]
        public ActionResult<Souscription> GetSouscription(int id)
        {
            var souscription = this.context.Souscriptions.Find(id);



            if (souscription == null)
            {
                return NotFound();
            }

            return souscription;
        }


        // DELETE: api/Souscription/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSouscription(int id)
        {
            var souscription = this.context.Souscriptions.Find(id);
            if (souscription == null)
            {
                return NotFound();
            }

            this.context.Souscriptions.Remove(souscription);
            this.context.SaveChanges();

            return Ok();
            ;
        }
        // PUT: api/Souscription/{id}
        [HttpPut("{id}/{idl}")]
        public IActionResult ModifierSouscriptionAvecModeLivraison(int id, int idl)
        {
            var souscription = context.Souscriptions.FirstOrDefault(s => s.IdSouscription == id);

            if (souscription == null)
            {
                return NotFound();

            }

            var modeLivraison = context.ModeLivraisons.FirstOrDefault(ml => ml.IdModeLivraison == idl);

            if (modeLivraison == null)
            {
                return BadRequest("Le mode de livraison spécifié n'existe pas.");
            }

            souscription.IdModeLivraison = modeLivraison.IdModeLivraison;
            souscription.PrixLivraison = modeLivraison.PrixLivraison;

            context.SaveChanges();

            return Ok(souscription);
        }

    }



}