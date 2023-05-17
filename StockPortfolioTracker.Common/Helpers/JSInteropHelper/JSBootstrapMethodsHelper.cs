using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace StockPortfolioTracker.Common;

public class JSBootstrapMethodsHelper
{
    #region Publics
    public static async Task CloseModal(IJSRuntime JSRuntime, ElementReference refElement)
    {
        await JSRuntime.InvokeVoidAsync("BootstrapMethods.CloseModal", refElement);
    }
    #endregion
}