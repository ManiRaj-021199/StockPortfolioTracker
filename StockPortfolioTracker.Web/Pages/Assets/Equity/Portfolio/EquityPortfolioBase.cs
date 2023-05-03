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
    
    public List<PortfolioStockDto>? HoldingStocks { get; set; }
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
        BaseApiResponseDto apiResponse = await HttpClientHelper.MakeApiRequest(string.Format(PortfolioEndPoints.GetHoldingStocks, UserId), HttpMethods.Get, this.UserAccessToken!, null!);

        if(apiResponse.ResponseCode == HttpStatusCode.OK)
        {
            this.HoldingStocks = JsonConvert.DeserializeObject<List<PortfolioStockDto>>(apiResponse.Result!.ToString()!);
        }
        else this.Message = apiResponse.ResponseMessage;
    }
    #endregion
}