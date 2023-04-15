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
    [Route("GetFinancialData/{strStockSympol}")]
    public IActionResult GetFinancialData(string strStockSympol)
    {
        FinancialData financialData = this.EquityServices.GetFinancialData(strStockSympol);

        return Ok(financialData);
    }
    #endregion
}