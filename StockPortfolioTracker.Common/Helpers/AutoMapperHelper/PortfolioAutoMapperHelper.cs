using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.Entity;

namespace StockPortfolioTracker.Logic;

public class PortfolioAutoMapperHelper
{
    #region Publics
    public static Holding ToHolding(PortfolioStockDto portfolioStockDto)
    {
        Holding portfolioStock = AutoMapperInitializer.Mapper.Map<Holding>(portfolioStockDto);

        return portfolioStock;
    }

    public static Transaction ToTransaction(PortfolioTransactionDto portfolioTransactionDto)
    {
        Transaction portfolioTransaction = AutoMapperInitializer.Mapper.Map<Transaction>(portfolioTransactionDto);

        return portfolioTransaction;
    }
    #endregion
}