using Lapostemobile_portail.Models;
 

namespace Lapostemobile_projetrest.Repositories
{
    public class SouscriptionRepository
    {
        private readonly PortailContext _dbContext;

        public SouscriptionRepository(PortailContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
