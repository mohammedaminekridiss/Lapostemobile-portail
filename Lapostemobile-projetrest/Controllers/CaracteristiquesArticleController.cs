using Lapostemobile_portail.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lapostemobile_projetrest.Repositories;

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


        // GET: api/CaracteristiquesArticle
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


        // POST: api/CaracteristiquesArticle
        [HttpPost]
        public ActionResult<CaracteristiquesArticle> CreateCaracteristiquesArticle(CaracteristiquesArticle caracteristiquesarticle)
        {
            _caracteristiquesArticleRepository.Add(caracteristiquesarticle);

            return CreatedAtAction(nameof(GetCaracteristiquesArticles), new { id = caracteristiquesarticle.IdCaracteristiquesArticles }, caracteristiquesarticle);
        }

        // PUT: api/CaracteristiquesArticle/{id}
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

        // DELETE: api/CaracteristiquesArticle/{id}
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
            ;
        }
    }
}
