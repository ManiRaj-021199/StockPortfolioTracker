namespace StockPortfolioTracker.Common;

public class PortfolioStockDto
{
    public string? StockSymbol { get; set; }
    public string? StockName { get; set; }
    public int StockQuantity { get; set; }
    public decimal StockBuyPrice { get; set; }

    public int? UserId { get; set; }
}