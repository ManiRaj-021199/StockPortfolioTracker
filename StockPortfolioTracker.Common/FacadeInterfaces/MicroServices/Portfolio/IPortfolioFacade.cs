namespace StockPortfolioTracker.Common;

public interface IPortfolioFacade
{
    public Task<BaseApiResponseDto> GetHoldingStocks(int nUserId);
    public Task<BaseApiResponseDto> AddStockToPortfolio(PortfolioStockDto portfolioStockDto, string strUserToken);
    public Task<BaseApiResponseDto> SellStockFromPortfolio(PortfolioTransactionDto transactionDto);
}