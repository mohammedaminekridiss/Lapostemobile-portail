﻿using Lapostemobile_portail.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectController : Controller
    {
        private readonly PortailContext context;

        public ProspectController(PortailContext context)
        {
            this.context = context;
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

            return CreatedAtAction(nameof(GetProspect), new { id = prospect.IdProspect }, prospect);
        }
    }
}