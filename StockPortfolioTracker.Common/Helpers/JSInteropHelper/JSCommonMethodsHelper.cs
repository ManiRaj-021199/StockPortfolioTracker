using Microsoft.JSInterop;

namespace StockPortfolioTracker.Common;

public class JSCommonMethodsHelper
{
    #region Publics
    public static async Task RefreshPage(IJSRuntime JSRuntime)
    {
        await JSRuntime.InvokeVoidAsync("CommonMethods.RefreshPage");
    }

    public static async Task ChangeInnerHtml(IJSRuntime JSRuntime, string strElementId, string strValue)
    {
        await JSRuntime.InvokeVoidAsync("CommonMethods.ChangeInnerHtml", strElementId, strValue);
    }
    #endregion
}