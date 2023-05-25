using System.Net;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.QuickGrid;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;
using HttpMethods = Microsoft.AspNetCore.Http.HttpMethods;

namespace StockPortfolioTracker.Web;

public class EquityPortfolioBase : ComponentBase
{
    #region Fields
    public string? Message = string.Empty;

    public int UserId = -1;
    
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

    public List<PortfolioStockDto>? PortfolioStocks { get; set; }
    public List<HoldingStockDto>? HoldingStocks { get; set; }
    #endregion

    #region Protecteds
    protected override async Task OnInitializedAsync()
    {
        await InitializeProperties();
        await UpdatePortfolio();

        /*
        // Update price every 1 sec

        _ = new Timer(async _ =>
                      {
                          await UpdatePortfolio();

                          await InvokeAsync(StateHasChanged);
                      }, null, 0, 1000);
        */
    }

    protected async Task UpdatePortfolio()
    {
        this.HoldingStocks = new List<HoldingStockDto>();

        await FetchUserHoldings();
        await UpdateUserHoldings();
    }
    #endregion

    #region Privates
    private async Task InitializeProperties()
    {
        UserId = await ((CustomAuthenticationStateProvider) this.AuthenticationStateProvider!).GetUserId();
    }

    private async Task FetchUserHoldings()
    {
        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(PortfolioEndPoints.GetHoldingStocks, UserId), HttpMethods.Get, null!);

        if(apiResponse.ResponseCode != HttpStatusCode.OK)
        {
            Message = apiResponse.ResponseMessage;
            return;
        }

        this.PortfolioStocks = JsonConvert.DeserializeObject<List<PortfolioStockDto>>(apiResponse.Result!.ToString()!);
    }

    private async Task UpdateUserHoldings()
    {
        foreach(PortfolioStockDto portfolioStockDto in this.PortfolioStocks!)
        {
            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(StockStatisticEndPoints.GetPrice, portfolioStockDto.Symbol), HttpMethods.Get, null!);

            if(apiResponse.ResponseCode != HttpStatusCode.OK)
            {
                Message = apiResponse.ResponseMessage;
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
                Message = CommonWebServiceMessages.SomethingWentWrong + err.Message;
            }
        }
    }
    #endregion
}