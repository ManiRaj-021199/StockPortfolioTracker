namespace StockPortfolioTracker.Common;

public class QuoteType : BaseApiResponse
{
	#region Properties
	public string? Exchange { get; set; }
	public string? Symbol { get; set; }
	public string? UnderlyingSymbol { get; set; }
	public string? ShortName { get; set; }
	public string? LongName { get; set; }
	public string? FirstTradeDateEpochUtc { get; set; }
	public string? TimeZoneFullName { get; set; }
	public string? TimeZoneShortName { get; set; }
	#endregion
}