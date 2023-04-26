using Microsoft.EntityFrameworkCore;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Data;

public class PortfolioTrackerDbContext : DbContext
{
    #region Properties
    public DbSet<User>? Users { get; set; }
    public DbSet<UserRole>? UserRoles { get; set; }
    public DbSet<PortfolioStock>? PortfolioStocks { get; set; }
    public DbSet<PortfolioTransaction>? PortfolioTransactions { get; set; }
    #endregion

    #region Protecteds
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.DbConnectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users", schema: "user");
        modelBuilder.Entity<UserRole>().ToTable("UserRoles", schema: "user");

        modelBuilder.Entity<PortfolioStock>().ToTable("PortfolioStocks", schema: "stock");
        modelBuilder.Entity<PortfolioTransaction>().ToTable("PortfolioTransactions", schema: "stock");

        base.OnModelCreating(modelBuilder);
    }
    #endregion
}