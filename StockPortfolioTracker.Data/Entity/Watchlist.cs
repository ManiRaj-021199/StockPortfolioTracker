using System;
using System.Collections.Generic;

namespace StockPortfolioTracker.Data.Entity;

public partial class Watchlist
{
    public int WatchlistId { get; set; }

    public int CategoryId { get; set; }

    public string Symbol { get; set; } = null!;

    public virtual WatchlistCategory Category { get; set; } = null!;
}
