namespace StockPortfolioTracker.Common;

public class HoldingStockDto
{
    #region Properties
    public string? StockName { get; set; }
    public int Quantity { get; set; }
    public double AveragePrice { get; set; }
    public double InvestedValue { get; set; }
    public double CurrentMarketPrice { get; set; }
    public string? TodayChangePercentage { get; set; }
    public double? CurrentValue { get; set; }
    public double? ProfitOrLossAmount { get; set; }
    public double? ProfitOrLossPercentage { get; set; }
    public string? Currency { get; set; }
    #endregion
}