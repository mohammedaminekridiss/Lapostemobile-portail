using Lapostemobile_portail.Models;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Repositories
{
    public class ModeLivraisonRepository
    {
        private readonly PortailContext _dbContext;

        public ModeLivraisonRepository(PortailContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ModeLivraison>> GetModeLivraisonsAsync()
        {
            return await _dbContext.ModeLivraisons.ToListAsync();
        }
    }
}
