using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioTracker.Common;

namespace Portfolio.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = EntityUserRoles.SUPERUSER_WITH_USER)]
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
        string strUserToken = Request.Headers.Authorization.ToString().Split(" ")[1];

        BaseApiResponseDto response = await portfolioService!.AddStockToPortfolio(portfolioStockDto, strUserToken);

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