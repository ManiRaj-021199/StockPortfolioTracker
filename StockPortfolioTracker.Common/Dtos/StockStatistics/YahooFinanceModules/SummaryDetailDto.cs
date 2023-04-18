namespace StockPortfolioTracker.Common;

public class SummaryDetailDto : BaseApiResponseDto
{
	#region Properties
	public string? Currency { get; set; }
	public string? FromCurrency { get; set; }
	public string? ToCurrency { get; set; }
	public string? LastMarket { get; set; }
	public string? CoinMarketCapLink { get; set; }
	public ResultFormatDto? PriceHint { get; set; }
	public ResultFormatDto? PreviousClose { get; set; }
	public ResultFormatDto? Open { get; set; }
	public ResultFormatDto? DayLow { get; set; }
	public ResultFormatDto? DayHigh { get; set; }
	public ResultFormatDto? RegularMarketPreviousClose { get; set; }
	public ResultFormatDto? RegularMarketOpen { get; set; }
	public ResultFormatDto? RegularMarketDayLow { get; set; }
	public ResultFormatDto? RegularMarketDayHigh { get; set; }
	public ResultFormatDto? DividendRate { get; set; }
	public ResultFormatDto? DividendYield { get; set; }
	public ResultFormatDto? ExDividendDate { get; set; }
	public ResultFormatDto? PayoutRatio { get; set; }
	public ResultFormatDto? FiveYearAvgDividendYield { get; set; }
	public ResultFormatDto? Beta { get; set; }
	public ResultFormatDto? TrailingPE { get; set; }
	public ResultFormatDto? ForwardPE { get; set; }
	public ResultFormatDto? Volume { get; set; }
	public ResultFormatDto? RegularMarketVolume { get; set; }
	public ResultFormatDto? AverageVolume { get; set; }
	public ResultFormatDto? AverageVolume10days { get; set; }
	public ResultFormatDto? AverageDailyVolume10Day { get; set; }
	public ResultFormatDto? Bid { get; set; }
	public ResultFormatDto? Ask { get; set; }
	public ResultFormatDto? BidSize { get; set; }
	public ResultFormatDto? AskSize { get; set; }
	public ResultFormatDto? MarketCap { get; set; }
	public ResultFormatDto? Yield { get; set; }
	public ResultFormatDto? YtdReturn { get; set; }
	public ResultFormatDto? TotalAssets { get; set; }
	public ResultFormatDto? ExpireDate { get; set; }
	public ResultFormatDto? StrikePrice { get; set; }
	public ResultFormatDto? OpenInterest { get; set; }
	public ResultFormatDto? FiftyTwoWeekLow { get; set; }
	public ResultFormatDto? FiftyTwoWeekHigh { get; set; }
	public ResultFormatDto? PriceToSalesTrailing12Months { get; set; }
	public ResultFormatDto? FiftyDayAverage { get; set; }
	public ResultFormatDto? TwoHundredDayAverage { get; set; }
	public ResultFormatDto? TrailingAnnualDividendRate { get; set; }
	public ResultFormatDto? TrailingAnnualDividendYield { get; set; }
	public ResultFormatDto? NavPrice { get; set; }
	public ResultFormatDto? Volume24Hr { get; set; }
	public ResultFormatDto? VolumeAllCurrencies { get; set; }
	public ResultFormatDto? CirculatingSupply { get; set; }
	public ResultFormatDto? MaxSupply { get; set; }
	public ResultFormatDto? StartDate { get; set; }
	#endregion
}