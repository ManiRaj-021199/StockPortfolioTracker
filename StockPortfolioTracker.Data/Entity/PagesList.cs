using System;
using System.Collections.Generic;

namespace StockPortfolioTracker.Data.Entity;

public partial class PagesList
{
    public int PageId { get; set; }

    public string PageRootName { get; set; } = null!;

    public string PageChildName { get; set; } = null!;

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
}
