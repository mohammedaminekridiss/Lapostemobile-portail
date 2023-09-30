using Lapostemobile_portail.Models;
using Lapostemobile_projetrest.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lapostemobile_projetrest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : Controller
    {
         
        private readonly ArticleRepository _articleRepository;

        public ArticleController( ArticleRepository articleRepository)
        {
             this._articleRepository = articleRepository;
        }

        // GET: api/Article
        [HttpGet]
        public ActionResult<IEnumerable<Article>> GetArticles()
        {
            return Ok(_articleRepository.GetAll());
        }

        // GET: api/Article/{id}
        [HttpGet("{id}")]
        public ActionResult<Article> GetArticle(int id)
        {
            var article = _articleRepository.GetById(id);

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
            _articleRepository.Add(article);

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

            _articleRepository.Update(article);

            return Ok();
        }

        // DELETE: api/Article/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            var article = _articleRepository.GetById(id);
            if (article == null)
            {
                return NotFound();
            }

            _articleRepository.Delete(id);

            return Ok();
            ;
        }

    }
}
