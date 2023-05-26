namespace StockPortfolioTracker.Common;

public class UserUpdateDto
{
    #region Properties
    public int UserId { get; set; }
    public int UserRoleId { get; set; }
    public int BranchId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    #endregion
}