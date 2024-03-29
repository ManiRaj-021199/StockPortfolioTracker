﻿using System;
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

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<ClientProfile> ClientProfiles { get; set; }

    public virtual DbSet<Holding> Holdings { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<PagesList> PagesLists { get; set; }

    public virtual DbSet<PortfolioCategory> PortfolioCategories { get; set; }

    public virtual DbSet<Recommendation> Recommendations { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Watchlist> Watchlists { get; set; }

    public virtual DbSet<WatchlistCategory> WatchlistCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(ConnectionStrings.DbConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__Branches__A1682FC53BBF6D03");

            entity.ToTable("Branches", "User");

            entity.Property(e => e.BranchName).HasMaxLength(50);
        });

        modelBuilder.Entity<ClientProfile>(entity =>
        {
            entity.HasKey(e => e.ClientProfileId).HasName("PK__ClientPr__08E213792C05F6B3");

            entity.ToTable("ClientProfiles", "Clients");

            entity.Property(e => e.ClientEmail).HasMaxLength(75);
            entity.Property(e => e.ClientName).HasMaxLength(50);

            entity.HasOne(d => d.ClientRole).WithMany(p => p.ClientProfiles)
                .HasForeignKey(d => d.ClientRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClientPro__Clien__6EF57B66");
        });

        modelBuilder.Entity<Holding>(entity =>
        {
            entity.HasKey(e => e.HoldingStockId).HasName("PK__Holdings__E4CDB4E74FD60D30");

            entity.ToTable("Holdings", "Portfolio");

            entity.Property(e => e.Symbol).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Holdings)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Holdings__Catego__19DFD96B");

            entity.HasOne(d => d.User).WithMany(p => p.Holdings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Holdings__UserId__66603565");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Logs__5E5486482F551EC9");

            entity.ToTable("Logs", "SPT");

            entity.Property(e => e.Severity).HasMaxLength(10);

            entity.HasOne(d => d.Page).WithMany(p => p.Logs)
                .HasForeignKey(d => d.PageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Logs__PageId__7E37BEF6");
        });

        modelBuilder.Entity<PagesList>(entity =>
        {
            entity.HasKey(e => e.PageId).HasName("PK__PagesLis__C565B104B703772F");

            entity.ToTable("PagesList", "SPT");

            entity.Property(e => e.PageId).ValueGeneratedNever();
            entity.Property(e => e.PageChildName).HasMaxLength(50);
            entity.Property(e => e.PageRootName).HasMaxLength(50);
        });

        modelBuilder.Entity<PortfolioCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Portfoli__19093A0B475C2CF7");

            entity.ToTable("PortfolioCategory", "Portfolio");

            entity.Property(e => e.CategoryName).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.PortfolioCategories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Portfolio__UserI__17F790F9");
        });

        modelBuilder.Entity<Recommendation>(entity =>
        {
            entity.HasKey(e => e.RecommendationId).HasName("PK__Recommen__AA15BEE4F2F28CB2");

            entity.ToTable("Recommendations", "Stock");

            entity.Property(e => e.Symbol).HasMaxLength(50);

            entity.HasOne(d => d.Branch).WithMany(p => p.Recommendations)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recommend__Branc__04E4BC85");
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

            entity.Property(e => e.BranchId).HasDefaultValueSql("((1))");
            entity.Property(e => e.Email).HasMaxLength(75);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.Branch).WithMany(p => p.Users)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__BranchId__06CD04F7");

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

        modelBuilder.Entity<Watchlist>(entity =>
        {
            entity.HasKey(e => e.WatchlistId).HasName("PK__Watchlis__48DE55CB4053984E");

            entity.ToTable("Watchlist", "Stock");

            entity.Property(e => e.Symbol).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Watchlists)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Watchlist__Categ__2BFE89A6");
        });

        modelBuilder.Entity<WatchlistCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Watchlis__19093A0B7935BD12");

            entity.ToTable("WatchlistCategory", "Stock");

            entity.Property(e => e.CategoryName).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.WatchlistCategories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Watchlist__UserI__29221CFB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
