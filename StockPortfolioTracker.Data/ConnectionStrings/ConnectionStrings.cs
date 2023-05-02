namespace StockPortfolioTracker.Data;

public static class ConnectionStrings
{
    #region Constants
    public static readonly string DbConnectionString = $"Server={EntityConstants.Server};Database={EntityConstants.InitialCatelog};Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;";
    #endregion
}

public static class EntityConstants
{
    #region Constants
    public static readonly string Server = "MS-NB0101";
    public static readonly string InitialCatelog = "PortfolioTrackerDB";
    #endregion
}