using BlogArticleProject.DBcontext;
using BlogArticleProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogArticleProject.Controllers
{
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleDBContext _context;
        public ArticleController(ArticleDBContext context)
        {
            _context = context;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IEnumerable<Article>> Get()
        {
            return await _context.Articles.ToListAsync();
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public async Task<Article> Get(int id)
        {
            return await _context.Articles.SingleOrDefaultAsync(article => article.Id == id);
        }

        // POST api/<ArticleController>
        [HttpPost]
        public async Task Post([FromBody] Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Article article)
        {
            if(id != article.Id)
            {
                throw new ArgumentException($"Article with {id} doesn't exist");
            }

            _context.Entry(article).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var article = _context.Articles.SingleOrDefault(article => article.Id == id);

            if(article == null)
            {
                throw new ArgumentException($"Article with {id} doesn't exist");
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
        }
    }
}
