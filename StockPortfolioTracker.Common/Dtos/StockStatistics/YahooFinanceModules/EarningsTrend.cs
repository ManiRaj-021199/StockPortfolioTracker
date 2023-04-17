namespace StockPortfolioTracker.Common;

public class EarningsTrend : BaseApiResponse
{
	#region Properties
	public List<TrendEarnings>? Trend { get; set; }
	#endregion
}

public class TrendEarnings
{
	#region Properties
	public string? Period { get; set; }
	public string? EndDate { get; set; }
	public ResultFormatDto? Growth { get; set; }
	public Estimate? EarningsEstimate { get; set; }
	public Estimate? RevenueEstimate { get; set; }
	public EpsTrend? EpsTrend { get; set; }
	public EpsRevisions? EpsRevisions { get; set; }
	#endregion
}

public class Estimate
{
	#region Properties
	public ResultFormatDto? Avg { get; set; }
	public ResultFormatDto? Low { get; set; }
	public ResultFormatDto? High { get; set; }
	public ResultFormatDto? YearAgoEps { get; set; }
	public ResultFormatDto? NumberOfAnalysts { get; set; }
	public ResultFormatDto? Growth { get; set; }
	#endregion
}

public class EpsTrend
{
	#region Properties
	public ResultFormatDto? Current { get; set; }
	public ResultFormatDto? _7daysAgo { get; set; }
	public ResultFormatDto? _30daysAgo { get; set; }
	public ResultFormatDto? _60daysAgo { get; set; }
	public ResultFormatDto? _90daysAgo { get; set; }
	#endregion
}

public class EpsRevisions
{
	#region Properties
	public ResultFormatDto? UpLast7days { get; set; }
	public ResultFormatDto? UpLast30days { get; set; }
	public ResultFormatDto? DownLast30days { get; set; }
	public ResultFormatDto? DownLast90days { get; set; }
	#endregion
}