using System;
using System.Collections.Generic;

namespace StockPortfolioTracker.Data.Entity;

public partial class User
{
    public int UserId { get; set; }

    public int UserRoleId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public DateTime RegisterDate { get; set; }

    public virtual ICollection<Holding> Holdings { get; set; } = new List<Holding>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual UserRole UserRole { get; set; } = null!;

    public virtual ICollection<WatchlistCategory> WatchlistCategories { get; set; } = new List<WatchlistCategory>();
}
