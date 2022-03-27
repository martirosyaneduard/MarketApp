using Microsoft.EntityFrameworkCore;

namespace MarketApp.Models
{
    public class MarketDbContext:DbContext
    {
        public DbSet<Product>? Products { get; set; }

        public MarketDbContext(DbContextOptions<MarketDbContext> options):base(options)
        {

        }
    }
}
