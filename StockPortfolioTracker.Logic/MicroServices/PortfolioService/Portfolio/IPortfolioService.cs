using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Logic;

public interface IPortfolioService
{
    public Task<BaseApiResponseDto> AddStockToPortfolio(PortfolioStockDto portfolioStockDto);
    public Task<BaseApiResponseDto> SellStockFromPortfolio(PortfolioTransactionDto transactionDto);
}