using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

public class PortfolioFacade : IPortfolioFacade
{
    #region Fields
    private readonly PortfolioBL blPortfolio;
    #endregion

    #region Constructors
    public PortfolioFacade(PortfolioTrackerDbContext dbContext)
    {
        blPortfolio = new PortfolioBL(dbContext);
    }
    #endregion

    #region Publics
    public async Task<BaseApiResponseDto> GetAllPortfolioCategories(int nUserId)
    {
        BaseApiResponseDto response = await blPortfolio.GetAllPortfolioCategories(nUserId);

        return response;
    }

    public async Task<BaseApiResponseDto> GetHoldingStocks(PortfolioCategoryDto dtoPortfolioCategory)
    {
        BaseApiResponseDto response = await blPortfolio.GetHoldingStocks(dtoPortfolioCategory);

        return response;
    }

    public async Task<BaseApiResponseDto> AddNewPortfolioCategory(PortfolioCategoryDto dtoPortfolioCategory)
    {
        BaseApiResponseDto response = await blPortfolio.AddNewPortfolioCategory(dtoPortfolioCategory);

        return response;
    }

    public async Task<BaseApiResponseDto> AddStockToPortfolio(PortfolioStockDto portfolioStockDto)
    {
        BaseApiResponseDto response = await blPortfolio.AddStockToPortfolio(portfolioStockDto);

        return response;
    }

    public async Task<BaseApiResponseDto> SellStockFromPortfolio(PortfolioTransactionDto transactionDto)
    {
        BaseApiResponseDto response = await blPortfolio.SellStockFromPortfolio(transactionDto);

        return response;
    }

    public async Task<BaseApiResponseDto> UpdatePortfolioCategoryName(PortfolioCategoryDto dtoPortfolioCategory)
    {
        BaseApiResponseDto response = await blPortfolio.UpdatePortfolioCategoryName(dtoPortfolioCategory);

        return response;
    }

    public async Task<BaseApiResponseDto> DeletePortfolioCategory(PortfolioCategoryDto dtoPortfolioCategory)
    {
        BaseApiResponseDto response = await blPortfolio.DeletePortfolioCategory(dtoPortfolioCategory);

        return response;
    }
    #endregion
}