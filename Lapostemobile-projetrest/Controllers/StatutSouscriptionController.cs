using Microsoft.AspNetCore.Mvc;
 using Lapostemobile_portail.Models;
using Lapostemobile_projetrest.Repositories;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatutSouscriptionController : ControllerBase
    {
        private readonly StatutSouscriptionRepository _statutSouscriptionRepository;

        public StatutSouscriptionController(StatutSouscriptionRepository statutSouscriptionRepository)
        {
            _statutSouscriptionRepository = statutSouscriptionRepository;
        }

        // GET: api/StatutSouscription
        [HttpGet]
        public ActionResult<IEnumerable<StatutSouscription>> GetStatutSouscriptions()
        {
            var statutSouscriptions = _statutSouscriptionRepository.GetAllStatutSouscriptions();
            return Ok(statutSouscriptions);
        }

        // GET: api/StatutSouscription/{id}
        [HttpGet("{id}")]
        public ActionResult<StatutSouscription> GetStatutSouscription(int id)
        {
            var statutSouscription = _statutSouscriptionRepository.GetStatutSouscriptionById(id);

            if (statutSouscription == null)
            {
                return NotFound();
            }

            return Ok(statutSouscription);
        }

        // POST: api/StatutSouscription
        [HttpPost]
        public ActionResult<StatutSouscription> CreateStatutSouscription(StatutSouscription statutSouscription)
        {
            _statutSouscriptionRepository.CreateStatutSouscription(statutSouscription);

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

            _statutSouscriptionRepository.UpdateStatutSouscription(statutSouscription);

            return Ok();
        }

        // DELETE: api/StatutSouscription/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStatutSouscription(int id)
        {
            var statutSouscription = _statutSouscriptionRepository.GetStatutSouscriptionById(id);
            if (statutSouscription == null)
            {
                return NotFound();
            }

            _statutSouscriptionRepository.DeleteStatutSouscription(statutSouscription);

            return Ok();
        }
    }
}
