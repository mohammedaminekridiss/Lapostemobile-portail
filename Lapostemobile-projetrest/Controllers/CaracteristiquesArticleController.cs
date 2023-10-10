using Lapostemobile_portail.Models;
using Lapostemobile_projetrest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaracteristiquesArticleController : ControllerBase
    {
        private readonly CaracteristiquesArticleRepository _caracteristiquesArticleRepository;

        public CaracteristiquesArticleController(CaracteristiquesArticleRepository caracteristiquesArticleRepository)
        {
            _caracteristiquesArticleRepository = caracteristiquesArticleRepository;
        }


         [HttpGet]
        public ActionResult<IEnumerable<CaracteristiquesArticle>> GetCaracteristiquesArticles()
        {
            var caracteristiquesArticles = _caracteristiquesArticleRepository.GetAll();
            return Ok(caracteristiquesArticles);
        }


        [HttpGet("{idArticle}")]
        public ActionResult<IEnumerable<CaracteristiquesArticle>> GetCaracteristiquesByArticleId(int idArticle)
        {
            var caracteristiquesarticle = _caracteristiquesArticleRepository.GetByArticleId(idArticle);

            if (caracteristiquesarticle == null)
            {
                return NotFound();
            }

            return caracteristiquesarticle.ToList();
        }


         [HttpPost]
        public ActionResult<CaracteristiquesArticle> CreateCaracteristiquesArticle(CaracteristiquesArticle caracteristiquesarticle)
        {
            _caracteristiquesArticleRepository.Add(caracteristiquesarticle);

            return CreatedAtAction(nameof(GetCaracteristiquesArticles), new { id = caracteristiquesarticle.IdCaracteristiquesArticles }, caracteristiquesarticle);
        }

         [HttpPut("{id}")]
        public IActionResult UpdateCaracteristiquesArticle(int id, CaracteristiquesArticle caracteristiquesarticle)
        {
            if (id != caracteristiquesarticle.IdCaracteristiquesArticles)
            {
                return BadRequest();
            }

            _caracteristiquesArticleRepository.Update(caracteristiquesarticle);

            return Ok();
        }

         [HttpDelete("{id}")]
        public IActionResult DeleteCaracteristiquesArticle(int idArticle)
        {
            var caracteristiquesarticle = _caracteristiquesArticleRepository.GetByArticleId(idArticle);
            if (caracteristiquesarticle == null)
            {
                return NotFound();
            }
            _caracteristiquesArticleRepository.Delete(idArticle);

            return Ok();
         
        }
    }
}
