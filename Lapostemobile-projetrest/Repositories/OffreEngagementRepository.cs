using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Lapostemobile_portail.Models;

namespace Lapostemobile_projetrest.Repositories
{
    public class OffreEngagementRepository
    {
        private readonly PortailContext _dbContext;

        public OffreEngagementRepository(PortailContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<OffreEngagement> GetAllOffreEngagements()
        {
            return _dbContext.OffreEngagements.ToList();
        }

        public OffreEngagement GetOffreEngagementById(int id)
        {
            return _dbContext.OffreEngagements.Find(id);
        }

        public void AddOffreEngagement(OffreEngagement offreEngagement)
        {
            _dbContext.OffreEngagements.Add(offreEngagement);
            _dbContext.SaveChanges();
        }

        public void UpdateOffreEngagement(OffreEngagement offreEngagement)
        {
            _dbContext.Entry(offreEngagement).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteOffreEngagement(int id)
        {
            var offreEngagement = _dbContext.OffreEngagements.Find(id);
            if (offreEngagement != null)
            {
                _dbContext.OffreEngagements.Remove(offreEngagement);
                _dbContext.SaveChanges();
            }
        }
    }
}
