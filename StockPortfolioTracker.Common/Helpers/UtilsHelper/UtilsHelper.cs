namespace StockPortfolioTracker.Common;

public class UtilsHelper
{
    #region Publics
    public static string GetCurrencyUnicode(string strCurrencySymbol)
    {
        return strCurrencySymbol switch
        {
            CurrencyConstants.INR => CurrencyConstants.INRUnicode,
            CurrencyConstants.USD => CurrencyConstants.USDUnicode,
            _ => CurrencyConstants.INRUnicode
        };
    }
    #endregion
}