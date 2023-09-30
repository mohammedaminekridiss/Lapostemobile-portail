using Lapostemobile_portail.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lapostemobile_projetrest.Repositories
{
    public class CoordonneesBancaireRepository
    {
        private readonly PortailContext _dbContext;

        public CoordonneesBancaireRepository(PortailContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CoordonneesBancaire> GetAllCoordonneesBancaires()
        {
            return _dbContext.CoordonneesBancaires.ToList();
        }

        public CoordonneesBancaire GetCoordonneesBancaireById(int id)
        {
            return _dbContext.CoordonneesBancaires.Find(id);
        }

        public void AddCoordonneesBancaire(CoordonneesBancaire coordonneesBancaire)
        {
            _dbContext.CoordonneesBancaires.Add(coordonneesBancaire);
        }

        public void UpdateCoordonneesBancaire(CoordonneesBancaire coordonneesBancaire)
        {
            _dbContext.Entry(coordonneesBancaire).State = EntityState.Modified;
        }

        public void DeleteCoordonneesBancaire(int id)
        {
            var coordonneesBancaire = _dbContext.CoordonneesBancaires.Find(id);
            if (coordonneesBancaire != null)
            {
                _dbContext.CoordonneesBancaires.Remove(coordonneesBancaire);
            }
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
