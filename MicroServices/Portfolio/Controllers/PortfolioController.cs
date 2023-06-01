using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioTracker.Common;

namespace Portfolio.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = EntityUserRoles.APPLICATION)]
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
    [Route("GetAllPortfolioCategories/{nUserId}")]
    public async Task<BaseApiResponseDto> GetAllPortfolioCategories(int nUserId)
    {
        BaseApiResponseDto response = await portfolioService!.GetAllPortfolioCategories(nUserId);

        return response;
    }

    [HttpPost]
    [Route("GetHoldingStocks")]
    public async Task<BaseApiResponseDto> GetHoldingStocks([FromBody] PortfolioCategoryDto dtoPortfolioCategory)
    {
        BaseApiResponseDto response = await portfolioService!.GetHoldingStocks(dtoPortfolioCategory);

        return response;
    }

    [HttpPost]
    [Route("AddNewPortfolioCategory")]
    public async Task<BaseApiResponseDto> AddNewPortfolioCategory([FromBody] PortfolioCategoryDto dtoPortfolioCategory)
    {
        BaseApiResponseDto response = await portfolioService!.AddNewPortfolioCategory(dtoPortfolioCategory);

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

    [HttpPut]
    [Route("UpdatePortfolioCategoryName")]
    public async Task<BaseApiResponseDto> UpdatePortfolioCategoryName([FromBody] PortfolioCategoryDto dtoPortfolioCategory)
    {
        BaseApiResponseDto response = await portfolioService!.UpdatePortfolioCategoryName(dtoPortfolioCategory);

        return response;
    }

    [HttpDelete]
    [Route("DeletePortfolioCategory")]
    public async Task<BaseApiResponseDto> DeletePortfolioCategory([FromBody] PortfolioCategoryDto dtoPortfolioCategory)
    {
        BaseApiResponseDto response = await portfolioService!.DeletePortfolioCategory(dtoPortfolioCategory);

        return response;
    }
    #endregion
}