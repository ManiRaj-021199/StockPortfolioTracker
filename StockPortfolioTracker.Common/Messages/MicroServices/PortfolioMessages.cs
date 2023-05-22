namespace StockPortfolioTracker.Common;

public class PortfolioMessages
{
    #region Constants
    public static readonly string StockFetchSuccess = "Stocks fetched successfully.";
    public static readonly string StockBuySuccess = "Stock added to portfolio successfully.";
    public static readonly string StockSellSuccess = "Stock sell from portfolio successfully.";
    public static readonly string StockQuantityMismatch = "Sell quantity must be less than buy quantity.";
    public static readonly string StockNotAvailable = "Given stock not available in your portfolio.";
    public static readonly string InvalidStock = "Selected Stock was Invalid. Please try again...";
    #endregion
}