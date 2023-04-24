using System.Net;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Logic;

public class EquityServices : IEquityServices
{
	#region Publics
	public AssetProfileDto GetAssetProfile(string strStockSympol)
	{
		AssetProfileDto assetProfile = new();

		try
		{
            HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.AssetProfile);

            if(!response.IsSuccessStatusCode)
			{
				assetProfile.ResponseCode = HttpStatusCode.NotFound;
				assetProfile.ResponseMessage = CommonWebServiceMessages.NotFound;

				return assetProfile;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			assetProfile = data!.QuoteSummary?.Result![0].AssetProfile!;
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

	public CalendarEventsDto GetCalendarEvents(string strStockSympol)
	{
		CalendarEventsDto calendarEvents = new();

		try
		{
			HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.CalendarEvents);

            if(!response.IsSuccessStatusCode)
			{
				calendarEvents.ResponseCode = HttpStatusCode.NotFound;
				calendarEvents.ResponseMessage = CommonWebServiceMessages.NotFound;

				return calendarEvents;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			calendarEvents = data!.QuoteSummary?.Result![0].CalendarEvents!;
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

	public EarningsDto GetEarnings(string strStockSympol)
	{
		EarningsDto earnings = new();

		try
		{
			HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.Earnings);

            if(!response.IsSuccessStatusCode)
			{
				earnings.ResponseCode = HttpStatusCode.NotFound;
				earnings.ResponseMessage = CommonWebServiceMessages.NotFound;

				return earnings;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			earnings = data!.QuoteSummary?.Result![0].Earnings!;
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

	public EarningsTrendDto GetEarningsTrend(string strStockSympol)
	{
		EarningsTrendDto earningsTrend = new();

		try
		{
            HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.EarningsTrend);

            if(!response.IsSuccessStatusCode)
			{
				earningsTrend.ResponseCode = HttpStatusCode.NotFound;
				earningsTrend.ResponseMessage = CommonWebServiceMessages.NotFound;

				return earningsTrend;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			earningsTrend = data!.QuoteSummary?.Result![0].EarningsTrend!;
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

	public EsgScoresDto GetEsgScores(string strStockSympol)
	{
		EsgScoresDto esgScores = new();

		try
		{
			HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.EsgScores);

            if(!response.IsSuccessStatusCode)
			{
				esgScores.ResponseCode = HttpStatusCode.NotFound;
				esgScores.ResponseMessage = CommonWebServiceMessages.NotFound;

				return esgScores;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			esgScores = data!.QuoteSummary?.Result![0].EsgScores!;
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

	public FinancialDataDto GetFinancialData(string strStockSympol)
	{
		FinancialDataDto financialData = new();

		try
		{
			HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.FinancialData);

            if(!response.IsSuccessStatusCode)
			{
				financialData.ResponseCode = HttpStatusCode.NotFound;
				financialData.ResponseMessage = CommonWebServiceMessages.NotFound;

				return financialData;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			financialData = data!.QuoteSummary?.Result![0].FinancialData!;
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

	public FundOwnershipDto GetFundOwnership(string strStockSympol)
	{
		FundOwnershipDto fundOwnership = new();

		try
		{
			HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.FundOwnership);

            if(!response.IsSuccessStatusCode)
			{
				fundOwnership.ResponseCode = HttpStatusCode.NotFound;
				fundOwnership.ResponseMessage = CommonWebServiceMessages.NotFound;

				return fundOwnership;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			fundOwnership = data!.QuoteSummary?.Result![0].FundOwnership!;
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

	public IndexTrendDto GetIndexTrend(string strStockSympol)
	{
		IndexTrendDto indexTrend = new();

		try
		{
			HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.IndexTrend);

            if(!response.IsSuccessStatusCode)
			{
				indexTrend.ResponseCode = HttpStatusCode.NotFound;
				indexTrend.ResponseMessage = CommonWebServiceMessages.NotFound;

				return indexTrend;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			indexTrend = data!.QuoteSummary?.Result![0].IndexTrend!;
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

	public IndustryTrendDto GetIndustryTrend(string strStockSympol)
	{
		IndustryTrendDto industryTrend = new();

		try
		{
			HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.IndustryTrend);

            if(!response.IsSuccessStatusCode)
			{
				industryTrend.ResponseCode = HttpStatusCode.NotFound;
				industryTrend.ResponseMessage = CommonWebServiceMessages.NotFound;

				return industryTrend;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			industryTrend = data!.QuoteSummary?.Result![0].IndustryTrend!;
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

	public InsiderHoldersDto GetInsiderHolders(string strStockSympol)
	{
		InsiderHoldersDto insiderHolders = new();

		try
		{
			HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.InsiderHolders);

            if(!response.IsSuccessStatusCode)
			{
				insiderHolders.ResponseCode = HttpStatusCode.NotFound;
				insiderHolders.ResponseMessage = CommonWebServiceMessages.NotFound;

				return insiderHolders;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			insiderHolders = data!.QuoteSummary?.Result![0].InsiderHolders!;
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

	public InsiderTransactionsDto GetInsiderTransactions(string strStockSympol)
	{
		InsiderTransactionsDto insiderTransactions = new();

		try
		{
			HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.InsiderTransactions);

            if(!response.IsSuccessStatusCode)
			{
				insiderTransactions.ResponseCode = HttpStatusCode.NotFound;
				insiderTransactions.ResponseMessage = CommonWebServiceMessages.NotFound;

				return insiderTransactions;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			insiderTransactions = data!.QuoteSummary?.Result![0].InsiderTransactions!;
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

	public PriceDto GetPrice(string strStockSympol)
	{
		PriceDto price = new();

		try
		{
            HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.Price);

            if(!response.IsSuccessStatusCode)
			{
				price.ResponseCode = HttpStatusCode.NotFound;
				price.ResponseMessage = CommonWebServiceMessages.NotFound;

				return price;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			price = data!.QuoteSummary?.Result![0].Price!;
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

	public QuoteTypeDto GetQuoteType(string strStockSympol)
	{
		QuoteTypeDto quoteType = new();

		try
		{
            HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.QuoteType);

            if(!response.IsSuccessStatusCode)
			{
				quoteType.ResponseCode = HttpStatusCode.NotFound;
				quoteType.ResponseMessage = CommonWebServiceMessages.NotFound;

				return quoteType;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			quoteType = data!.QuoteSummary?.Result![0].QuoteType!;
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

	public RecommendationTrendDto GetRecommendationTrend(string strStockSympol)
	{
		RecommendationTrendDto recommendationTrend = new();

		try
		{
            HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.RecommendationTrend);

            if(!response.IsSuccessStatusCode)
			{
				recommendationTrend.ResponseCode = HttpStatusCode.NotFound;
				recommendationTrend.ResponseMessage = CommonWebServiceMessages.NotFound;

				return recommendationTrend;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			recommendationTrend = data!.QuoteSummary?.Result![0].RecommendationTrend!;
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

	public SummaryDetailDto GetSummaryDetail(string strStockSympol)
	{
		SummaryDetailDto summaryDetail = new();

		try
		{
			HttpResponseMessage response = HttpClientHelper.GetYahooFinanceModuleResponse(strStockSympol, YahooFinanceModules.SummaryDetail);

            if(!response.IsSuccessStatusCode)
			{
				summaryDetail.ResponseCode = HttpStatusCode.NotFound;
				summaryDetail.ResponseMessage = CommonWebServiceMessages.NotFound;

				return summaryDetail;
			}

			string responseResult = response.Content.ReadAsStringAsync().Result;
			QuoteSummaryResponseDto? data = JsonConvert.DeserializeObject<QuoteSummaryResponseDto>(responseResult);

			summaryDetail = data!.QuoteSummary?.Result![0].SummaryDetail!;
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