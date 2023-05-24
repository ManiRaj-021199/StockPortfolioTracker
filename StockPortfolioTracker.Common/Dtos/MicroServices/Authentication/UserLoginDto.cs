namespace StockPortfolioTracker.Common;

public class UserLoginDto
{
    #region Properties
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? SecretKey { get; set; }
    #endregion
}