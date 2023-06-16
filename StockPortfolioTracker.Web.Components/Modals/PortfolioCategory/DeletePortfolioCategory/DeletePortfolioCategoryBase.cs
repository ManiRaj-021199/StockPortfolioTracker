using System.Net;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Web.Components;

public class DeletePortfolioCategoryBase : ComponentBase
{
    #region Fields
    protected ElementReference RefToDeleteCategoryModal;
    #endregion

    #region Properties
    public string? ErrorMessage { get; set; }
    public PortfolioCategoryDto? CategoryNeedToDelete { get; set; }

    [Parameter]
    public int UserId { get; set; }

    [Inject]
    public ISessionStorageService? SessionStorageService { get; set; }

    [Inject]
    private IJSRuntime? JSRuntime { get; set; }
    #endregion

    #region Protecteds
    protected override void OnInitialized()
    {
        InitializeProperties();
    }

    protected async Task DeletePortfolioCategoryAsync()
    {
        KeyValuePair<int, string> kvpCurrentCategory = await this.SessionStorageService!.GetItemAsync<KeyValuePair<int, string>>("current-portfolio-category");

        this.CategoryNeedToDelete = new PortfolioCategoryDto
                                    {
                                        UserId = this.UserId,
                                        CategoryId = kvpCurrentCategory.Key,
                                        CategoryName = kvpCurrentCategory.Value
                                    };

        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(PortfolioEndPoints.DeletePortfolioCategory, HttpMethods.Delete, this.CategoryNeedToDelete!);

        if(apiResponse.ResponseCode == HttpStatusCode.OK)
        {
            await this.SessionStorageService.RemoveItemAsync("current-portfolio-category");

            await JSBootstrapMethodsHelper.CloseModal(this.JSRuntime!, RefToDeleteCategoryModal);
            await JSCommonMethodsHelper.RefreshPage(this.JSRuntime!);
        }
        else this.ErrorMessage = apiResponse.ResponseMessage;
    }
    #endregion

    #region Privates
    private void InitializeProperties()
    {
        this.CategoryNeedToDelete = new PortfolioCategoryDto();
    }
    #endregion
}