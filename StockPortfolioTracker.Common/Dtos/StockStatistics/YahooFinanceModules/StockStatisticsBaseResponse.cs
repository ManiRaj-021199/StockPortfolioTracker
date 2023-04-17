namespace StockPortfolioTracker.Common;

public class QuoteSummaryResponse
{
    public QuoteSummary? QuoteSummary { get; set; }
}

public class QuoteSummary
{
    public QuoteSummaryResult[]? Result { get; set; }
}

public class QuoteSummaryResult
{
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
    public SummaryProfile? SummaryProfile { get; set; }
    public FundOwnership? FundOwnership { get; set; }
    public InsiderHolders? InsiderHolders { get; set; }
    public InsiderTransactions? InsiderTransactions { get; set; }
    public RecommendationTrend? RecommendationTrend { get; set; }
}

public class ResultFormatDto
{
    public string? Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}