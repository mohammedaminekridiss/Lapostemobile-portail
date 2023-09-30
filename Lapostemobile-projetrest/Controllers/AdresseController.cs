using Lapostemobile_portail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lapostemobile_projetrest.Repositories;

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

        // GET: api/Adresse
        [HttpGet]
        public ActionResult<IEnumerable<Adresse>> GetAdresse()
        {
            var adresses = _adresseRepository.GetAll();
            return Ok(adresses);
        }

        // GET: api/Adresse/{id}
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

        // POST: api/Adresse
        [HttpPost]
        public ActionResult<Adresse> CreateAdresse(Adresse adresse)
        {
            _adresseRepository.Add(adresse);

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

            _adresseRepository.Update(adresse);

            return Ok();
        }

        // DELETE: api/Adresse/{id}
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
