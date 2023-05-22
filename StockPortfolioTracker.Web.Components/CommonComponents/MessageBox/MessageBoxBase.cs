using Microsoft.AspNetCore.Components;

namespace StockPortfolioTracker.Web.Components;

public class MessageBoxBase : ComponentBase
{
    #region Properties
    [Parameter]
    public string? Message { get; set; }

    [Parameter]
    public string? MessageStyleClass { get; set; }
    #endregion
}