using System;
using System.Collections.Generic;

namespace StockPortfolioTracker.Data.Entity;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
