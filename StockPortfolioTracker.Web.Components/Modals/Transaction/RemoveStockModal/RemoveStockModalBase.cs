using System.Net;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Web.Components;

public class RemoveStockModalBase : ComponentBase
{
    #region Fields
    protected ElementReference RefToRemoveStockModal;
    protected ElementReference RefToSmartSearch;
    #endregion

    #region Properties
    [Parameter]
    public int UserId { get; set; }

    [Parameter]
    public List<HoldingStockDto>? HoldingStocks { get; set; }

    [Inject]
    public ISessionStorageService? SessionStorageService { get; set; }

    protected string? ErrorMessage { get; set; }
    protected PortfolioTransactionDto? StockNeedToRemove { get; set; }
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

    protected async Task RemoveStockFromPortfolio()
    {
        KeyValuePair<int, string> kvpCurrentCategory = await this.SessionStorageService!.GetItemAsync<KeyValuePair<int, string>>("current-portfolio-category");
        this.StockNeedToRemove!.CategoryId = kvpCurrentCategory.Key;
        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(PortfolioEndPoints.RemoveStockFromPortfolio, HttpMethods.Post, this.StockNeedToRemove);

        if(apiResponse.ResponseCode == HttpStatusCode.OK)
        {
            await JSBootstrapMethodsHelper.CloseModal(this.JSRuntime!, RefToRemoveStockModal);
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

        IEnumerable<HoldingStockDto> holdingStocks = this.HoldingStocks!.Where(stock => stock.StockName!.ToLower().Contains(strValue.ToLower()) || stock.Symbol!.ToLower().Contains(strValue.ToLower())).ToList();

        this.SmartSearchStocks = new SmartSearchResponseDto
                                 {
                                     Count = holdingStocks.Count(),
                                     Quotes = new List<SmartSearchQuotesDto>()
                                 };

        foreach(HoldingStockDto holdingStock in holdingStocks)
        {
            this.SmartSearchStocks.Quotes.Add(new SmartSearchQuotesDto
                                              {
                                                  LongName = holdingStock.StockName,
                                                  ExchDisp = holdingStock.Quantity.ToString(),
                                                  Symbol = holdingStock.Symbol
                                              });
        }

        await JSBootstrapMethodsHelper.UpdateSmartSearch(this.JSRuntime!, RefToSmartSearch, this.SmartSearchStocks, "removeStockSmartSearchValue");
    }
    #endregion

    #region Privates
    private void InitializeProperties()
    {
        this.StockNeedToRemove = new PortfolioTransactionDto { UserId = this.UserId };
    }
    #endregion
}