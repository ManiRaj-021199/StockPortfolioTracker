namespace StockPortfolioTracker.Common;

public class RecommendationTrend : BaseApiResponse
{
	#region Properties
	public List<TrendRecommendation>? Trend { get; set; }
	#endregion
}

public class TrendRecommendation
{
	#region Properties
	public string? Period { get; set; }
	public string? StrongBuy { get; set; }
	public string? Buy { get; set; }
	public string? Hold { get; set; }
	public string? Sell { get; set; }
	public string? StrongSell { get; set; }
	#endregion
}