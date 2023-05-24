namespace StockPortfolioTracker.Common;

public class UserManagementEndPoints
{
    #region Constants
    public static readonly string GetUserByEmail = ApiEndPoints.UserManagementBaseUrl + "/GetUserByEmail/{0}";
    public static readonly string GetUserByUserId = ApiEndPoints.UserManagementBaseUrl + "/GetUserByUserId/{0}";

    public static readonly string GetClientByEmail = ApiEndPoints.ClientManagementBaseUrl + "/GetClientByEmail/{0}";
    #endregion
}