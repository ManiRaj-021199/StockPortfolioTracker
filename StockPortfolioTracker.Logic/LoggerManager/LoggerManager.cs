using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.Entity;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

internal class LoggerManager
{
    #region Fields
    private readonly PortfolioTrackerDbContext dbContext;
    #endregion

    #region Constructors
    internal LoggerManager(PortfolioTrackerDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Internals
    internal async Task CreateNewLog(LoggerDto dtoLogger)
    {
        try
        {
            Log log = LoggerAutoMapperHelper.ToLog(dtoLogger);

            dbContext.Logs.Add(log);
            await dbContext.SaveChangesAsync();
        }
        catch(Exception err)
        {
            Log log = new()
                      {
                          PageId = PagesListConstants.LogsId,
                          Severity = LogSeverityConstants.Error,
                          Request = dtoLogger.Request,
                          Response = TypeCastingHelper.ConvertObjectToString(err)
                      };

            dbContext.Logs.Add(log);
            await dbContext.SaveChangesAsync();
        }
    }
    #endregion
}