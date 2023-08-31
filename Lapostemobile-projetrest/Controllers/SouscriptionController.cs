using Lapostemobile_portail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SouscriptionController : Controller
    {
        private readonly PortailContext context;

        public SouscriptionController(PortailContext context)
        {
            this.context = context;
        }

        // GET: api/Souscription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Souscription>>> GetSouscriptions()
        {
            return this.context.Souscriptions.ToList();
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

        // POST: api/Souscription
        [HttpPost]
        public ActionResult<Souscription> CreateSouscription(Souscription souscription)
        {
            this.context.Souscriptions.Add(souscription);
            this.context.SaveChanges();

            return CreatedAtAction(nameof(GetSouscription), new { id = souscription.IdSouscription }, souscription);
        }

        // PUT: api/Souscription/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSouscription(int id, Souscription souscription)
        {
            if (id != souscription.IdSouscription)
            {
                return BadRequest();
            }

            this.context.Entry(souscription).State = EntityState.Modified;
            this.context.SaveChanges();

            return Ok();
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

    }
}

