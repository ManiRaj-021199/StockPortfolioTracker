namespace StockPortfolioTracker.Common;

public class LoggerManagerHelper
{
    #region Publics
    public static LoggerDto BuildLoggerDto(int nPageId, string strSeverity, string strRequest, string strResponse)
    {
        LoggerDto dtoLogger = new()
                              {
                                  PageId = nPageId,
                                  Severity = strSeverity,
                                  Request = strRequest,
                                  Response = strResponse
                              };

        return dtoLogger;
    }

    public static string LogMethodStarted(string strMethodName)
    {
        return string.Format(CommonWebServiceMessages.MethodStarted, strMethodName);
    }
    #endregion
}