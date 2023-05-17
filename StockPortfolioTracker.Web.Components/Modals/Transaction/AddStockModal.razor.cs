using System.Net;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Radzen;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Web.Components;

public partial class AddStockModal
{
    #region Fields
    private ElementReference RefToAddStockModal;
    #endregion

    #region Properties
    [Parameter]
    public int UserId { get; set; }

    [Parameter]
    public string? UserAccessToken { get; set; }

    [Inject]
    private IJSRuntime? JSRuntime { get; set; }

    private PortfolioStockDto? StockNeedToAdd { get; set; }
    private SmartSearchResponseDto? SmartSearchStocks { get; set; }
    #endregion

    #region Protecteds
    protected override void OnInitialized()
    {
        InitializeProperties();
    }
    #endregion

    #region Privates
    private void InitializeProperties()
    {
        this.SmartSearchStocks = new SmartSearchResponseDto();
        this.StockNeedToAdd = new PortfolioStockDto();
    }

    private async Task AddStockToPortfolio()
    {
        this.StockNeedToAdd!.UserId = this.UserId;

        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(PortfolioEndPoints.AddStockToPortfolio, HttpMethods.Post, this.UserAccessToken!, this.StockNeedToAdd);

        await JSBootstrapMethodsHelper.CloseModal(this.JSRuntime!, RefToAddStockModal);

        if(apiResponse.ResponseCode == HttpStatusCode.OK)
        {
            this.StockNeedToAdd = new PortfolioStockDto();
            await JSCommonMethodsHelper.RefreshPage(this.JSRuntime!);
        }
    }

    private async Task StockSmartSearch(LoadDataArgs args)
    {
        if(args.Filter.Length < 3) return;

        SmartSearchRequestDto request = new()
                                        {
                                            StocksCount = 3,
                                            NewsCount = 0,
                                            SearchQuery = args.Filter
                                        };
        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(StockStatisticEndPoints.GetSmartSearchStocks, HttpMethods.Post, this.UserAccessToken!, request);
        this.SmartSearchStocks = JsonConvert.DeserializeObject<SmartSearchResponseDto>(apiResponse.Result!.ToString()!)!;
    }
    #endregion
}