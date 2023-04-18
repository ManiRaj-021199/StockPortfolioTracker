namespace StockPortfolioTracker.Common;

public static class ConnectionStrings
{
    #region Constants
    public static readonly string DbConnectionString = $"Server={EntityValues.Server};Database={EntityValues.InitialCatelog};Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;";
    #endregion
}