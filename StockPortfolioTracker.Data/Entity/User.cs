using System.ComponentModel.DataAnnotations;

namespace StockPortfolioTracker.Data;

public class User
{
    #region Properties
    [Key]
    public int UserId { get; set; }
    public int? UserRoleId { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    #endregion
}