namespace StockPortfolioTracker.Common;

public class PortfolioTransactionDto
{
    public int PortfolioStockId { get; set; }
    public int Quantity { get; set; }
    public double SellPrice { get; set; }
}