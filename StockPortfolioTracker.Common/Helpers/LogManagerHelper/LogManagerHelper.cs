using System.Diagnostics;
using Newtonsoft.Json;

namespace StockPortfolioTracker.Common;

public class LogManagerHelper
{
    #region Publics
    public static LogDto BuildLogDto(int nPageId, object objRequest, string strResponse)
    {
        LogDto dtoLog = new()
                        {
                            PageId = nPageId,
                            Request = TypeCastingHelper.ConvertObjectToString(objRequest),
                            Response = strResponse
                        };

        return dtoLog;
    }

    public static string GetMethodStartedMessage()
    {
        StackTrace trace = new();
        StackFrame frame = trace.GetFrame(1)!;

        string strMethodName = JsonConvert.SerializeObject(frame.GetMethod()!.DeclaringType!.UnderlyingSystemType).Split(",")[0];

        return string.Format(CommonWebServiceMessages.MethodStarted, strMethodName);
    }
    #endregion
}