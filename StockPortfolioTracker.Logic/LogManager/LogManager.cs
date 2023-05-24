using StockPortfolioTracker.Common;
using StockPortfolioTracker.Data.Entity;
using StockPortfolioTracker.Data.PortfolioContext;

namespace StockPortfolioTracker.Logic;

internal class LogManager
{
    #region Fields
    private readonly PortfolioTrackerDbContext dbContext;
    #endregion

    #region Constructors
    internal LogManager(PortfolioTrackerDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Internals
    internal async Task AddInfoLog(LogDto dtoLog)
    {
        try
        {
            dtoLog.Severity = LogSeverityConstants.Info;
            dtoLog.LogDate = DateTimeHelper.GetCurrentDateTime();

            Log log = LoggerAutoMapperHelper.ToLog(dtoLog);

            dbContext.Logs.Add(log);
            await dbContext.SaveChangesAsync();
        }
        catch(Exception err)
        {
            await LogError(dtoLog.Request, err);
        }
    }

    internal async Task AddInfoLog(LogDto dtoLog, object response)
    {
        try
        {
            dtoLog.Response = TypeCastingHelper.ConvertObjectToString(response);
            dtoLog.Severity = LogSeverityConstants.Info;
            dtoLog.LogDate = DateTimeHelper.GetCurrentDateTime();

            Log log = LoggerAutoMapperHelper.ToLog(dtoLog);

            dbContext.Logs.Add(log);
            await dbContext.SaveChangesAsync();
        }
        catch(Exception err)
        {
            await LogError(dtoLog.Request, err);
        }
    }

    internal async Task AddWarningLog(LogDto dtoLog)
    {
        try
        {
            dtoLog.Severity = LogSeverityConstants.Warning;
            dtoLog.LogDate = DateTimeHelper.GetCurrentDateTime();

            Log log = LoggerAutoMapperHelper.ToLog(dtoLog);

            dbContext.Logs.Add(log);
            await dbContext.SaveChangesAsync();
        }
        catch(Exception err)
        {
            await LogError(dtoLog.Request, err);
        }
    }

    internal async Task AddWarningLog(LogDto dtoLog, object response)
    {
        try
        {
            dtoLog.Response = TypeCastingHelper.ConvertObjectToString(response);
            dtoLog.Severity = LogSeverityConstants.Warning;
            dtoLog.LogDate = DateTimeHelper.GetCurrentDateTime();

            Log log = LoggerAutoMapperHelper.ToLog(dtoLog);

            dbContext.Logs.Add(log);
            await dbContext.SaveChangesAsync();
        }
        catch(Exception err)
        {
            await LogError(dtoLog.Request, err);
        }
    }

    internal async Task AddErrorLog(LogDto dtoLog, Exception exception)
    {
        try
        {
            dtoLog.Severity = LogSeverityConstants.Error;
            dtoLog.Response = TypeCastingHelper.ConvertObjectToString(exception);
            dtoLog.LogDate = DateTimeHelper.GetCurrentDateTime();

            Log log = LoggerAutoMapperHelper.ToLog(dtoLog);

            dbContext.Logs.Add(log);
            await dbContext.SaveChangesAsync();
        }
        catch(Exception err)
        {
            await LogError(dtoLog.Request, err);
        }
    }
    #endregion

    #region Privates
    private async Task LogError(string strRequest, Exception exception)
    {
        try
        {
            Log log = new()
                      {
                          PageId = PagesListConstants.LogsId,
                          Severity = LogSeverityConstants.Error,
                          Request = strRequest,
                          Response = TypeCastingHelper.ConvertObjectToString(exception),
                          LogDate = DateTimeHelper.GetCurrentDateTime()
                      };

            dbContext.Logs.Add(log);
            await dbContext.SaveChangesAsync();
        }
        catch
        {
            // ignored
        }
    }
    #endregion
}