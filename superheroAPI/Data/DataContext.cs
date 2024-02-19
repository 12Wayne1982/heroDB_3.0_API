using Microsoft.EntityFrameworkCore;

namespace superheroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        // SuperHeroes = Name of Table
        public DbSet<SuperHero> SuperHeroes => Set<SuperHero>();    
    }
}
