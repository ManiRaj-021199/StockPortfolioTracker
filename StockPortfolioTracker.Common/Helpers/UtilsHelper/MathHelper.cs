namespace StockPortfolioTracker.Common;

public class MathHelper
{
    #region Publics
    public static double GetTwoPrecisionDouble(double dValue)
    {
        return Math.Round(dValue, 2);
    }
    #endregion
}