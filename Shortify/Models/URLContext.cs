using Microsoft.EntityFrameworkCore;
namespace Shortify.Models
{
    public class URLContext : DbContext
    {
        public URLContext(DbContextOptions<URLContext> options) : base(options)
        {
        }
        public DbSet<URL> URLs { get; set; }

    }
}