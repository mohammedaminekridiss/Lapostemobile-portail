using Lapostemobile_portail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresseController : Controller
    {
        private readonly PortailContext context;

        public AdresseController(PortailContext context)
        {
            this.context = context;
        }

        // GET: api/Adresse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAdresse()
        {
            return this.context.Adresses.ToList();
        }

        // GET: api/Adresse/{id}
        [HttpGet("{id}")]
        public ActionResult<Adresse> GetAdresse(int id)
        {
            var adresse = this.context.Adresses.Find(id);



            if (adresse == null)
            {
                return NotFound();
            }

            return adresse;
        }

        // POST: api/Adresse
        [HttpPost]
        public ActionResult<Adresse> CreateAdresse(Adresse adresse)
        {
            this.context.Adresses.Add(adresse);
            this.context.SaveChanges();

            return CreatedAtAction(nameof(GetAdresse), new { id = adresse.IdAdresse }, adresse);
        }

        // PUT: api/Adresse/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAdresse(int id, Adresse adresse)
        {
            if (id != adresse.IdAdresse)
            {
                return BadRequest();
            }

            this.context.Entry(adresse).State = EntityState.Modified;
            this.context.SaveChanges();

            return Ok();
        }

        // DELETE: api/Adresse/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAdresse(int id)
        {
            var adresse = this.context.Adresses.Find(id);
            if (adresse == null)
            {
                return NotFound();
            }

            this.context.Adresses.Remove(adresse);
            this.context.SaveChanges();

            return Ok();
            ;
        }
    }
}
