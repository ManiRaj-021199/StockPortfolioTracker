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
    public async Task<BaseApiResponseDto> GetHoldingStocks(int nUserId)
    {
        BaseApiResponseDto response = await blPortfolio.GetHoldingStocks(nUserId);

        return response;
    }

    public async Task<BaseApiResponseDto> AddStockToPortfolio(PortfolioStockDto portfolioStockDto, string strUserToken)
    {
        BaseApiResponseDto response = await blPortfolio.AddStockToPortfolio(portfolioStockDto, strUserToken);

        return response;
    }

    public async Task<BaseApiResponseDto> SellStockFromPortfolio(PortfolioTransactionDto transactionDto)
    {
        BaseApiResponseDto response = await blPortfolio.SellStockFromPortfolio(transactionDto);

        return response;
    }
    #endregion
}