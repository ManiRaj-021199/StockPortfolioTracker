using Microsoft.EntityFrameworkCore;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Data;

public class PortfolioTrackerDbContext : DbContext
{
    #region Properties
    public DbSet<User>? Users { get; set; }
    #endregion

    #region Protecteds
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.DbConnectionString);
    }
    #endregion
}