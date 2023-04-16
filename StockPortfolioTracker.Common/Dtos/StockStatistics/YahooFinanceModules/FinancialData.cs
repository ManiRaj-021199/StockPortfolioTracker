namespace StockPortfolioTracker.Common;

public class FinancialData : BaseApiResponse
{
    public int? MaxAge { get; set; }
    public string? RecommendationKey { get; set; }
    public string? FinancialCurrency { get; set; }
    public ResultFormatDto? CurrentPrice { get; set; }
    public ResultFormatDto? TargetHighPrice { get; set; }
    public ResultFormatDto? TargetLowPrice { get; set; }
    public ResultFormatDto? TargetMeanPrice { get; set; }
    public ResultFormatDto? TargetMedianPrice { get; set; }
    public ResultFormatDto? RecommendationMean { get; set; }
    public ResultFormatDto? NumberOfAnalystOpinions { get; set; }
    public ResultFormatDto? TotalCash { get; set; }
    public ResultFormatDto? TotalCashPerShare { get; set; }
    public ResultFormatDto? Ebitda { get; set; }
    public ResultFormatDto? TotalDebt { get; set; }
    public ResultFormatDto? QuickRatio { get; set; }
    public ResultFormatDto? CurrentRatio { get; set; }
    public ResultFormatDto? TotalRevenue { get; set; }
    public ResultFormatDto? DebtToEquity { get; set; }
    public ResultFormatDto? RevenuePerShare { get; set; }
    public ResultFormatDto? ReturnOnAssets { get; set; }
    public ResultFormatDto? ReturnOnEquity { get; set; }
    public ResultFormatDto? GrossProfits { get; set; }
    public ResultFormatDto? FreeCashflow { get; set; }
    public ResultFormatDto? OperatingCashflow { get; set; }
    public ResultFormatDto? EarningsGrowth { get; set; }
    public ResultFormatDto? RevenueGrowth { get; set; }
    public ResultFormatDto? GrossMargins { get; set; }
    public ResultFormatDto? EbitdaMargins { get; set; }
    public ResultFormatDto? OperatingMargins { get; set; }
    public ResultFormatDto? ProfitMargins { get; set; }
}
