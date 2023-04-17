namespace StockPortfolioTracker.Common;

public class CalendarEvents : BaseApiResponse
{
	#region Properties
	public CalenderEventEarnings? Earnings { get; set; }
	public ResultFormatDto? DividendDate { get; set; }
	public ResultFormatDto? ExDividendDate { get; set; }
	#endregion
}

public class CalenderEventEarnings
{
	#region Properties
	public List<ResultFormatDto>? EarningsDate { get; set; }
	public ResultFormatDto? EarningsAverage { get; set; }
	public ResultFormatDto? EarningsLow { get; set; }
	public ResultFormatDto? EarningsHigh { get; set; }
	public ResultFormatDto? RevenueAverage { get; set; }
	public ResultFormatDto? RevenueLow { get; set; }
	public ResultFormatDto? RevenueHigh { get; set; }
	#endregion
}