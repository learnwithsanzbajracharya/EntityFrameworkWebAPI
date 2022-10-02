using BlogArticleProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogArticleProject.DBcontext
{
    public class ArticleDBContext : DbContext
    {
        public ArticleDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
