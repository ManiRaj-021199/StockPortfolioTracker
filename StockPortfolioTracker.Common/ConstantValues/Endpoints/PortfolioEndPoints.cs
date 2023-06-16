namespace StockPortfolioTracker.Common;

public class PortfolioEndPoints
{
    #region Constants
    public static readonly string GetAllPortfolioCategories = ApiEndPoints.PortfolioBaseUrl + "/GetAllPortfolioCategories/{0}";
    public static readonly string GetHoldingStocks = ApiEndPoints.PortfolioBaseUrl + "/GetHoldingStocks";
    public static readonly string AddNewPortfolioCategory = $"{ApiEndPoints.PortfolioBaseUrl}/AddNewPortfolioCategory";
    public static readonly string AddStockToPortfolio = $"{ApiEndPoints.PortfolioBaseUrl}/AddStockToPortfolio";
    public static readonly string RemoveStockFromPortfolio = $"{ApiEndPoints.PortfolioBaseUrl}/SellStockFromPortfolio";
    public static readonly string UpdatePortfolioCategoryName = $"{ApiEndPoints.PortfolioBaseUrl}/UpdatePortfolioCategoryName";
    public static readonly string DeletePortfolioCategory = $"{ApiEndPoints.PortfolioBaseUrl}/DeletePortfolioCategory";
    #endregion
}