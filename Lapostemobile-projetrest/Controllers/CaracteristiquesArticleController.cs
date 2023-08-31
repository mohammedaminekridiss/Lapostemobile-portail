using Lapostemobile_portail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaracteristiquesArticleController : Controller
    {
        private readonly PortailContext context;

        public CaracteristiquesArticleController(PortailContext context)
        {
            this.context = context;
        }

        // GET: api/CaracteristiquesArticle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaracteristiquesArticle>>> GetCaracteristiquesArticles()
        {
            return this.context.CaracteristiquesArticles.ToList();
        }

       
        [HttpGet("{idArticle}")]
        public ActionResult<IEnumerable<CaracteristiquesArticle>> GetCaracteristiquesByArticleId(int idArticle)
        {
            var caracteristiquesArticles = this.context.CaracteristiquesArticles.Where(c => c.IdArticle == idArticle).ToList();

            if (caracteristiquesArticles == null || caracteristiquesArticles.Count == 0)
            {
                return NotFound();
            }

            return caracteristiquesArticles; 
        }


        // POST: api/CaracteristiquesArticle
        [HttpPost]
        public ActionResult<CaracteristiquesArticle> CreateCaracteristiquesArticle(CaracteristiquesArticle caracteristiquesarticle)
        {
            this.context.CaracteristiquesArticles.Add(caracteristiquesarticle);
            this.context.SaveChanges();

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

            this.context.Entry(caracteristiquesarticle).State = EntityState.Modified;
            this.context.SaveChanges();

            return Ok();
        }

        // DELETE: api/CaracteristiquesArticle/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCaracteristiquesArticle(int id)
        {
            var caracteristiquesarticle = this.context.CaracteristiquesArticles.Find(id);
            if (caracteristiquesarticle == null)
            {
                return NotFound();
            }

            this.context.CaracteristiquesArticles.Remove(caracteristiquesarticle);
            this.context.SaveChanges();

            return Ok();
            ;
        }
    }
}
