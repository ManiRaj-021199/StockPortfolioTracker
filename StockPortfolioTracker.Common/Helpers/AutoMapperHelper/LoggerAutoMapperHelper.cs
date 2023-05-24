using StockPortfolioTracker.Data.Entity;
using StockPortfolioTracker.Logic;

namespace StockPortfolioTracker.Common;

public class LoggerAutoMapperHelper
{
    #region Publics
    public static Log ToLog(LogDto dtoLog)
    {
        Log log = AutoMapperInitializer.Mapper.Map<Log>(dtoLog);

        return log;
    }
    #endregion
}