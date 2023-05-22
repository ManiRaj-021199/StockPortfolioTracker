using Microsoft.JSInterop;

namespace StockPortfolioTracker.Common;

public class JSCommonMethodsHelper
{
    #region Publics
    public static async Task RefreshPage(IJSRuntime JSRuntime)
    {
        await JSRuntime.InvokeVoidAsync("CommonMethods.RefreshPage");
    }
    #endregion
}