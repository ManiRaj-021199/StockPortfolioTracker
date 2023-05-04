using System.Globalization;

namespace StockPortfolioTracker.Common;

public class TypeCastingHelper
{
    #region Publics
    public static string ConvertToMoney(double dValue, string strCurrency)
    {
        return string.Format(new CultureInfo(strCurrency), "{0:C}", dValue);
    }
    #endregion
}