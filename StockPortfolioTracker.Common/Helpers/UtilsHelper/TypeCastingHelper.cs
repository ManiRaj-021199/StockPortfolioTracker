using System.Globalization;
using Newtonsoft.Json;

namespace StockPortfolioTracker.Common;

public class TypeCastingHelper
{
    #region Publics
    public static string ConvertToMoney(double dValue, string strCurrency)
    {
        return string.Format(new CultureInfo(strCurrency), "{0:C}", dValue);
    }

    public static string ConvertObjectToString(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
    #endregion
}