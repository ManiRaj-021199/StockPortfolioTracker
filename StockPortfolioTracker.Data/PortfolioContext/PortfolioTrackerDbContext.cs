using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StockPortfolioTracker.Data.Entity;

namespace StockPortfolioTracker.Data.PortfolioContext;

public partial class PortfolioTrackerDbContext : DbContext
{
    public PortfolioTrackerDbContext()
    {
    }

    public PortfolioTrackerDbContext(DbContextOptions<PortfolioTrackerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Holding> Holdings { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(ConnectionStrings.DbConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Holding>(entity =>
        {
            entity.HasKey(e => e.HoldingStockId).HasName("PK__Holdings__E4CDB4E74FD60D30");

            entity.ToTable("Holdings", "Portfolio");

            entity.Property(e => e.Symbol).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Holdings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Holdings__UserId__66603565");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A6BB596E72A");

            entity.ToTable("Transactions", "Portfolio");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__UserI__693CA210");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C37155F01");

            entity.ToTable("Users", "User");

            entity.Property(e => e.Email).HasMaxLength(75);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__UserRoleI__6383C8BA");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A35D80C4A90");

            entity.ToTable("UserRoles", "User");

            entity.Property(e => e.UserRoleId).ValueGeneratedNever();
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
