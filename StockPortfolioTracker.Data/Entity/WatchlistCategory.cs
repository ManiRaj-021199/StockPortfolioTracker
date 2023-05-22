using System;
using System.Collections.Generic;

namespace StockPortfolioTracker.Data.Entity;

public partial class WatchlistCategory
{
    public int CategoryId { get; set; }

    public int UserId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Watchlist> Watchlists { get; set; } = new List<Watchlist>();
}
