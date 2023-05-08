namespace StockPortfolioTracker.Common;

public class SmartSearchRequestDto
{
    #region Properties
    public int StocksCount { get; set; }
    public int NewsCount { get; set; }
    public string? SearchQuery { get; set; }
    #endregion
}