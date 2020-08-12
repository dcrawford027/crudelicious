using Microsoft.EntityFrameworkCore;

namespace crudelicious.Models
{
    public class CrudeliciousContext : DbContext
    {
        public CrudeliciousContext(DbContextOptions options) : base(options) { }

        public DbSet<Dish> Dishes {get;set;}
    }
}