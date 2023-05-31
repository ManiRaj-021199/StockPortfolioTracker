namespace StockPortfolioTracker.Common;

public interface IPortfolioFacade
{
    public Task<BaseApiResponseDto> GetAllPortfolioCategories(int nUserId);
    public Task<BaseApiResponseDto> GetHoldingStocks(PortfolioCategoryDto dtoPortfolioCategory);
    public Task<BaseApiResponseDto> AddNewPortfolioCategory(PortfolioCategoryDto dtoPortfolioCategory);
    public Task<BaseApiResponseDto> AddStockToPortfolio(PortfolioStockDto portfolioStockDto);
    public Task<BaseApiResponseDto> SellStockFromPortfolio(PortfolioTransactionDto transactionDto);
    public Task<BaseApiResponseDto> UpdatePortfolioCategoryName(PortfolioCategoryDto dtoPortfolioCategory);
    public Task<BaseApiResponseDto> DeletePortfolioCategory(PortfolioCategoryDto dtoPortfolioCategory);
}