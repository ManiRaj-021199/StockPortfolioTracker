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

    [Parameter]
    public EventCallback UpdatePortfolio { get; set; }

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

        await HttpClientHelper.MakeApiRequest(PortfolioEndPoints.AddStockToPortfolio, HttpMethods.Post, this.UserAccessToken!, this.StockNeedToAdd);

        this.StockNeedToAdd = new PortfolioStockDto();
        await CloseModal(RefToAddStockModal);
        await this.UpdatePortfolio.InvokeAsync();
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

    private async Task CloseModal(ElementReference refElement)
    {
        await this.JSRuntime!.InvokeVoidAsync("BootstrapMethods.CloseModal", refElement);
    }
    #endregion
}