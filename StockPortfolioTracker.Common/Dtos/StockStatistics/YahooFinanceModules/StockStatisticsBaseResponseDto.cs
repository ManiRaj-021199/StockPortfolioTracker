namespace StockPortfolioTracker.Common;

public class QuoteSummaryResponseDto
{
	#region Properties
	public QuoteSummaryDto? QuoteSummary { get; set; }
	#endregion
}

public class QuoteSummaryDto
{
	#region Properties
	public QuoteSummaryResultDto[]? Result { get; set; }
	#endregion
}

public class QuoteSummaryResultDto
{
	#region Properties
	public AssetProfileDto? AssetProfile { get; set; }
	public CalendarEventsDto? CalendarEvents { get; set; }
	public EarningsDto? Earnings { get; set; }
	public EarningsTrendDto? EarningsTrend { get; set; }
	public EsgScoresDto? EsgScores { get; set; }
	public FinancialDataDto? FinancialData { get; set; }
	public IndexTrendDto? IndexTrend { get; set; }
	public IndustryTrendDto? IndustryTrend { get; set; }
	public PriceDto? Price { get; set; }
	public QuoteTypeDto? QuoteType { get; set; }
	public SummaryDetailDto? SummaryDetail { get; set; }
	public FundOwnershipDto? FundOwnership { get; set; }
	public InsiderHoldersDto? InsiderHolders { get; set; }
	public InsiderTransactionsDto? InsiderTransactions { get; set; }
	public RecommendationTrendDto? RecommendationTrend { get; set; }
	#endregion
}

public class ResultFormatDto
{
	#region Properties
	public string? Raw { get; set; }
	public string? Fmt { get; set; }
	public string? LongFmt { get; set; }
	#endregion
}