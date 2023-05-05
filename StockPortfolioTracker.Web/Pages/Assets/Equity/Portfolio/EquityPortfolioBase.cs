using System.Net;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;
using HttpMethods = Microsoft.AspNetCore.Http.HttpMethods;

namespace StockPortfolioTracker.Web;

public class EquityPortfolioBase : ComponentBase
{
    #region Fields
    public bool bIsAddStockModalOpen;
    public bool bIsRemoveStockModalOpen;
    public string? Message = string.Empty;
    public string? MessageStyleClass = string.Empty;

    public int UserId = -1;
    public string? UserAccessToken = string.Empty;
    #endregion

    #region Properties
    [Inject]
    public AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

    public List<PortfolioStockDto>? PortfolioStocks { get; set; }
    public List<HoldingStockDto>? HoldingStocks { get; set; }

    protected PortfolioStockDto? StockNeedToAdd { get; set; }
    protected PortfolioTransactionDto? StockNeedToRemove { get; set; }
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

    protected async Task AddStockToPortfolio()
    {
        this.StockNeedToAdd!.UserId = UserId;

        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(PortfolioEndPoints.AddStockToPortfolio, HttpMethods.Post, UserAccessToken!, this.StockNeedToAdd);

        bIsAddStockModalOpen = false;
        MessageStyleClass = BootstrapStyles.BackgroundSuccess;
        Message = apiResponse.ResponseMessage;

        this.StockNeedToAdd = new PortfolioStockDto();
        await UpdatePortfolio();
    }

    protected async Task RemoveStockFromPortfolio()
    {
        this.StockNeedToRemove!.UserId = UserId;

        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(PortfolioEndPoints.RemoveStockFromPortfolio, HttpMethods.Post, UserAccessToken!, this.StockNeedToRemove);

        bIsRemoveStockModalOpen = false;
        MessageStyleClass = BootstrapStyles.BackgroundDanger;
        Message = apiResponse.ResponseMessage;

        this.StockNeedToRemove = new PortfolioTransactionDto();
        await UpdatePortfolio();
    }
    #endregion

    #region Privates
    private async Task InitializeProperties()
    {
        this.StockNeedToAdd = new PortfolioStockDto();
        this.StockNeedToRemove = new PortfolioTransactionDto();

        UserId = await ((CustomAuthenticationStateProvider) this.AuthenticationStateProvider!).GetUserId();
        UserAccessToken = await ((CustomAuthenticationStateProvider) this.AuthenticationStateProvider!).GetAccessToken();
    }

    private async Task UpdatePortfolio()
    {
        this.HoldingStocks = new List<HoldingStockDto>();

        await FetchUserHoldings();
        await UpdateUserHoldings();
    }

    private async Task FetchUserHoldings()
    {
        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(PortfolioEndPoints.GetHoldingStocks, UserId), HttpMethods.Get, UserAccessToken!, null!);

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
            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(StockStatisticEndPoints.GetPrice, portfolioStockDto.Symbol), HttpMethods.Get, UserAccessToken!, null!);

            if(apiResponse.ResponseCode != HttpStatusCode.OK)
            {
                Message = apiResponse.ResponseMessage;
                return;
            }

            HoldingStockDto holdingStock = new();

            try
            {
                PriceDto priceDto = JsonConvert.DeserializeObject<PriceDto>(apiResponse.Result!.ToString()!)!;

                holdingStock.StockName = priceDto.LongName;
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