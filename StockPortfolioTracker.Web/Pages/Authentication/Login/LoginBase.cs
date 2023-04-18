using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using StockPortfolioTracker.Common;

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

    protected UserDto? User { get; set; }
    #endregion

    #region Protecteds
    protected override Task OnInitializedAsync()
    {
        this.User = new UserDto();
        return base.OnInitializedAsync();
    }

    protected async Task<bool> ValidateUser()
    {
        ((CustomAuthenticationStateProvider) this.AuthenticationStateProvider!).MarkUserAsAuthenticated(this.User?.Email!);
        this.NavigationManager?.NavigateTo("/");

        await this.SessionStorageService!.SetItemAsync("user-email", this.User!.Email);

        return await Task.FromResult(true);
    }
    #endregion
}