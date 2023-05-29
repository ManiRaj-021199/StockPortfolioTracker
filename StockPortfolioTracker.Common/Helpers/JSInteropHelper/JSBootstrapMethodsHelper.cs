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

    public static async Task MakeModalDraggable(IJSRuntime JSRuntime)
    {
        await JSRuntime.InvokeVoidAsync("BootstrapMethods.MakeModalDraggable");
    }

    public static async Task UpdateSmartSearch(IJSRuntime JSRuntime, ElementReference refElement, SmartSearchResponseDto dtoSmartSearchResponse, string strResultInputId)
    {
        await JSRuntime.InvokeVoidAsync("AutoCompleteSmartSearch", refElement, dtoSmartSearchResponse, strResultInputId);
    }
    #endregion
}