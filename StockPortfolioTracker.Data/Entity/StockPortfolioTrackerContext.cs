using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StockPortfolioTracker.Data.Entity;

public partial class StockPortfolioTrackerContext : DbContext
{
    public StockPortfolioTrackerContext()
    {
    }

    public StockPortfolioTrackerContext(DbContextOptions<StockPortfolioTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SptUser> SptUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        // => optionsBuilder.UseSqlServer("Server=MS-NB0101;Database=StockPortfolioTracker;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SptUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(25);
            entity.Property(e => e.LastName).HasMaxLength(25);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
