using Lapostemobile_portail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordonnesBancaireController : Controller
    {
        private readonly PortailContext context;

        public CoordonnesBancaireController(PortailContext context)
        {
            this.context = context;
        }

        // GET: api/CoordonnesBancaire
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoordonneesBancaire>>> GetCoordonnesBancaires()
        {
            return this.context.CoordonneesBancaires.ToList();
        }

        // GET: api/CoordonnesBancaire/{id}
        [HttpGet("{id}")]
        public ActionResult<CoordonneesBancaire> GetCoordonnesBancaire(int id)
        {
            var coordonneesBancaire = this.context.CoordonneesBancaires.Find(id);



            if (coordonneesBancaire == null)
            {
                return NotFound();
            }

            return coordonneesBancaire;
        }

        // POST: api/CoordonneesBancaire
        [HttpPost]
        public ActionResult<CoordonneesBancaire> CreateCoordonneesBancaire(CoordonneesBancaire coordonneesBancaire)
        {
            this.context.CoordonneesBancaires.Add(coordonneesBancaire);
            this.context.SaveChanges();

            return CreatedAtAction(nameof(GetCoordonnesBancaire), new { id = coordonneesBancaire.IdCoordonnees }, coordonneesBancaire);
        }

        // PUT: api/CoordonneesBancaire/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCoordonneesBancaire(int id, CoordonneesBancaire coordonneesBancaire)
        {
            if (id != coordonneesBancaire.IdCoordonnees)
            {
                return BadRequest();
            }

            this.context.Entry(coordonneesBancaire).State = EntityState.Modified;
            this.context.SaveChanges();

            return Ok();
        }

        // DELETE: api/CoordonneesBancaire/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCoordonneesBancaire(int id)
        {
            var coordonneesBancaire = this.context.CoordonneesBancaires.Find(id);
            if (coordonneesBancaire == null)
            {
                return NotFound();
            }

            this.context.CoordonneesBancaires.Remove(coordonneesBancaire);
            this.context.SaveChanges();

            return Ok();
            ;
        }

    }
}

