using Lapostemobile_portail.Models;
using Lapostemobile_projetrest.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OffreEngagementController : ControllerBase
{
    private readonly OffreEngagementRepository _offreEngagementRepository;

    public OffreEngagementController(OffreEngagementRepository offreEngagementRepository)
    {
        _offreEngagementRepository = offreEngagementRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<OffreEngagement>> GetOffreEngagements()
    {
        var offreEngagements = _offreEngagementRepository.GetAllOffreEngagements();
        return Ok(offreEngagements);
    }

    [HttpGet("{id}")]
    public ActionResult<OffreEngagement> GetOffreEngagement(int id)
    {
        var offreEngagement = _offreEngagementRepository.GetOffreEngagementById(id);
        if (offreEngagement == null)
        {
            return NotFound();
        }

        return Ok(offreEngagement);
    }

    [HttpPost]
    public ActionResult<OffreEngagement> CreateOffreEngagement(OffreEngagement offreEngagement)
    {
        _offreEngagementRepository.AddOffreEngagement(offreEngagement);
        return CreatedAtAction(nameof(GetOffreEngagement), new { id = offreEngagement.IdOffreEngagement }, offreEngagement);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOffreEngagement(int id, OffreEngagement offreEngagement)
    {
        if (id != offreEngagement.IdOffreEngagement)
        {
            return BadRequest();
        }

        _offreEngagementRepository.UpdateOffreEngagement(offreEngagement);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOffreEngagement(int id)
    {
        _offreEngagementRepository.DeleteOffreEngagement(id);
        return Ok();
    }
}
