namespace StockPortfolioTracker.Common;

public class PortfolioMessages
{
    #region Constants
    public static readonly string StockFetchSuccess = "Stocks fetched successfully.";
    public static readonly string StockBuySuccess = "Stock added to portfolio successfully.";
    public static readonly string StockSellSuccess = "Stock sell from portfolio successfully.";
    public static readonly string StockQuantityMismatch = "Sell quantity must be less than buy quantity.";
    public static readonly string StockNotAvailableInCategory = "Given stock not available in your selected portfolio category.";
    public static readonly string InvalidStock = "Selected Stock was Invalid. Please try again...";
    public static readonly string CategoriesFetchSuccess = "Categories fetched successfully.";
    public static readonly string CategoryNotFound = "Category Not Found...";
    public static readonly string AddCategorySuccess = "Category added to portfolio successfully.";
    public static readonly string CategoryNameUpdateSuccess = "Category Name Update Success...";
    public static readonly string RemoveCategorySuccess = "Category removed from portfolio successfully.";
    #endregion
}