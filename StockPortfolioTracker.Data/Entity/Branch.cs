using System;
using System.Collections.Generic;

namespace StockPortfolioTracker.Data.Entity;

public partial class Branch
{
    public int BranchId { get; set; }

    public string BranchName { get; set; } = null!;

    public virtual ICollection<Recommendation> Recommendations { get; set; } = new List<Recommendation>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
