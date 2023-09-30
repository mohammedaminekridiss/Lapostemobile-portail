using Lapostemobile_portail.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lapostemobile_projetrest.Repositories
{
    public class StatutSouscriptionRepository
    {
        private readonly PortailContext _dbContext;

        public StatutSouscriptionRepository(PortailContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<StatutSouscription> GetAllStatutSouscriptions()
        {
            return _dbContext.StatutSouscriptions.ToList();
        }

        public StatutSouscription GetStatutSouscriptionById(int id)
        {
            return _dbContext.StatutSouscriptions.Find(id);
        }

        public void CreateStatutSouscription(StatutSouscription statutSouscription)
        {
            if (statutSouscription == null)
            {
                throw new ArgumentNullException(nameof(statutSouscription));
            }

            _dbContext.StatutSouscriptions.Add(statutSouscription);
            _dbContext.SaveChanges();
        }

        public void UpdateStatutSouscription(StatutSouscription statutSouscription)
        {
            if (statutSouscription == null)
            {
                throw new ArgumentNullException(nameof(statutSouscription));
            }

            _dbContext.Entry(statutSouscription).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteStatutSouscription(StatutSouscription statutSouscription)
        {
            if (statutSouscription == null)
            {
                throw new ArgumentNullException(nameof(statutSouscription));
            }

            _dbContext.StatutSouscriptions.Remove(statutSouscription);
            _dbContext.SaveChanges();
        }
    }
}
