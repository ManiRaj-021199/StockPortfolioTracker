using System.Net;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Web.Components;

public class AddNewPortfolioCategoryBase : ComponentBase
{
    #region Fields
    protected ElementReference RefToAddCategoryModal;
    #endregion

    #region Properties
    [Parameter]
    public int UserId { get; set; }

    [Inject]
    public ISessionStorageService? SessionStorageService { get; set; }

    protected string? ErrorMessage { get; set; }
    protected PortfolioCategoryDto? CategoryNeedToAdd { get; set; }

    [Inject]
    private IJSRuntime? JSRuntime { get; set; }
    #endregion

    #region Protecteds
    protected override void OnInitialized()
    {
        InitializeProperties();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await InitializePageActions();
    }

    protected async Task AddPortfolioCategoryAsync()
    {
        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(PortfolioEndPoints.AddNewPortfolioCategory, HttpMethods.Post, this.CategoryNeedToAdd!);

        if(apiResponse.ResponseCode == HttpStatusCode.OK)
        {
            KeyValuePair<int, string> kvpCurrentCategory = JsonConvert.DeserializeObject<KeyValuePair<int, string>>(TypeCastingHelper.ConvertObjectToString(apiResponse.Result!));

            if(!string.IsNullOrEmpty(kvpCurrentCategory.Value))
            {
                await this.SessionStorageService!.SetItemAsync("current-portfolio-category", kvpCurrentCategory);
                await JSCommonMethodsHelper.ChangeInnerHtml(this.JSRuntime!, "portfolioCategoryName", kvpCurrentCategory.Value);
            }

            await JSBootstrapMethodsHelper.CloseModal(this.JSRuntime!, RefToAddCategoryModal);
            await JSCommonMethodsHelper.RefreshPage(this.JSRuntime!);
        }
        else
        {
            this.ErrorMessage = apiResponse.ResponseMessage;
        }
    }
    #endregion

    #region Privates
    private void InitializeProperties()
    {
        this.CategoryNeedToAdd = new PortfolioCategoryDto { UserId = this.UserId };
    }

    private async Task InitializePageActions()
    {
        await JSBootstrapMethodsHelper.MakeModalDraggable(this.JSRuntime!);
    }
    #endregion
}