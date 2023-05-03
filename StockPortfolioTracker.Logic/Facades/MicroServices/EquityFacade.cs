using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Logic;

public class EquityFacade : IEquityFacade
{
	#region Publics
    public BaseApiResponseDto GetDataFromYahooFinance(string strStockSympol, string strModule)
    {
        BaseApiResponseDto response = new();

        try
        {
			// Get Data From Yahoo Finance
            HttpClient httpClient = new()
                                    {
                                        BaseAddress = new Uri(string.Format(ApiEndPoints.YahooFinanceModulesApiUrl, strStockSympol, strModule))
                                    };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage apiResponse = httpClient.GetAsync(string.Empty).Result;

            if(!apiResponse.IsSuccessStatusCode)
            {
                response.ResponseCode = HttpStatusCode.NotFound;
                response.ResponseMessage = CommonWebServiceMessages.NotFound;

                return response;
            }

            string responseResult = apiResponse.Content.ReadAsStringAsync().Result;
            QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);
			
            response.ResponseCode = HttpStatusCode.OK;
            response.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
            response.Result = strModule switch
            {
                YahooFinanceModules.AssetProfile => data!.QuoteSummary?.Result![0].AssetProfile!,
				YahooFinanceModules.CalendarEvents => data!.QuoteSummary?.Result![0].CalendarEvents!,
				YahooFinanceModules.Earnings => data!.QuoteSummary?.Result![0].Earnings!,
				YahooFinanceModules.EarningsTrend => data!.QuoteSummary?.Result![0].EarningsTrend!,
				YahooFinanceModules.EsgScores => data!.QuoteSummary?.Result![0].EsgScores!,
				YahooFinanceModules.FinancialData => data!.QuoteSummary?.Result![0].FinancialData!,
				YahooFinanceModules.IndexTrend => data!.QuoteSummary?.Result![0].IndexTrend!,
				YahooFinanceModules.IndustryTrend => data!.QuoteSummary?.Result![0].IndustryTrend!,
				YahooFinanceModules.Price => data!.QuoteSummary?.Result![0].Price!,
				YahooFinanceModules.QuoteType => data!.QuoteSummary?.Result![0].QuoteType!,
				YahooFinanceModules.SummaryDetail => data!.QuoteSummary?.Result![0].SummaryDetail!,
				YahooFinanceModules.FundOwnership => data!.QuoteSummary?.Result![0].FundOwnership!,
				YahooFinanceModules.InsiderHolders => data!.QuoteSummary?.Result![0].InsiderHolders!,
				YahooFinanceModules.InsiderTransactions => data!.QuoteSummary?.Result![0].InsiderTransactions!,
				YahooFinanceModules.RecommendationTrend => data!.QuoteSummary?.Result![0].RecommendationTrend!,
                _ => response.Result
            };
        }
        catch(Exception err)
        {
            response.ResponseCode = HttpStatusCode.BadRequest;
            response.ResponseMessage = err.Message;
        }

		return response;
    }
    #endregion
}