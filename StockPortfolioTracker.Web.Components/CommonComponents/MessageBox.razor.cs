using Microsoft.AspNetCore.Components;

namespace StockPortfolioTracker.Web.Components;

public partial class MessageBox
{
    #region Properties
    [Parameter]
    public string? Message { get; set; }

    [Parameter]
    public string? MessageStyleClass { get; set; }
    #endregion
}