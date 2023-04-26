namespace StockPortfolioTracker.Common;

public class PortfolioStockDto
{
    #region Properties
    public int UserId { get; set; }
    public string? Symbol { get; set; }
    public int Quantity { get; set; }
    public decimal BuyPrice { get; set; }
    #endregion
}