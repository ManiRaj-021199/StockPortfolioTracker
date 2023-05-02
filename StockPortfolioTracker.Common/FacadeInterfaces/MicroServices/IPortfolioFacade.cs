namespace StockPortfolioTracker.Common;

public interface IPortfolioFacade
{
    public Task<BaseApiResponseDto> AddStockToPortfolio(PortfolioStockDto portfolioStockDto);
    public Task<BaseApiResponseDto> SellStockFromPortfolio(PortfolioTransactionDto transactionDto);
}