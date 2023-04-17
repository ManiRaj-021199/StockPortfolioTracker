namespace StockPortfolioTracker.Common;

public class IndexTrend : BaseApiResponse
{
	#region Properties
	public string? Symbol { get; set; }
	public ResultFormatDto? PeRatio { get; set; }
	public ResultFormatDto? PegRatio { get; set; }
	public List<IndexTrendEstimates>? Estimates { get; set; }
	#endregion
}

public class IndexTrendEstimates
{
	#region Properties
	public string? Period { get; set; }
	public ResultFormatDto? Growth { get; set; }
	#endregion
}