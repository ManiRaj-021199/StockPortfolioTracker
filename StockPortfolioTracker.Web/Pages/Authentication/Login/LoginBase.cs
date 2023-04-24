using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using StockPortfolioTracker.Common;
using HttpMethods = StockPortfolioTracker.Common.HttpMethods;

namespace StockPortfolioTracker.Web;

public class LoginBase : ComponentBase
{
    #region Properties
    [Inject]
    public AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

    [Inject]
    public ISessionStorageService? SessionStorageService { get; set; }

    [Inject]
    public NavigationManager? NavigationManager { get; set; }

    protected UserLoginDto? UserLoginDto { get; set; }
    #endregion

    #region Protecteds
    protected override Task OnInitializedAsync()
    {
        this.UserLoginDto = new UserLoginDto();
        return base.OnInitializedAsync();
    }

    protected async Task<bool> ValidateUser()
    {
        BaseApiResponseDto response = await HttpClientHelper.MakeApiRequest(AuthenticationEndPoints.LoginUser, HttpMethods.Post, this.UserLoginDto!);

        ((CustomAuthenticationStateProvider) this.AuthenticationStateProvider!).MarkUserAsAuthenticated(this.UserLoginDto?.Email!);
        this.NavigationManager?.NavigateTo("/");

        await this.SessionStorageService!.SetItemAsync("user-email", this.UserLoginDto!.Email);

        return await Task.FromResult(true);
    }
    #endregion
}