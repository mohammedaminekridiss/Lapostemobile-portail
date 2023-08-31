using Lapostemobile_portail.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
        private readonly PortailContext context;

        public ArticleController(PortailContext context)
        {
            this.context = context;
        }

        // GET: api/Article
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            return this.context.Articles.ToList();
        }

        // GET: api/Article/{id}
        [HttpGet("{id}")]
        public ActionResult<Article> GetArticle(int id)
        {
            var article = this.context.Articles.Find(id);



            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        // POST: api/Article
        [HttpPost]
        public ActionResult<Article> CreateArticle(Article article)
        {
            this.context.Articles.Add(article);
            this.context.SaveChanges();

            return CreatedAtAction(nameof(GetArticle), new { id = article.IdArticle }, article);
        }

        // PUT: api/Article/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateArticle(int id, Article article)
        {
            if (id != article.IdArticle)
            {
                return BadRequest();
            }

            this.context.Entry(article).State = EntityState.Modified;
            this.context.SaveChanges();

            return Ok();
        }

        // DELETE: api/Article/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            var article = this.context.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            this.context.Articles.Remove(article);
            this.context.SaveChanges();

            return Ok();
            ;
        }

    }
}
