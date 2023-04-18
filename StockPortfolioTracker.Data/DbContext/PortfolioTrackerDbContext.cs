using Microsoft.EntityFrameworkCore;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Data;

public class PortfolioTrackerDbContext : DbContext
{
    #region Properties
    public DbSet<Users>? Users { get; set; }
    #endregion

    #region Protecteds
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Server={EntityValues.Server};Database={EntityValues.InitialCatelog};Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;");
    }
    #endregion
}