namespace StockPortfolioTracker.Common;

public class PriceDto : BaseApiResponseDto
{
	#region Properties
	public string? PreMarketSource { get; set; }
	public string? PostMarketSource { get; set; }
	public string? RegularMarketSource { get; set; }
	public string? PostMarketTime { get; set; }
	public string? RegularMarketTime { get; set; }
	public string? Exchange { get; set; }
	public string? ExchangeName { get; set; }
	public string? ExchangeDataDelayedBy { get; set; }
	public string? MarketState { get; set; }
	public string? QuoteType { get; set; }
	public string? Symbol { get; set; }
	public string? UnderlyingSymbol { get; set; }
	public string? ShortName { get; set; }
	public string? LongName { get; set; }
	public string? Currency { get; set; }
	public string? QuoteSourceName { get; set; }
	public string? CurrencySymbol { get; set; }
	public string? FromCurrency { get; set; }
	public string? ToCurrency { get; set; }
	public string? LastMarket { get; set; }
	public ResultFormatDto? PreMarketChange { get; set; }
	public ResultFormatDto? PreMarketPrice { get; set; }
	public ResultFormatDto? PostMarketChangePercent { get; set; }
	public ResultFormatDto? PostMarketChange { get; set; }
	public ResultFormatDto? PostMarketPrice { get; set; }
	public ResultFormatDto? RegularMarketChangePercent { get; set; }
	public ResultFormatDto? RegularMarketChange { get; set; }
	public ResultFormatDto? PriceHint { get; set; }
	public ResultFormatDto? RegularMarketPrice { get; set; }
	public ResultFormatDto? RegularMarketDayHigh { get; set; }
	public ResultFormatDto? RegularMarketDayLow { get; set; }
	public ResultFormatDto? RegularMarketVolume { get; set; }
	public ResultFormatDto? AverageDailyVolume10Day { get; set; }
	public ResultFormatDto? AverageDailyVolume3Month { get; set; }
	public ResultFormatDto? RegularMarketPreviousClose { get; set; }
	public ResultFormatDto? RegularMarketOpen { get; set; }
	public ResultFormatDto? StrikePrice { get; set; }
	public ResultFormatDto? OpenInterest { get; set; }
	public ResultFormatDto? Volume24Hr { get; set; }
	public ResultFormatDto? VolumeAllCurrencies { get; set; }
	public ResultFormatDto? CirculatingSupply { get; set; }
	public ResultFormatDto? MarketCap { get; set; }
	#endregion
}