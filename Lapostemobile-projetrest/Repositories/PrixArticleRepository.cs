using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lapostemobile_portail.Models;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Repositories
{
    public class PrixArticleRepository
    {
        private readonly PortailContext _dbContext;

        public PrixArticleRepository(PortailContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PrixArticle>> GetPrixArticlesByEngagement(int idEngagement)
        {
            return await _dbContext.PrixArticles
                .Where(pa => pa.IdOffreEngagement == idEngagement)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrixArticle>> GetPrixArticlesByIdOffreAndArticle(int idOffre, int idArticle)
        {
            return await _dbContext.PrixArticles
                .Where(pa => pa.IdOffreEngagement == idOffre && pa.IdArticle == idArticle)
                .ToListAsync();
        }

        public async Task<bool> DeletePrixArticle(int id)
        {
            var prixArticle = await _dbContext.PrixArticles.FindAsync(id);
            if (prixArticle == null)
            {
                return false;
            }

            _dbContext.PrixArticles.Remove(prixArticle);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
