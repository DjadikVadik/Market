using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Market.Data;


public class ContextFactory : IDesignTimeDbContextFactory<MarketContext>
{
    MarketContext IDesignTimeDbContextFactory<MarketContext>.CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath($"{Directory.GetCurrentDirectory()}/../Market")
            .AddJsonFile($"appsettings.Development.json")
            .Build();

        var builder = new DbContextOptionsBuilder<MarketContext>();
        var connectionString = configuration.GetConnectionString("MyDatabase");

        builder.UseSqlServer(connectionString);

        return new MarketContext(builder.Options);
    }
}

