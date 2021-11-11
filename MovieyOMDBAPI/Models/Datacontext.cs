using Microsoft.EntityFrameworkCore;

namespace MovieyOMDBAPI.Models
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Movie> Movie { get; set; }
    }
}
