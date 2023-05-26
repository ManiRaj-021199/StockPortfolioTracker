using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioTracker.Common;

namespace StockStatistics.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
//[Authorize(Roles = EntityUserRoles.SUPERUSER_WITH_APPLICATION)]
public class EquityController : ControllerBase
{
    #region Fields
    private readonly IEquityFacade EquityServices;
    #endregion

    #region Constructors
    public EquityController(IEquityFacade equityServices)
    {
        EquityServices = equityServices;
    }
    #endregion

    #region Publics
    [HttpGet]
    [Route("GetAssetProfile/{strStockSympol}")]
    public IActionResult GetAssetProfile(string strStockSympol)
    {
        BaseApiResponseDto assetProfile = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.AssetProfile);

        return Ok(assetProfile);
    }

    [HttpGet]
    [Route("GetCalendarEvents/{strStockSympol}")]
    public IActionResult GetCalendarEvents(string strStockSympol)
    {
        BaseApiResponseDto calendarEvents = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.CalendarEvents);

        return Ok(calendarEvents);
    }

    [HttpGet]
    [Route("GetEarnings/{strStockSympol}")]
    public IActionResult GetEarnings(string strStockSympol)
    {
        BaseApiResponseDto earnings = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.Earnings);

        return Ok(earnings);
    }

    [HttpGet]
    [Route("GetEarningsTrend/{strStockSympol}")]
    public IActionResult GetEarningsTrend(string strStockSympol)
    {
        BaseApiResponseDto earningsTrend = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.EarningsTrend);

        return Ok(earningsTrend);
    }

    [HttpGet]
    [Route("GetEsgScores/{strStockSympol}")]
    public IActionResult GetEsgScores(string strStockSympol)
    {
        BaseApiResponseDto esgScores = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.EsgScores);

        return Ok(esgScores);
    }

    [HttpGet]
    [Route("GetFinancialData/{strStockSympol}")]
    public IActionResult GetFinancialData(string strStockSympol)
    {
        BaseApiResponseDto financialData = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.FinancialData);

        return Ok(financialData);
    }

    [HttpGet]
    [Route("GetIndexTrend/{strStockSympol}")]
    public IActionResult GetIndexTrend(string strStockSympol)
    {
        BaseApiResponseDto indexTrend = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.IndexTrend);

        return Ok(indexTrend);
    }

    [HttpGet]
    [Route("GetIndustryTrend/{strStockSympol}")]
    public IActionResult GetIndustryTrend(string strStockSympol)
    {
        BaseApiResponseDto industryTrend = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.IndustryTrend);

        return Ok(industryTrend);
    }

    [HttpGet]
    [Route("GetPrice/{strStockSympol}")]
    public IActionResult GetPrice(string strStockSympol)
    {
        BaseApiResponseDto price = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.Price);

        return Ok(price);
    }

    [HttpGet]
    [Route("GetQuoteType/{strStockSympol}")]
    public IActionResult GetQuoteType(string strStockSympol)
    {
        BaseApiResponseDto quoteType = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.QuoteType);

        return Ok(quoteType);
    }

    [HttpGet]
    [Route("GetSummaryDetail/{strStockSympol}")]
    public IActionResult GetSummaryDetail(string strStockSympol)
    {
        BaseApiResponseDto summaryDetail = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.SummaryDetail);

        return Ok(summaryDetail);
    }

    [HttpGet]
    [Route("GetFundOwnership/{strStockSympol}")]
    public IActionResult GetFundOwnership(string strStockSympol)
    {
        BaseApiResponseDto fundOwnership = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.FundOwnership);

        return Ok(fundOwnership);
    }

    [HttpGet]
    [Route("GetInsiderHolders/{strStockSympol}")]
    public IActionResult GetInsiderHolders(string strStockSympol)
    {
        BaseApiResponseDto insiderHolders = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.InsiderHolders);

        return Ok(insiderHolders);
    }

    [HttpGet]
    [Route("GetInsiderTransactions/{strStockSympol}")]
    public IActionResult GetInsiderTransactions(string strStockSympol)
    {
        BaseApiResponseDto insiderTransactions = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.InsiderTransactions);

        return Ok(insiderTransactions);
    }

    [HttpGet]
    [Route("GetRecommendationTrend/{strStockSympol}")]
    public IActionResult GetRecommendationTrend(string strStockSympol)
    {
        BaseApiResponseDto recommendationTrend = EquityServices.GetDataFromYahooFinance(strStockSympol, YahooFinanceModules.RecommendationTrend);

        return Ok(recommendationTrend);
    }

    [HttpPost]
    [Route("GetSmartSearchStocks")]
    public IActionResult GetSmartSearchStocks([FromBody] SmartSearchRequestDto dtoSmartSearchRequest)
    {
        BaseApiResponseDto response = EquityServices.GetSmartSearchStocks(dtoSmartSearchRequest);

        return Ok(response);
    }
    #endregion
}