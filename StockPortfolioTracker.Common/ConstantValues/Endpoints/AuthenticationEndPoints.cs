namespace StockPortfolioTracker.Common;

public class AuthenticationEndPoints
{
    #region Constants
    public static readonly string RegisterUser = $"{ApiEndPoints.AuthenticationBaseUrl}/RegisterUser";
    public static readonly string LoginUser = $"{ApiEndPoints.AuthenticationBaseUrl}/LoginUser";
    #endregion
}