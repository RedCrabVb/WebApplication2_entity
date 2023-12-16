using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CSharpCornerArticle> Articles { get; set; }
    }
}
