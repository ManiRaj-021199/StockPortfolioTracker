using System.Net.Http.Headers;

namespace StockPortfolioTracker.Common;

public static class HttpClientHelper
{
	#region Publics
	public static HttpResponseMessage GetYahooFinanceModuleResponse(string strStockSympol, string strModule)
	{
		HttpClient httpClient = new()
		                        {
			                        BaseAddress = new Uri(string.Format(ApiEndPoints.YahooFinanceModulesApiUrl, strStockSympol, strModule))
		                        };
		httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

		HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

		return response;
	}
	#endregion
}