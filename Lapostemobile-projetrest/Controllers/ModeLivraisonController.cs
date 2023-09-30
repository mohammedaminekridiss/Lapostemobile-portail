using Lapostemobile_portail.Models;
using Lapostemobile_projetrest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeLivraisonController : ControllerBase
    {
        private readonly ModeLivraisonRepository _modeLivraisonRepository;

        public ModeLivraisonController(ModeLivraisonRepository modeLivraisonRepository)
        {
            _modeLivraisonRepository = modeLivraisonRepository;
        }

        // GET: api/ModeLivraison
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeLivraison>>> GetModeLivraisons()
        {
            try
            {
                var modeLivraisons = await _modeLivraisonRepository.GetModeLivraisonsAsync();
                return Ok(modeLivraisons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Une erreur interne s'est produite : {ex.Message}");
            }
        }
    }
}
