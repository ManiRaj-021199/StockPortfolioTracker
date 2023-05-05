namespace StockPortfolioTracker.Common;

public class PortfolioEndPoints
{
    #region Constants
    public static readonly string GetHoldingStocks = ApiEndPoints.PortfolioBaseUrl + "/GetHoldingStocks/{0}";
    public static readonly string AddStockToPortfolio = $"{ApiEndPoints.PortfolioBaseUrl}/AddStockToPortfolio";
    public static readonly string RemoveStockFromPortfolio = $"{ApiEndPoints.PortfolioBaseUrl}/SellStockFromPortfolio";
    #endregion
}