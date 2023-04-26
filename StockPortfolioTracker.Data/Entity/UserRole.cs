using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockPortfolioTracker.Data;

public class UserRole
{
    #region Properties
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int RoleId { get; set; }

    public string RoleName { get; set; }
    #endregion
}