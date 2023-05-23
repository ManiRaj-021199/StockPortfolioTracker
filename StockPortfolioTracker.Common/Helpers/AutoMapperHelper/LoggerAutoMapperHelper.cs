using StockPortfolioTracker.Data.Entity;
using StockPortfolioTracker.Logic;

namespace StockPortfolioTracker.Common;

public class LoggerAutoMapperHelper
{
    #region Publics
    public static Log ToLog(LoggerDto dtoLogger)
    {
        Log log = AutoMapperInitializer.Mapper.Map<Log>(dtoLogger);

        return log;
    }
    #endregion
}