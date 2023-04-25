using Microsoft.AspNetCore.Mvc;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Logic;

namespace Portfolio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioController : ControllerBase
{
    #region Fields
    private readonly IPortfolioService? portfolioService;
    #endregion

    #region Constructors
    public PortfolioController(IPortfolioService? portfolioService)
    {
        this.portfolioService = portfolioService;
    }
    #endregion

    #region Publics
    [HttpPost]
    [Route("AddStockToPortfolio")]
    public async Task<BaseApiResponseDto> AddStockToPortfolio([FromBody] PortfolioStockDto portfolioStockDto)
    {
        BaseApiResponseDto response = await portfolioService!.AddStockToPortfolio(portfolioStockDto);

        return response;
    }

    [HttpPost]
    [Route("SellStockFromPortfolio")]
    public async Task<BaseApiResponseDto> SellStockFromPortfolio([FromBody] PortfolioTransactionDto transactionDto)
    {
        BaseApiResponseDto response = await portfolioService!.SellStockFromPortfolio(transactionDto);

        return response;
    }
    #endregion
}