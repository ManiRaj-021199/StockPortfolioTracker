namespace StockPortfolioTracker.Common;

public static class ApiEndPoints
{
	#region Constants
	public static readonly string YahooFinanceModulesApiUrl = "https://query2.finance.yahoo.com/v10/finance/quoteSummary/{0}?modules={1}";
	public static readonly string UserManagementApiUrl = "http://localhost:92/usermanagement";
	#endregion
}