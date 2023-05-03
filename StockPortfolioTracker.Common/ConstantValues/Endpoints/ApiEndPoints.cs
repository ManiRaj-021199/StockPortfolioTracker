namespace StockPortfolioTracker.Common;

public static class ApiEndPoints
{
	#region Constants
	public static readonly string YahooFinanceModulesApiUrl = "https://query2.finance.yahoo.com/v10/finance/quoteSummary/{0}?modules={1}";

    // Webservice Endpoints
    public static readonly string AuthenticationBaseUrl = "http://localhost:92/Authentication";
    public static readonly string UserManagementBaseUrl = "http://localhost:92/UserManagement";
    public static readonly string PortfolioBaseUrl = "http://localhost:92/Portfolio";
    #endregion
}