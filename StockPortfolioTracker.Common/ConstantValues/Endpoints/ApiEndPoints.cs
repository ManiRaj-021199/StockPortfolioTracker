namespace StockPortfolioTracker.Common;

public static class ApiEndPoints
{
    #region Constants
    public static readonly string YahooFinanceModulesApiUrl = "https://query2.finance.yahoo.com/v10/finance/quoteSummary/{0}?modules={1}";
    public static readonly string SPTBaseUrl = "http://localhost:92";

    // Webservice Endpoints
    public static readonly string AuthenticationBaseUrl = $"{SPTBaseUrl}/Authentication";
    public static readonly string StockStatisticsEquityBaseUrl = $"{SPTBaseUrl}/Equity";
    public static readonly string UserManagementBaseUrl = $"{SPTBaseUrl}/UserManagement";
    public static readonly string ClientManagementBaseUrl = $"{SPTBaseUrl}/ClientManagement";
    public static readonly string PortfolioBaseUrl = $"{SPTBaseUrl}/Portfolio";
    #endregion
}