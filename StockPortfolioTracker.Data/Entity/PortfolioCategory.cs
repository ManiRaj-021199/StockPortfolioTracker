using System;
using System.Collections.Generic;

namespace StockPortfolioTracker.Data.Entity;

public partial class PortfolioCategory
{
    public int CategoryId { get; set; }

    public int UserId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Holding> Holdings { get; set; } = new List<Holding>();

    public virtual User User { get; set; } = null!;
}
