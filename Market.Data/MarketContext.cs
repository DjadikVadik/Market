using Market.Data.Configurations;
using Market.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Data
{
    public class MarketContext : DbContext
    {
        public MarketContext(DbContextOptions<MarketContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            //new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        }
    }
}
