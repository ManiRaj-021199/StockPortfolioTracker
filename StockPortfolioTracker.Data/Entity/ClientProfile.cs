using System;
using System.Collections.Generic;

namespace StockPortfolioTracker.Data.Entity;

public partial class ClientProfile
{
    public int ClientProfileId { get; set; }

    public int ClientRoleId { get; set; }

    public string ClientName { get; set; } = null!;

    public string ClientEmail { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public DateTime RegisterDate { get; set; }

    public virtual UserRole ClientRole { get; set; } = null!;
}
