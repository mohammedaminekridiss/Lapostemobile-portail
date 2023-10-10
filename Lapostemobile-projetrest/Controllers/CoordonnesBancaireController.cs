using Lapostemobile_portail.Models;
using Lapostemobile_projetrest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordonnesBancaireController : ControllerBase
    {
        private readonly CoordonneesBancaireRepository _coordonneesBancaireRepository;

        public CoordonnesBancaireController(CoordonneesBancaireRepository coordonneesBancaireRepository)
        {
            _coordonneesBancaireRepository = coordonneesBancaireRepository;
        }

         [HttpGet]
        public ActionResult<IEnumerable<CoordonneesBancaire>> GetCoordonnesBancaires()
        {
            var coordonnees = _coordonneesBancaireRepository.GetAllCoordonneesBancaires();
            return Ok(coordonnees);
        }

         [HttpGet("{id}")]
        public ActionResult<CoordonneesBancaire> GetCoordonneesBancaire(int id)
        {
            var coordonneesBancaire = _coordonneesBancaireRepository.GetCoordonneesBancaireById(id);
            if (coordonneesBancaire == null)
            {
                return NotFound();
            }
            return Ok(coordonneesBancaire);
        }

         [HttpPost]
        public IActionResult CreateCoordonneesBancaire(CoordonneesBancaire coordonneesBancaire)
        {
            _coordonneesBancaireRepository.AddCoordonneesBancaire(coordonneesBancaire);
            _coordonneesBancaireRepository.SaveChanges();

            return CreatedAtAction(nameof(GetCoordonneesBancaire), new { id = coordonneesBancaire.IdCoordonnees }, coordonneesBancaire);
        }

         [HttpPut("{id}")]
        public IActionResult UpdateCoordonneesBancaire(int id, CoordonneesBancaire coordonneesBancaire)
        {
            if (id != coordonneesBancaire.IdCoordonnees)
            {
                return BadRequest();
            }

            _coordonneesBancaireRepository.UpdateCoordonneesBancaire(coordonneesBancaire);
            _coordonneesBancaireRepository.SaveChanges();

            return Ok();
        }

         [HttpDelete("{id}")]
        public IActionResult DeleteCoordonneesBancaire(int id)
        {
            _coordonneesBancaireRepository.DeleteCoordonneesBancaire(id);
            _coordonneesBancaireRepository.SaveChanges();

            return Ok(); }
    } }
