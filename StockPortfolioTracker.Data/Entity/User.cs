using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockPortfolioTracker.Data;

public class User
{
    #region Properties
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    public int UserRoleId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public string PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime RegisterDate { get; set; }
    #endregion
}