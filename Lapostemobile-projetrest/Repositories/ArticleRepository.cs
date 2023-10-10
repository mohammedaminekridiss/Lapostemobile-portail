using Lapostemobile_portail.Models;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Repositories
{
    public class ArticleRepository
    {
        private readonly PortailContext _dbContext;
        public ArticleRepository(PortailContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Article> GetAll()
        {
            return _dbContext.Articles.ToList();
        }
        public Article GetById(int id)
        {
            return _dbContext.Articles.Find(id);
        }

        public void Add(Article Article)
        {
            _dbContext.Articles.Add(Article);
            _dbContext.SaveChanges();
        }

        public void Update(Article Article)
        {
            _dbContext.Entry(Article).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var ArticleToDelete = _dbContext.Articles.Find(id);
            if (ArticleToDelete != null)
            {
                _dbContext.Articles.Remove(ArticleToDelete);
                _dbContext.SaveChanges();
            }
        }

    }
}
