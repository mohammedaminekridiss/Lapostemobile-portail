using Lapostemobile_portail.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lapostemobile_projetrest.Repositories
{
    public class ProspectRepository
    {
        private readonly PortailContext _dbContext;

        public ProspectRepository(PortailContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Prospect GetProspectById(int id)
        {
            return _dbContext.Prospects.Find(id);
 
        }

        public void AddProspect(Prospect prospect)
        {
            _dbContext.Prospects.Add(prospect);
            _dbContext.SaveChanges();
        }

     }
}
