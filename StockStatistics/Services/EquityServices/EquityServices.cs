using Newtonsoft.Json;
using StockPortfolioTracker.Common;
using System.Net;

namespace StockStatistics.Services;

public class EquityServices : IEquityServices
{
    #region Publics
    public AssetProfile GetAssetProfile(string strStockSympol)
    {
        AssetProfile assetProfile = new();

        try
        {
            HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.AssetProfile);
            HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

            if (!response.IsSuccessStatusCode)
            {
                assetProfile.ResponseCode = HttpStatusCode.NotFound;
                assetProfile.ResponseMessage = CommonWebServiceMessages.NotFound;

                return assetProfile;
            }

            string responseResult = response.Content.ReadAsStringAsync().Result;
            QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

            assetProfile = data.QuoteSummary?.Result![0].AssetProfile!;
            assetProfile.ResponseCode = HttpStatusCode.OK;
            assetProfile.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
        }
        catch (Exception err)
        {
            assetProfile.ResponseCode = HttpStatusCode.BadRequest;
            assetProfile.ResponseMessage = err.Message;
        }

        return assetProfile;
    }

    public CalendarEvents GetCalendarEvents(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public Earnings GetEarnings(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public EarningsTrend GetEarningsTrend(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public EsgScores GetEsgScores(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public FinancialData GetFinancialData(string strStockSympol)
    {
        FinancialData financialData = new();

        try
        {
            HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.FinancialData);
            HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

            if (!response.IsSuccessStatusCode)
            {
                financialData.ResponseCode = HttpStatusCode.NotFound;
                financialData.ResponseMessage = CommonWebServiceMessages.NotFound;

                return financialData;
            }

            string responseResult = response.Content.ReadAsStringAsync().Result;
            QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

            financialData = data.QuoteSummary?.Result![0].FinancialData!;
            financialData.ResponseCode = HttpStatusCode.OK;
            financialData.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
        }
        catch (Exception err)
        {
            financialData.ResponseCode = HttpStatusCode.BadRequest;
            financialData.ResponseMessage = err.Message;
        }

        return financialData;
    }

    public FundOwnership GetFundOwnership(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public IndexTrend GetIndexTrend(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public IndustryTrend GetIndustryTrend(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public InsiderHolders GetInsiderHolders(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public InsiderTransactions GetInsiderTransactions(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public Price GetPrice(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public QuoteType GetQuoteType(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public RecommendationTrend GetRecommendationTrend(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public SummaryDetail GetSummaryDetail(string strStockSympol)
    {
        throw new NotImplementedException();
    }

    public SummaryProfile GetSummaryProfile(string strStockSympol)
    {
        throw new NotImplementedException();
    }
    #endregion
}