namespace StockPortfolioTracker.Data.Entity;

public static class ConnectionStrings
{
    #region Constants
    public static readonly string DbConnectionString = $"Server={EntityConstants.Server};Database={EntityConstants.InitialCatelog};Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;";

    // Run the following in the Package Manager Console for Migrate the Db
    // Scaffold-DbContext "Server=<Server Name>;Database=PortfolioTrackerDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entity -ContextDir PortfolioContext -force
    #endregion
}

public static class EntityConstants
{
    #region Constants
    public static readonly string Server = "MS-NB0101";
    public static readonly string InitialCatelog = "PortfolioTrackerDB";
    #endregion
}