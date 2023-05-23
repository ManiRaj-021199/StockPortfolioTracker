using System;
using System.Collections.Generic;

namespace StockPortfolioTracker.Data.Entity;

public partial class Log
{
    public int LogId { get; set; }

    public int PageId { get; set; }

    public string Severity { get; set; } = null!;

    public string Request { get; set; } = null!;

    public string Response { get; set; } = null!;

    public DateTime LogDate { get; set; }

    public virtual PagesList Page { get; set; } = null!;
}
