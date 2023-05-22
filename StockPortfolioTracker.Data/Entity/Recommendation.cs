using System;
using System.Collections.Generic;

namespace StockPortfolioTracker.Data.Entity;

public partial class Recommendation
{
    public int RecommendationId { get; set; }

    public int BranchId { get; set; }

    public string Symbol { get; set; } = null!;

    public int RecommendedBuyPrice { get; set; }

    public int TargetPrice { get; set; }

    public DateTime RegisterDate { get; set; }

    public virtual Branch Branch { get; set; } = null!;
}
