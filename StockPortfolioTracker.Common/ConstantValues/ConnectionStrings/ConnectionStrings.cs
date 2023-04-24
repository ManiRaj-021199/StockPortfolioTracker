namespace StockPortfolioTracker.Common;

public static class ConnectionStrings
{
    #region Constants
    public static readonly string DbConnectionString = $"Server={EntityConstants.Server};Database={EntityConstants.InitialCatelog};Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;";
    #endregion
}