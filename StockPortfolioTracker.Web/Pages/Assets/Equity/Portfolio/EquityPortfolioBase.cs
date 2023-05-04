using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using StockPortfolioTracker.Common;
using HttpMethods = Microsoft.AspNetCore.Http.HttpMethods;

namespace StockPortfolioTracker.Web;

public class EquityPortfolioBase : ComponentBase
{
    #region Fields
    public int UserId;
    #endregion

    #region Properties
    [Inject]
    public AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

    public List<PortfolioStockDto>? PortfolioStocks { get; set; }
    public List<HoldingStockDto>? HoldingStocks { get; set; }
    public string? UserAccessToken { get; set; }
    public string? Message { get; set; }
    #endregion

    #region Protecteds
    protected override async Task OnInitializedAsync()
    {
        AuthenticationState authState = await ((CustomAuthenticationStateProvider) this.AuthenticationStateProvider!).GetAuthenticationStateAsync();

        this.UserAccessToken = await ((CustomAuthenticationStateProvider) this.AuthenticationStateProvider!).GetAccessToken();
        _ = int.TryParse(authState.User.Claims.FirstOrDefault(state => state.Type == ClaimTypes.PrimarySid)!.Value, out UserId);

        await UpdatePortfolio();
    }
    #endregion

    #region Privates
    private async Task UpdatePortfolio()
    {
        this.HoldingStocks = new List<HoldingStockDto>();

        await FetchUserHoldings();
        await UpdateUserHoldings();
    }

    private async Task FetchUserHoldings()
    {
        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(PortfolioEndPoints.GetHoldingStocks, UserId), HttpMethods.Get, this.UserAccessToken!, null!);

        if(apiResponse.ResponseCode != HttpStatusCode.OK)
        {
            this.Message = apiResponse.ResponseMessage;
            return;
        }

        this.PortfolioStocks = JsonConvert.DeserializeObject<List<PortfolioStockDto>>(apiResponse.Result!.ToString()!);
    }

    private async Task UpdateUserHoldings()
    {
        foreach(PortfolioStockDto portfolioStockDto in this.PortfolioStocks!)
        {
            BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(StockStatisticEndPoints.GetPrice, portfolioStockDto.Symbol), HttpMethods.Get, this.UserAccessToken!, null!);

            if(apiResponse.ResponseCode != HttpStatusCode.OK)
            {
                this.Message = apiResponse.ResponseMessage;
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
                this.Message = CommonWebServiceMessages.SomethingWentWrong + err.Message;
            }
        }
    }
    #endregion
}