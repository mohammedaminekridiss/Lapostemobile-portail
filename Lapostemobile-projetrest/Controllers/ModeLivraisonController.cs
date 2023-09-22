using Lapostemobile_portail.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeLivraisonController : Controller
    {
        private readonly PortailContext context;

        public ModeLivraisonController(PortailContext context)
        {
            this.context = context;
        }
        // GET: api/Livraison
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeLivraison>>> Getmode()
        {
            return this.context.ModeLivraisons.ToList();

        }



    }
}
