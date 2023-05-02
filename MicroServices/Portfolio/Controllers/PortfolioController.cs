using Microsoft.AspNetCore.Mvc;
using StockPortfolioTracker.Common;

namespace Portfolio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioController : ControllerBase
{
    #region Fields
    private readonly IPortfolioFacade? portfolioService;
    #endregion

    #region Constructors
    public PortfolioController(IPortfolioFacade? portfolioService)
    {
        this.portfolioService = portfolioService;
    }
    #endregion

    #region Publics
    [HttpGet]
    [Route("GetHoldingStocks/{nUserId}")]
    public async Task<BaseApiResponseDto> GetHoldingStocks(int nUserId)
    {
        BaseApiResponseDto response = await portfolioService!.GetHoldingStocks(nUserId);

        return response;
    }

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