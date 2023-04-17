namespace StockPortfolioTracker.Common;

public class QuoteSummaryResponse
{
	#region Properties
	public QuoteSummary? QuoteSummary { get; set; }
	#endregion
}

public class QuoteSummary
{
	#region Properties
	public QuoteSummaryResult[]? Result { get; set; }
	#endregion
}

public class QuoteSummaryResult
{
	#region Properties
	public AssetProfile? AssetProfile { get; set; }
	public CalendarEvents? CalendarEvents { get; set; }
	public Earnings? Earnings { get; set; }
	public EarningsTrend? EarningsTrend { get; set; }
	public EsgScores? EsgScores { get; set; }
	public FinancialData? FinancialData { get; set; }
	public IndexTrend? IndexTrend { get; set; }
	public IndustryTrend? IndustryTrend { get; set; }
	public Price? Price { get; set; }
	public QuoteType? QuoteType { get; set; }
	public SummaryDetail? SummaryDetail { get; set; }
	public FundOwnership? FundOwnership { get; set; }
	public InsiderHolders? InsiderHolders { get; set; }
	public InsiderTransactions? InsiderTransactions { get; set; }
	public RecommendationTrend? RecommendationTrend { get; set; }
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