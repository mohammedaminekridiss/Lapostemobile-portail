using Lapostemobile_portail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrixArticleController : Controller
    {

        private readonly PortailContext context;

        public PrixArticleController(PortailContext context)
        {
            this.context = context;
        }

        [HttpGet("{idEngagement}")]
        public async Task<ActionResult<IEnumerable<PrixArticle>>> GetPrixArticles(int idEngagement)
        {
            // Utilisez l'ID de l'engagement pour filtrer les PrixArticles
            var prixArticles = await this.context.PrixArticles
                .Where(pa => pa.IdOffreEngagement == idEngagement)
                .ToListAsync();

            return prixArticles;
        }
        [HttpGet("GetPrixArticlesByIdOffreAndArticle/{idOffre}/{idArticle}")]
        public async Task<ActionResult<IEnumerable<PrixArticle>>> GetPrixArticlesByIdOffreAndArticle(int idOffre, int idArticle)
        {
            try
            {
                // Utilisez l'ID de l'offre et l'ID de l'article pour filtrer les PrixArticles
                var prixArticles = await this.context.PrixArticles
                    .Where(pa => pa.IdOffreEngagement == idOffre && pa.IdArticle == idArticle)
                    .ToListAsync();

                if (prixArticles == null || prixArticles.Count == 0)
                {
                    return NotFound(); // Renvoyer une réponse NotFound si aucun prix d'article n'est trouvé
                }

                return Ok(prixArticles); // Renvoyer les prix d'articles trouvés en réponse
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur interne du serveur s'est produite : {ex.Message}");
            }
        }






        // DELETE: api/PrixArticle/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePrixArticle(int id)
        {
            var prixarticle = this.context.PrixArticles.Find(id);
            if (prixarticle == null)
            {
                return NotFound();
            }

            this.context.PrixArticles.Remove(prixarticle);
            this.context.SaveChanges();

            return Ok();
            ;
        }

    }
}

