namespace StockPortfolioTracker.Common;

public class EarningsTrendDto : BaseApiResponseDto
{
	#region Properties
	public List<TrendEarningsDto>? Trend { get; set; }
	#endregion
}

public class TrendEarningsDto
{
	#region Properties
	public string? Period { get; set; }
	public string? EndDate { get; set; }
	public ResultFormatDto? Growth { get; set; }
	public EstimateDto? EarningsEstimate { get; set; }
	public EstimateDto? RevenueEstimate { get; set; }
	public EpsTrendDto? EpsTrend { get; set; }
	public EpsRevisionsDto? EpsRevisions { get; set; }
	#endregion
}

public class EstimateDto
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

public class EpsTrendDto
{
	#region Properties
	public ResultFormatDto? Current { get; set; }
	public ResultFormatDto? _7daysAgo { get; set; }
	public ResultFormatDto? _30daysAgo { get; set; }
	public ResultFormatDto? _60daysAgo { get; set; }
	public ResultFormatDto? _90daysAgo { get; set; }
	#endregion
}

public class EpsRevisionsDto
{
	#region Properties
	public ResultFormatDto? UpLast7days { get; set; }
	public ResultFormatDto? UpLast30days { get; set; }
	public ResultFormatDto? DownLast30days { get; set; }
	public ResultFormatDto? DownLast90days { get; set; }
	#endregion
}