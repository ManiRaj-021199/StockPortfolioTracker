namespace StockPortfolioTracker.Common;

public class ClientDto
{
    #region Properties
    public string? ClientName { get; set; }
    public string? ClientEmail { get; set; }
    public string? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    #endregion
}