using Newtonsoft.Json;
using StockPortfolioTracker.Common;
using System.Net;

namespace StockStatistics.Services;

public class EquityServices : IEquityServices
{
    #region Publics
    public FinancialData GetFinancialData(string strStockSympol)
    {
        FinancialData financialData = new();

        try
        {
            HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, "financialData");
            HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

            if (!response.IsSuccessStatusCode)
            {
                financialData.ResponseCode = HttpStatusCode.NotFound;
                financialData.ResponseMessage = CommonWebServiceMessages.NOT_FOUND;

                return financialData;
            }

            string responseResult = response.Content.ReadAsStringAsync().Result;
            QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

            financialData = data.QuoteSummary?.Result![0].FinancialData!;
            financialData.ResponseCode = HttpStatusCode.OK;
            financialData.ResponseMessage = CommonWebServiceMessages.DATA_FETCH_SUCCESS;
        }
        catch (Exception err)
        {
            financialData.ResponseCode = HttpStatusCode.BadRequest;
            financialData.ResponseMessage = err.Message;
        }

        return financialData;
    }
    #endregion
}