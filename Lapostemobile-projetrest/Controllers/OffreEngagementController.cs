using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lapostemobile_portail.Models;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffreEngagementController : ControllerBase
    {
        private readonly PortailContext context;

        public OffreEngagementController(PortailContext context)
        {
            this.context = context;
        }

        // GET: api/OffreEngagement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OffreEngagement>>> GetOffreEngagements()
        {
            return this.context.OffreEngagements.ToList();
        }

        // GET: api/OffreEngagement/{id}
        [HttpGet("{id}")]
        public ActionResult<OffreEngagement> GetOffreEngagement(int id)
        {
            var offreEngagement = this.context.OffreEngagements.Find(id);



            if (offreEngagement == null)
            {
                return NotFound();
            }

            return offreEngagement;
        }

        // POST: api/OffreEngagement
        [HttpPost]
        public ActionResult<OffreEngagement> CreateOffreEngagement(OffreEngagement offreEngagement)
        {
            this.context.OffreEngagements.Add(offreEngagement);
            this.context.SaveChanges();

            return CreatedAtAction(nameof(GetOffreEngagement), new { id = offreEngagement.IdOffreEngagement }, offreEngagement);
        }

        // PUT: api/OffreEngagement/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateOffreEngagement(int id, OffreEngagement offreEngagement)
        {
            if (id != offreEngagement.IdOffreEngagement)
            {
                return BadRequest();
            }

            this.context.Entry(offreEngagement).State = EntityState.Modified;
            this.context.SaveChanges();

            return Ok();
        }

        // DELETE: api/OffreEngagement/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteOffreEngagement(int id)
        {
            var offreEngagement = this.context.OffreEngagements.Find(id);
            if (offreEngagement == null)
            {
                return NotFound();
            }

            this.context.OffreEngagements.Remove(offreEngagement);
            this.context.SaveChanges();

            return Ok();
            ;
        }

    }
}
