using Lapostemobile_portail.Models;
using Lapostemobile_projetrest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresseController : Controller
    {
        private readonly AdresseRepository _adresseRepository;

        public AdresseController(AdresseRepository adresseRepository)
        {
            _adresseRepository = adresseRepository;
        }

         [HttpGet]
        public ActionResult<IEnumerable<Adresse>> GetAdresse()
        {
            var adresses = _adresseRepository.GetAll();
            return Ok(adresses);
        }

         [HttpGet("{id}")]
        public ActionResult<Adresse> GetAdresse(int id)
        {
            var adresse = _adresseRepository.GetById(id);

            if (adresse == null)
            {
                return NotFound();
            }

            return adresse;
        }

         [HttpPost]
        public ActionResult<Adresse> CreateAdresse(Adresse adresse)
        {
            _adresseRepository.Add(adresse);

            return CreatedAtAction(nameof(GetAdresse), new { id = adresse.IdAdresse }, adresse);
        }

         [HttpPut("{id}")]
        public IActionResult UpdateAdresse(int id, Adresse adresse)
        {
            if (id != adresse.IdAdresse)
            {
                return BadRequest();
            }

            _adresseRepository.Update(adresse);

            return Ok();
        }

         [HttpDelete("{id}")]
        public IActionResult DeleteAdresse(int id)
        {
            var adresse = _adresseRepository.GetById(id);
            if (adresse == null)
            {
                return NotFound();
            }

            _adresseRepository.Delete(id);

            return Ok();

        }
    }
}
