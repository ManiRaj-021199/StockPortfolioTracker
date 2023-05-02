using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data;

namespace StockPortfolioTracker.Logic;

public class PortfolioAutoMapperHelper
{
    #region Publics
    public static PortfolioStock ToPortfolioStock(PortfolioStockDto portfolioStockDto)
    {
        PortfolioStock portfolioStock = AutoMapperInitializer.Mapper.Map<PortfolioStock>(portfolioStockDto);

        return portfolioStock;
    }

    public static PortfolioTransaction ToPortfolioTransaction(PortfolioTransactionDto portfolioTransactionDto)
    {
        PortfolioTransaction portfolioTransaction = AutoMapperInitializer.Mapper.Map<PortfolioTransaction>(portfolioTransactionDto);

        return portfolioTransaction;
    }
    #endregion
}