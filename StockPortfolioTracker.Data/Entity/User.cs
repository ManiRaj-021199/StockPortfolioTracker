using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockPortfolioTracker.Data;

[Table("Users", Schema = "User")]
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

    public ICollection<PortfolioStock>? PortfolioStocks { get; set; }
    #endregion
}