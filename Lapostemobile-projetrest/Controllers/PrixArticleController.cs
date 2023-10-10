using Lapostemobile_portail.Models;
using Lapostemobile_projetrest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrixArticleController : ControllerBase
    {
        private readonly PrixArticleRepository _prixArticleRepository;

        public PrixArticleController(PrixArticleRepository prixArticleRepository)
        {
            _prixArticleRepository = prixArticleRepository;
        }

        [HttpGet("{idEngagement}")]
        public async Task<ActionResult<IEnumerable<PrixArticle>>> GetPrixArticles(int idEngagement)
        {
            var prixArticles = await _prixArticleRepository.GetPrixArticlesByEngagement(idEngagement);
            return Ok(prixArticles);
        }

        [HttpGet("GetPrixArticlesByIdOffreAndArticle/{idOffre}/{idArticle}")]
        public async Task<ActionResult<IEnumerable<PrixArticle>>> GetPrixArticlesByIdOffreAndArticle(int idOffre, int idArticle)
        {
            var prixArticles = await _prixArticleRepository.GetPrixArticlesByIdOffreAndArticle(idOffre, idArticle);

            if (prixArticles == null || !prixArticles.Any())
            {
                return NotFound();
            }

            return Ok(prixArticles);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrixArticle(int id)
        {
            var success = await _prixArticleRepository.DeletePrixArticle(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
