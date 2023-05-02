using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Web;

public class EquityWatchlistBase : ComponentBase
{
    #region Properties
    [Inject]
    public AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

    public List<PriceDto>? StockPrices { get; set; }

    public string? UserAccessToken { get; set; }
    #endregion

    #region Protecteds
    protected override async Task OnInitializedAsync()
    {
        this.UserAccessToken = await ((CustomAuthenticationStateProvider) this.AuthenticationStateProvider!).GetAccessToken();

        await UpdateUserWatchlist();
    }
    #endregion

    #region Privates
    private async Task UpdateUserWatchlist()
    {
        List<string> StockNames = new() { "BAJFINANCE.NS", "ASIANPAINT.NS", "RELIANCE.NS", "INFY.NS", "TMB.NS", "TCS.NS", "WIPRO.NS", "ITC.NS", "IEX.NS", "KPITTECH.NS", "TATAMOTORS.NS", "TATAPOWER.NS" };
        List<PriceDto> temp = new();

        foreach(string stock in StockNames)
        {
            HttpClient client = new();
            client.BaseAddress = new Uri($"http://ms-nb0101:92/equity/GetPrice/{stock}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.UserAccessToken);

            PriceDto priceDto = (await client.GetFromJsonAsync<PriceDto>(string.Empty))!;

            temp.Add(priceDto);
        }

        this.StockPrices = temp;
    }
    #endregion
}