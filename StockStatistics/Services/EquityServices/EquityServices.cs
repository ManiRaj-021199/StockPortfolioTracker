using System.Net;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;

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

			if(!response.IsSuccessStatusCode)
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
		catch(Exception err)
		{
			assetProfile.ResponseCode = HttpStatusCode.BadRequest;
			assetProfile.ResponseMessage = err.Message;
		}

		return assetProfile;
	}

	public CalendarEvents GetCalendarEvents(string strStockSympol)
	{
		CalendarEvents calendarEvents = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.CalendarEvents);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				calendarEvents.ResponseCode = HttpStatusCode.NotFound;
				calendarEvents.ResponseMessage = CommonWebServiceMessages.NotFound;

				return calendarEvents;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			calendarEvents = data.QuoteSummary?.Result![0].CalendarEvents!;
			calendarEvents.ResponseCode = HttpStatusCode.OK;
			calendarEvents.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			calendarEvents.ResponseCode = HttpStatusCode.BadRequest;
			calendarEvents.ResponseMessage = err.Message;
		}

		return calendarEvents;
	}

	public Earnings GetEarnings(string strStockSympol)
	{
		Earnings earnings = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.Earnings);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				earnings.ResponseCode = HttpStatusCode.NotFound;
				earnings.ResponseMessage = CommonWebServiceMessages.NotFound;

				return earnings;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			earnings = data.QuoteSummary?.Result![0].Earnings!;
			earnings.ResponseCode = HttpStatusCode.OK;
			earnings.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			earnings.ResponseCode = HttpStatusCode.BadRequest;
			earnings.ResponseMessage = err.Message;
		}

		return earnings;
	}

	public EarningsTrend GetEarningsTrend(string strStockSympol)
	{
		EarningsTrend earningsTrend = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.EarningsTrend);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				earningsTrend.ResponseCode = HttpStatusCode.NotFound;
				earningsTrend.ResponseMessage = CommonWebServiceMessages.NotFound;

				return earningsTrend;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			earningsTrend = data.QuoteSummary?.Result![0].EarningsTrend!;
			earningsTrend.ResponseCode = HttpStatusCode.OK;
			earningsTrend.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			earningsTrend.ResponseCode = HttpStatusCode.BadRequest;
			earningsTrend.ResponseMessage = err.Message;
		}

		return earningsTrend;
	}

	public EsgScores GetEsgScores(string strStockSympol)
	{
		EsgScores esgScores = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.EsgScores);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				esgScores.ResponseCode = HttpStatusCode.NotFound;
				esgScores.ResponseMessage = CommonWebServiceMessages.NotFound;

				return esgScores;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			esgScores = data.QuoteSummary?.Result![0].EsgScores!;
			esgScores.ResponseCode = HttpStatusCode.OK;
			esgScores.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			esgScores.ResponseCode = HttpStatusCode.BadRequest;
			esgScores.ResponseMessage = err.Message;
		}

		return esgScores;
	}

	public FinancialData GetFinancialData(string strStockSympol)
	{
		FinancialData financialData = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.FinancialData);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
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
		catch(Exception err)
		{
			financialData.ResponseCode = HttpStatusCode.BadRequest;
			financialData.ResponseMessage = err.Message;
		}

		return financialData;
	}

	public FundOwnership GetFundOwnership(string strStockSympol)
	{
		FundOwnership fundOwnership = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.FundOwnership);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				fundOwnership.ResponseCode = HttpStatusCode.NotFound;
				fundOwnership.ResponseMessage = CommonWebServiceMessages.NotFound;

				return fundOwnership;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			fundOwnership = data.QuoteSummary?.Result![0].FundOwnership!;
			fundOwnership.ResponseCode = HttpStatusCode.OK;
			fundOwnership.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			fundOwnership.ResponseCode = HttpStatusCode.BadRequest;
			fundOwnership.ResponseMessage = err.Message;
		}

		return fundOwnership;
	}

	public IndexTrend GetIndexTrend(string strStockSympol)
	{
		IndexTrend indexTrend = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.IndexTrend);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				indexTrend.ResponseCode = HttpStatusCode.NotFound;
				indexTrend.ResponseMessage = CommonWebServiceMessages.NotFound;

				return indexTrend;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			indexTrend = data.QuoteSummary?.Result![0].IndexTrend!;
			indexTrend.ResponseCode = HttpStatusCode.OK;
			indexTrend.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			indexTrend.ResponseCode = HttpStatusCode.BadRequest;
			indexTrend.ResponseMessage = err.Message;
		}

		return indexTrend;
	}

	public IndustryTrend GetIndustryTrend(string strStockSympol)
	{
		IndustryTrend industryTrend = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.IndustryTrend);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				industryTrend.ResponseCode = HttpStatusCode.NotFound;
				industryTrend.ResponseMessage = CommonWebServiceMessages.NotFound;

				return industryTrend;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			industryTrend = data.QuoteSummary?.Result![0].IndustryTrend!;
			industryTrend.ResponseCode = HttpStatusCode.OK;
			industryTrend.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			industryTrend.ResponseCode = HttpStatusCode.BadRequest;
			industryTrend.ResponseMessage = err.Message;
		}

		return industryTrend;
	}

	public InsiderHolders GetInsiderHolders(string strStockSympol)
	{
		InsiderHolders insiderHolders = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.InsiderHolders);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				insiderHolders.ResponseCode = HttpStatusCode.NotFound;
				insiderHolders.ResponseMessage = CommonWebServiceMessages.NotFound;

				return insiderHolders;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			insiderHolders = data.QuoteSummary?.Result![0].InsiderHolders!;
			insiderHolders.ResponseCode = HttpStatusCode.OK;
			insiderHolders.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			insiderHolders.ResponseCode = HttpStatusCode.BadRequest;
			insiderHolders.ResponseMessage = err.Message;
		}

		return insiderHolders;
	}

	public InsiderTransactions GetInsiderTransactions(string strStockSympol)
	{
		InsiderTransactions insiderTransactions = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.InsiderTransactions);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				insiderTransactions.ResponseCode = HttpStatusCode.NotFound;
				insiderTransactions.ResponseMessage = CommonWebServiceMessages.NotFound;

				return insiderTransactions;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			insiderTransactions = data.QuoteSummary?.Result![0].InsiderTransactions!;
			insiderTransactions.ResponseCode = HttpStatusCode.OK;
			insiderTransactions.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			insiderTransactions.ResponseCode = HttpStatusCode.BadRequest;
			insiderTransactions.ResponseMessage = err.Message;
		}

		return insiderTransactions;
	}

	public Price GetPrice(string strStockSympol)
	{
		Price price = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.Price);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				price.ResponseCode = HttpStatusCode.NotFound;
				price.ResponseMessage = CommonWebServiceMessages.NotFound;

				return price;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			price = data.QuoteSummary?.Result![0].Price!;
			price.ResponseCode = HttpStatusCode.OK;
			price.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			price.ResponseCode = HttpStatusCode.BadRequest;
			price.ResponseMessage = err.Message;
		}

		return price;
	}

	public QuoteType GetQuoteType(string strStockSympol)
	{
		QuoteType quoteType = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.QuoteType);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				quoteType.ResponseCode = HttpStatusCode.NotFound;
				quoteType.ResponseMessage = CommonWebServiceMessages.NotFound;

				return quoteType;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			quoteType = data.QuoteSummary?.Result![0].QuoteType!;
			quoteType.ResponseCode = HttpStatusCode.OK;
			quoteType.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			quoteType.ResponseCode = HttpStatusCode.BadRequest;
			quoteType.ResponseMessage = err.Message;
		}

		return quoteType;
	}

	public RecommendationTrend GetRecommendationTrend(string strStockSympol)
	{
		RecommendationTrend recommendationTrend = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.RecommendationTrend);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				recommendationTrend.ResponseCode = HttpStatusCode.NotFound;
				recommendationTrend.ResponseMessage = CommonWebServiceMessages.NotFound;

				return recommendationTrend;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			recommendationTrend = data.QuoteSummary?.Result![0].RecommendationTrend!;
			recommendationTrend.ResponseCode = HttpStatusCode.OK;
			recommendationTrend.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			recommendationTrend.ResponseCode = HttpStatusCode.BadRequest;
			recommendationTrend.ResponseMessage = err.Message;
		}

		return recommendationTrend;
	}

	public SummaryDetail GetSummaryDetail(string strStockSympol)
	{
		SummaryDetail summaryDetail = new();

		try
		{
			HttpClient httpClient = ApiConfigurations.ConfigureYahooFinanceModulesApi(strStockSympol, YahooFinanceModules.SummaryDetail);
			HttpResponseMessage response = httpClient.GetAsync(string.Empty).Result;

			if(!response.IsSuccessStatusCode)
			{
				summaryDetail.ResponseCode = HttpStatusCode.NotFound;
				summaryDetail.ResponseMessage = CommonWebServiceMessages.NotFound;

				return summaryDetail;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

			summaryDetail = data.QuoteSummary?.Result![0].SummaryDetail!;
			summaryDetail.ResponseCode = HttpStatusCode.OK;
			summaryDetail.ResponseMessage = CommonWebServiceMessages.DataFetchSuccess;
		}
		catch(Exception err)
		{
			summaryDetail.ResponseCode = HttpStatusCode.BadRequest;
			summaryDetail.ResponseMessage = err.Message;
		}

		return summaryDetail;
	}
	#endregion
}