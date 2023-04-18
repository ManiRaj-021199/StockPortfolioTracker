using Microsoft.AspNetCore.Mvc;
using StockPortfolioTracker.Common;
using StockStatistics.Services;

namespace StockStatistics.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquityController : ControllerBase
{
	#region Fields
	private readonly IEquityServices EquityServices;
	#endregion

	#region Constructors
	public EquityController(IEquityServices equityServices)
	{
		EquityServices = equityServices;
	}
	#endregion

	#region Publics
	[HttpGet]
	[Route("GetAssetProfile/{strStockSympol}")]
	public IActionResult GetAssetProfile(string strStockSympol)
	{
		AssetProfileDto assetProfile = EquityServices.GetAssetProfile(strStockSympol);

		return Ok(assetProfile);
	}

	[HttpGet]
	[Route("GetCalendarEvents/{strStockSympol}")]
	public IActionResult GetCalendarEvents(string strStockSympol)
	{
		CalendarEventsDto calendarEvents = EquityServices.GetCalendarEvents(strStockSympol);

		return Ok(calendarEvents);
	}

	[HttpGet]
	[Route("GetEarnings/{strStockSympol}")]
	public IActionResult GetEarnings(string strStockSympol)
	{
		EarningsDto earnings = EquityServices.GetEarnings(strStockSympol);

		return Ok(earnings);
	}

	[HttpGet]
	[Route("GetEarningsTrend/{strStockSympol}")]
	public IActionResult GetEarningsTrend(string strStockSympol)
	{
		EarningsTrendDto earningsTrend = EquityServices.GetEarningsTrend(strStockSympol);

		return Ok(earningsTrend);
	}

	[HttpGet]
	[Route("GetEsgScores/{strStockSympol}")]
	public IActionResult GetEsgScores(string strStockSympol)
	{
		EsgScoresDto esgScores = EquityServices.GetEsgScores(strStockSympol);

		return Ok(esgScores);
	}

	[HttpGet]
	[Route("GetFinancialData/{strStockSympol}")]
	public IActionResult GetFinancialData(string strStockSympol)
	{
		FinancialDataDto financialData = EquityServices.GetFinancialData(strStockSympol);

		return Ok(financialData);
	}

	[HttpGet]
	[Route("GetIndexTrend/{strStockSympol}")]
	public IActionResult GetIndexTrend(string strStockSympol)
	{
		IndexTrendDto indexTrend = EquityServices.GetIndexTrend(strStockSympol);

		return Ok(indexTrend);
	}

	[HttpGet]
	[Route("GetIndustryTrend/{strStockSympol}")]
	public IActionResult GetIndustryTrend(string strStockSympol)
	{
		IndustryTrendDto industryTrend = EquityServices.GetIndustryTrend(strStockSympol);

		return Ok(industryTrend);
	}

	[HttpGet]
	[Route("GetPrice/{strStockSympol}")]
	public IActionResult GetPrice(string strStockSympol)
	{
		PriceDto price = EquityServices.GetPrice(strStockSympol);

		return Ok(price);
	}

	[HttpGet]
	[Route("GetQuoteType/{strStockSympol}")]
	public IActionResult GetQuoteType(string strStockSympol)
	{
		QuoteTypeDto quoteType = EquityServices.GetQuoteType(strStockSympol);

		return Ok(quoteType);
	}

	[HttpGet]
	[Route("GetSummaryDetail/{strStockSympol}")]
	public IActionResult GetSummaryDetail(string strStockSympol)
	{
		SummaryDetailDto summaryDetail = EquityServices.GetSummaryDetail(strStockSympol);

		return Ok(summaryDetail);
	}

	[HttpGet]
	[Route("GetFundOwnership/{strStockSympol}")]
	public IActionResult GetFundOwnership(string strStockSympol)
	{
		FundOwnershipDto fundOwnership = EquityServices.GetFundOwnership(strStockSympol);

		return Ok(fundOwnership);
	}

	[HttpGet]
	[Route("GetInsiderHolders/{strStockSympol}")]
	public IActionResult GetInsiderHolders(string strStockSympol)
	{
		InsiderHoldersDto insiderHolders = EquityServices.GetInsiderHolders(strStockSympol);

		return Ok(insiderHolders);
	}

	[HttpGet]
	[Route("GetInsiderTransactions/{strStockSympol}")]
	public IActionResult GetInsiderTransactions(string strStockSympol)
	{
		InsiderTransactionsDto insiderTransactions = EquityServices.GetInsiderTransactions(strStockSympol);

		return Ok(insiderTransactions);
	}

	[HttpGet]
	[Route("GetRecommendationTrend/{strStockSympol}")]
	public IActionResult GetRecommendationTrend(string strStockSympol)
	{
		RecommendationTrendDto recommendationTrend = EquityServices.GetRecommendationTrend(strStockSympol);

		return Ok(recommendationTrend);
	}
	#endregion
}