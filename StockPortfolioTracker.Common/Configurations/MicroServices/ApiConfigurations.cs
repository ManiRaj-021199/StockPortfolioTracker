using System.Net.Http.Headers;

namespace StockPortfolioTracker.Common;

public static class ApiConfigurations
{
    #region Publics
    public static HttpClient ConfigureYahooFinanceModulesApi(string strStockSympol, string strModule)
    {
        HttpClient httpClient = new()
        {
            BaseAddress = new Uri(string.Format(ApiEndPoints.YAHOO_FINANCE_MODULES_API, strStockSympol, strModule))
        };
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        return httpClient;
    }
    #endregion
}
