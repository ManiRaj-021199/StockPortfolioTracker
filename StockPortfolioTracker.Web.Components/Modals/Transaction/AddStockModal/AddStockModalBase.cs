using System.Net;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Web.Components;

public class AddStockModalBase : ComponentBase
{
    #region Fields
    protected ElementReference RefToAddStockModal;
    protected ElementReference RefToSmartSearch;
    #endregion

    #region Properties
    [Parameter]
    public int UserId { get; set; }

    protected string? ErrorMessage { get; set; }
    protected PortfolioStockDto? StockNeedToAdd { get; set; }
    protected SmartSearchResponseDto? SmartSearchStocks { get; set; }

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
        await JSBootstrapMethodsHelper.MakeModalDraggable(this.JSRuntime!);
    }

    protected async Task AddStockToPortfolio()
    {
        this.StockNeedToAdd!.UserId = this.UserId;

        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(PortfolioEndPoints.AddStockToPortfolio, HttpMethods.Post, this.StockNeedToAdd);

        if(apiResponse.ResponseCode == HttpStatusCode.OK)
        {
            await JSBootstrapMethodsHelper.CloseModal(this.JSRuntime!, RefToAddStockModal);
            await JSCommonMethodsHelper.RefreshPage(this.JSRuntime!);
        }
        else
        {
            this.ErrorMessage = apiResponse.ResponseMessage;
        }
    }

    protected async void StockSmartSearch(ChangeEventArgs args)
    {
        string strValue = args.Value!.ToString()!;

        if(string.IsNullOrEmpty(strValue) || strValue.Length < 3) return;

        SmartSearchRequestDto request = new()
                                        {
                                            StocksCount = 3,
                                            NewsCount = 0,
                                            SearchQuery = strValue
                                        };

        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(StockStatisticEndPoints.GetSmartSearchStocks, HttpMethods.Post, request);
        this.SmartSearchStocks = JsonConvert.DeserializeObject<SmartSearchResponseDto>(apiResponse.Result!.ToString()!)!;

        await JSBootstrapMethodsHelper.UpdateSmartSearch(this.JSRuntime!, RefToSmartSearch, this.SmartSearchStocks!);
    }
    #endregion

    #region Privates
    private void InitializeProperties()
    {
        this.SmartSearchStocks = new SmartSearchResponseDto();
        this.StockNeedToAdd = new PortfolioStockDto();
    }
    #endregion
}