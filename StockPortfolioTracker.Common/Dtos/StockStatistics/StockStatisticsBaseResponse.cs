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
    public FinancialData? FinancialData { get; set; }
}

public class ResultFormatDto
{
    public string? Raw { get; set; }
    public string? Fmt { get; set; }
    public string? LongFmt { get; set; }
}