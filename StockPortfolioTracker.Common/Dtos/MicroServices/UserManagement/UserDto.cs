namespace StockPortfolioTracker.Common;

public class UserDto
{
    #region Properties
    public int? UserRoleId { get; set; }
    public string? UserRole { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    #endregion
}