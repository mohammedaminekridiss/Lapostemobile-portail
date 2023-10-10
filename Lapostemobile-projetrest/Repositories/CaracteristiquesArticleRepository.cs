using Lapostemobile_portail.Models;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Repositories
{
    public class CaracteristiquesArticleRepository
    {
        private readonly PortailContext _context;

        public CaracteristiquesArticleRepository(PortailContext context)
        {
            _context = context;
        }
        public IEnumerable<CaracteristiquesArticle> GetAll()
        {
            return _context.CaracteristiquesArticles.ToList();
        }
        public IEnumerable<CaracteristiquesArticle> GetByArticleId(int idArticle)
        {
            return _context.CaracteristiquesArticles.Where(ca => ca.IdArticle == idArticle).ToList();
        }

        public void Add(CaracteristiquesArticle caracteristiquesArticle)
        {
            _context.CaracteristiquesArticles.Add(caracteristiquesArticle);
            _context.SaveChanges();
        }

        public void Update(CaracteristiquesArticle caracteristiquesArticle)
        {
            _context.Entry(caracteristiquesArticle).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var caracteristiquesArticle = _context.CaracteristiquesArticles.Find(id);
            if (caracteristiquesArticle == null)
            {
                return false;  
            }

            _context.CaracteristiquesArticles.Remove(caracteristiquesArticle);
            _context.SaveChanges();
            return true;  
        }
    }
}
