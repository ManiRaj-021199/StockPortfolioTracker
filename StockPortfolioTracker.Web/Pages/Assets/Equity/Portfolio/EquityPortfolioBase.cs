using System.Net;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;
using HttpMethods = Microsoft.AspNetCore.Http.HttpMethods;

namespace StockPortfolioTracker.Web;

public class EquityPortfolioBase : ComponentBase
{
    #region Fields
    public int nUserId = -1;
    public int nCategoryId = -1;

    public string? strCategoryName = string.Empty;
    public string? strMessage = string.Empty;

    protected ElementReference RefToCategoryId;

    protected readonly GridSort<HoldingStockDto> SortByStockName = GridSort<HoldingStockDto>.ByDescending(x => x.StockName);
    protected readonly GridSort<HoldingStockDto> SortByStockQuantity = GridSort<HoldingStockDto>.ByDescending(x => x.Quantity);
    protected readonly GridSort<HoldingStockDto> SortByStockInvestment = GridSort<HoldingStockDto>.ByDescending(x => x.InvestedValue);
    protected readonly GridSort<HoldingStockDto> SortByStockChange = GridSort<HoldingStockDto>.ByDescending(x => x.TodayChangePercentage);
    protected readonly GridSort<HoldingStockDto> SortByStockCurrentValue = GridSort<HoldingStockDto>.ByDescending(x => x.CurrentValue);
    protected readonly GridSort<HoldingStockDto> SortByStockPL = GridSort<HoldingStockDto>.ByDescending(x => x.ProfitOrLossAmount);
    protected readonly GridSort<HoldingStockDto> SortByStockPLPercentage = GridSort<HoldingStockDto>.ByDescending(x => x.ProfitOrLossPercentage);
    #endregion

    #region Properties
    [Inject]
    public AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

    [Inject]
    public ISessionStorageService? SessionStorageService { get; set; }

    [Inject]
    private IJSRuntime? JSRuntime { get; set; }

    public List<KeyValuePair<int, string>>? PortfolioStockCategories { get; set; }
    public List<PortfolioStockDto>? PortfolioStocks { get; set; }
    public List<HoldingStockDto>? HoldingStocks { get; set; }
    #endregion

    #region Protecteds
    protected override async Task OnInitializedAsync()
    {
        await InitializeProperties();
        await InitializePageActions();

        /*
        // Update price every 1 sec

        _ = new Timer(async _ =>
                      {
                          await UpdatePortfolio();

                          await InvokeAsync(StateHasChanged);
                      }, null, 0, 1000);
        */
    }

    protected async Task GetHoldingStocks(int nCategoryID, string strCategoryName)
    {
        PortfolioCategoryDto dtoPortfolioCategory = new()
                                                    {
                                                        CategoryId = nCategoryID,
                                                        CategoryName = strCategoryName,
                                                        UserId = nUserId
                                                    };

        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(PortfolioEndPoints.GetHoldingStocks, HttpMethods.Post, dtoPortfolioCategory);

        if(apiResponse.ResponseCode == HttpStatusCode.OK)
        {
            this.PortfolioStocks = JsonConvert.DeserializeObject<List<PortfolioStockDto>>(TypeCastingHelper.ConvertObjectToString(apiResponse.Result!));

            await UpdateUserHoldings();
            StateHasChanged();

            KeyValuePair<int, string> kvpCurrentCategory = new(nCategoryID, strCategoryName);

            await this.SessionStorageService!.SetItemAsync("current-portfolio-category", kvpCurrentCategory);
            await JSCommonMethodsHelper.ChangeInnerHtml(this.JSRuntime!, "portfolioCategoryName", kvpCurrentCategory.Value);
            await JSCommonMethodsHelper.ChangeInnerHtml(this.JSRuntime!, "categoryNeedToDelete", kvpCurrentCategory.Value);
        }
        else
        {
            strMessage = apiResponse.ResponseMessage;
        }
    }

    protected async Task UpdatePortfolio()
    {
        await FetchUserHoldings();
    }
    #endregion

    #region Privates
    private async Task InitializeProperties()
    {
        nUserId = await ((CustomAuthenticationStateProvider) this.AuthenticationStateProvider!).GetUserId();
    }

    private async Task InitializePageActions()
    {
        await UpdatePortfolio();

        KeyValuePair<int, string> kvpCurrentCategory = await this.SessionStorageService!.GetItemAsync<KeyValuePair<int, string>>("current-portfolio-category");

        int nKey;
        string strValue;

        if(!string.IsNullOrEmpty(kvpCurrentCategory.Value))
        {
            nKey = kvpCurrentCategory.Key;
            strValue = kvpCurrentCategory.Value;
        }
        else
        {
            nKey = this.PortfolioStockCategories!.First().Key;
            strValue = this.PortfolioStockCategories!.First().Value;
        }

        nCategoryId = nKey;
        strCategoryName = strValue;
        await GetHoldingStocks(nKey, strValue);
    }

    private async Task FetchUserHoldings()
    {
        await FetchPortfolioCategories();
    }

    private async Task FetchPortfolioCategories()
    {
        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(PortfolioEndPoints.GetAllPortfolioCategories, nUserId), HttpMethods.Get, null!);

        if(apiResponse.ResponseCode != HttpStatusCode.OK)
        {
            strMessage = apiResponse.ResponseMessage;
            return;
        }

        this.PortfolioStockCategories = JsonConvert.DeserializeObject<List<KeyValuePair<int, string>>>(TypeCastingHelper.ConvertObjectToString(apiResponse.Result!));
    }

    private async Task UpdateUserHoldings()
    {
        this.HoldingStocks = new List<HoldingStockDto>();

        foreach(PortfolioStockDto portfolioStockDto in this.PortfolioStocks!)
        {
            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(StockStatisticEndPoints.GetPrice, portfolioStockDto.Symbol), HttpMethods.Get, null!);

            if(apiResponse.ResponseCode != HttpStatusCode.OK)
            {
                strMessage = apiResponse.ResponseMessage;
                return;
            }

            HoldingStockDto holdingStock = new();

            try
            {
                PriceDto priceDto = JsonConvert.DeserializeObject<PriceDto>(apiResponse.Result!.ToString()!)!;

                holdingStock.Symbol = priceDto.Symbol;
                holdingStock.StockName = priceDto.LongName ?? priceDto.ShortName;
                holdingStock.Quantity = portfolioStockDto.Quantity;
                holdingStock.AveragePrice = portfolioStockDto.BuyPrice;
                holdingStock.InvestedValue = holdingStock.Quantity * holdingStock.AveragePrice;
                holdingStock.CurrentMarketPrice = double.Parse(priceDto.RegularMarketPrice!.Fmt!);
                holdingStock.TodayChangePercentage = priceDto.RegularMarketChangePercent!.Fmt!;
                holdingStock.CurrentValue = holdingStock.CurrentMarketPrice * holdingStock.Quantity;
                holdingStock.ProfitOrLossAmount = (double) (holdingStock.CurrentValue! - holdingStock.InvestedValue);
                holdingStock.ProfitOrLossPercentage = (double) ((holdingStock.ProfitOrLossAmount / holdingStock.Quantity) * 100) / holdingStock.AveragePrice;
                holdingStock.Currency = priceDto.Currency;

                this.HoldingStocks!.Add(holdingStock);
            }
            catch(Exception err)
            {
                strMessage = CommonWebServiceMessages.SomethingWentWrong + err.Message;
            }
        }
    }
    #endregion
}