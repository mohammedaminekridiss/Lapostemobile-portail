using Lapostemobile_portail.Models;
using Lapostemobile_projetrest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectController : Controller
    {
        private readonly PortailContext context;
        private readonly MailService _mailService;
        private readonly SAPService _sapService;
        private readonly ContratService _contratService;

        public ProspectController(PortailContext context, MailService mailService, SAPService sAPService, ContratService contratService)
        {
            this.context = context;
            this._mailService = mailService;
            this._sapService = sAPService;
            this._contratService = contratService;

        }
        // GET: api/Prospect/{id}
        [HttpGet("{id}")]
        public ActionResult<Prospect> GetProspect(int id)
        {
            var prospect = this.context.Prospects.Find(id);



            if (prospect == null)
            {
                return NotFound();
            }

            return Ok(prospect);
        }

        // POST: api/Prospect
        [HttpPost("add/{idsouscription}")]
        public ActionResult<Prospect> CreateProspect([FromBody] Prospect prospect, [FromRoute] int idsouscription)
        {
            CoordonneesBancaire c = new CoordonneesBancaire()
            {
                TitulaireCompte = "",
                NomBanque = "",
                Iban = "",
                CodeBic = "",
                DateCreation = null,
                DateModification = null
            };

            this.context.CoordonneesBancaires.Add(c);
            this.context.SaveChanges();
            prospect.IdCoordonneesBancaires = c.IdCoordonnees;


            prospect.IdSouscription = idsouscription;

            this.context.Prospects.Add(prospect);
            this.context.SaveChanges();
            _mailService.sendMail(prospect);
            _sapService.sendSAP();
            _contratService.sendContrat(prospect);

            return CreatedAtAction(nameof(GetProspect), new { id = prospect.IdProspect }, prospect);
        }
       
    }
}