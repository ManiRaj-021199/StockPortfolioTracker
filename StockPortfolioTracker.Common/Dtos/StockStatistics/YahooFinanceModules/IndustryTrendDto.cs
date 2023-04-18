namespace StockPortfolioTracker.Common;

public class IndustryTrendDto : BaseApiResponseDto
{
	#region Properties
	public string? Symbol { get; set; }
	public ResultFormatDto? PeRatio { get; set; }
	public ResultFormatDto? PegRatio { get; set; }
	public List<IndustryTrendEstimatesDto>? Estimates { get; set; }
	#endregion
}

public class IndustryTrendEstimatesDto
{
	#region Properties
	public string? Period { get; set; }
	public ResultFormatDto? Growth { get; set; }
	#endregion
}