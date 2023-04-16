using Microsoft.AspNetCore.Mvc;
using StockStatistics.Services;
using StockPortfolioTracker.Common;

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
        this.EquityServices = equityServices;
    }
    #endregion

    #region Publics
    [HttpGet]
    [Route("GetAssetProfile/{strStockSympol}")]
    public IActionResult GetAssetProfile(string strStockSympol)
    {
        AssetProfile assetProfile = this.EquityServices.GetAssetProfile(strStockSympol);

        return Ok(assetProfile);
    }

    [HttpGet]
    [Route("GetCalendarEvents/{strStockSympol}")]
    public IActionResult GetCalendarEvents(string strStockSympol)
    {
        CalendarEvents calendarEvents = this.EquityServices.GetCalendarEvents(strStockSympol);

        return Ok(calendarEvents);
    }

    [HttpGet]
    [Route("GetEarnings/{strStockSympol}")]
    public IActionResult GetEarnings(string strStockSympol)
    {
        Earnings earnings = this.EquityServices.GetEarnings(strStockSympol);

        return Ok(earnings);
    }

    [HttpGet]
    [Route("GetEarningsTrend/{strStockSympol}")]
    public IActionResult GetEarningsTrend(string strStockSympol)
    {
        EarningsTrend earningsTrend = this.EquityServices.GetEarningsTrend(strStockSympol);

        return Ok(earningsTrend);
    }

    [HttpGet]
    [Route("GetEsgScores/{strStockSympol}")]
    public IActionResult GetEsgScores(string strStockSympol)
    {
        EsgScores esgScores = this.EquityServices.GetEsgScores(strStockSympol);

        return Ok(esgScores);
    }

    [HttpGet]
    [Route("GetFinancialData/{strStockSympol}")]
    public IActionResult GetFinancialData(string strStockSympol)
    {
        FinancialData financialData = this.EquityServices.GetFinancialData(strStockSympol);

        return Ok(financialData);
    }

    [HttpGet]
    [Route("GetIndexTrend/{strStockSympol}")]
    public IActionResult GetIndexTrend(string strStockSympol)
    {
        IndexTrend indexTrend = this.EquityServices.GetIndexTrend(strStockSympol);

        return Ok(indexTrend);
    }

    [HttpGet]
    [Route("GetIndustryTrend/{strStockSympol}")]
    public IActionResult GetIndustryTrend(string strStockSympol)
    {
        IndustryTrend industryTrend = this.EquityServices.GetIndustryTrend(strStockSympol);

        return Ok(industryTrend);
    }

    [HttpGet]
    [Route("GetPrice/{strStockSympol}")]
    public IActionResult GetPrice(string strStockSympol)
    {
        Price price = this.EquityServices.GetPrice(strStockSympol);

        return Ok(price);
    }

    [HttpGet]
    [Route("GetQuoteType/{strStockSympol}")]
    public IActionResult GetQuoteType(string strStockSympol)
    {
        QuoteType quoteType = this.EquityServices.GetQuoteType(strStockSympol);

        return Ok(quoteType);
    }

    [HttpGet]
    [Route("GetSummaryDetail/{strStockSympol}")]
    public IActionResult GetSummaryDetail(string strStockSympol)
    {
        SummaryDetail summaryDetail = this.EquityServices.GetSummaryDetail(strStockSympol);

        return Ok(summaryDetail);
    }

    [HttpGet]
    [Route("GetSummaryProfile/{strStockSympol}")]
    public IActionResult GetSummaryProfile(string strStockSympol)
    {
        SummaryProfile summaryProfile = this.EquityServices.GetSummaryProfile(strStockSympol);

        return Ok(summaryProfile);
    }

    [HttpGet]
    [Route("GetFundOwnership/{strStockSympol}")]
    public IActionResult GetFundOwnership(string strStockSympol)
    {
        FundOwnership fundOwnership = this.EquityServices.GetFundOwnership(strStockSympol);

        return Ok(fundOwnership);
    }

    [HttpGet]
    [Route("GetInsiderHolders/{strStockSympol}")]
    public IActionResult GetInsiderHolders(string strStockSympol)
    {
        InsiderHolders insiderHolders = this.EquityServices.GetInsiderHolders(strStockSympol);

        return Ok(insiderHolders);
    }

    [HttpGet]
    [Route("GetInsiderTransactions/{strStockSympol}")]
    public IActionResult GetInsiderTransactions(string strStockSympol)
    {
        InsiderTransactions insiderTransactions = this.EquityServices.GetInsiderTransactions(strStockSympol);

        return Ok(insiderTransactions);
    }

    [HttpGet]
    [Route("GetRecommendationTrend/{strStockSympol}")]
    public IActionResult GetRecommendationTrend(string strStockSympol)
    {
        RecommendationTrend recommendationTrend = this.EquityServices.GetRecommendationTrend(strStockSympol);

        return Ok(recommendationTrend);
    }
    #endregion
}