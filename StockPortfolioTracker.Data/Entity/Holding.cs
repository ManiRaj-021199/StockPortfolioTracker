using System;
using System.Collections.Generic;

namespace StockPortfolioTracker.Data.Entity;

public partial class Holding
{
    public int HoldingStockId { get; set; }

    public int UserId { get; set; }

    public string Symbol { get; set; } = null!;

    public int Quantity { get; set; }

    public float BuyPrice { get; set; }

    public DateTime BuyDate { get; set; }

    public int CategoryId { get; set; }

    public virtual PortfolioCategory Category { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
