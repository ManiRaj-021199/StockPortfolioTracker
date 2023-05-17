using System;
using System.Collections.Generic;

namespace StockPortfolioTracker.Data.Entity;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int UserId { get; set; }

    public string Symbol { get; set; } = null!;

    public int Quantity { get; set; }

    public double BuyPrice { get; set; }

    public double SellPrice { get; set; }

    public DateTime SellDate { get; set; }

    public virtual User User { get; set; } = null!;
}
