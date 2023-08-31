using Lapostemobile_portail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatutSouscriptionController : Controller
    {
        private readonly PortailContext context;

        public StatutSouscriptionController(PortailContext context)
        {
            this.context = context;
        }

        // GET: api/StatutSouscription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatutSouscription>>> GetStatutSouscriptions()
        {
            return this.context.StatutSouscriptions.ToList();
        }

        // GET: api/StatutSouscription/{id}
        [HttpGet("{id}")]
        public ActionResult<StatutSouscription> GetStatutSouscription(int id)
        {
            var statutSouscription = this.context.StatutSouscriptions.Find(id);



            if (statutSouscription == null)
            {
                return NotFound();
            }

            return statutSouscription;
        }

        // POST: api/StatutSouscription
        [HttpPost]
        public ActionResult<StatutSouscription> CreateStatutSouscription(StatutSouscription statutSouscription)
        {
            this.context.StatutSouscriptions.Add(statutSouscription);
            this.context.SaveChanges();

            return CreatedAtAction(nameof(GetStatutSouscription), new { id = statutSouscription.IdStatutSouscription }, statutSouscription);
        }

        // PUT: api/StatutSouscription/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStatutSouscription(int id, StatutSouscription statutSouscription)
        {
            if (id != statutSouscription.IdStatutSouscription)
            {
                return BadRequest();
            }

            this.context.Entry(statutSouscription).State = EntityState.Modified;
            this.context.SaveChanges();

            return Ok();
        }

        // DELETE: api/StatutSouscription/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStatutSouscription(int id)
        {
            var statutSouscription = this.context.StatutSouscriptions.Find(id);
            if (statutSouscription == null)
            {
                return NotFound();
            }

            this.context.StatutSouscriptions.Remove(statutSouscription);
            this.context.SaveChanges();

            return Ok();
            ;
        }

    }
}

