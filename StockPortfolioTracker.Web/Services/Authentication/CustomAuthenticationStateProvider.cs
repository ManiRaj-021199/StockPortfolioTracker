using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using StockPortfolioTracker.Logic;

namespace StockPortfolioTracker.Web;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    #region Fields
    private readonly ISessionStorageService? SessionStorageService;
    #endregion

    #region Constructors
    public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
    {
        SessionStorageService = sessionStorageService;
    }
    #endregion

    #region Publics
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string strAccessToken = await SessionStorageService!.GetItemAsync<string>("user-accesstoken");

        ClaimsIdentity identity = !string.IsNullOrEmpty(strAccessToken) ? new ClaimsIdentity(JwtTokenHelper.ParseClaimsFromJwtToken(strAccessToken), "jwt") : new ClaimsIdentity();
        ClaimsPrincipal user = new(identity);

        return await Task.FromResult(new AuthenticationState(user));
    }

    public void MarkUserAsAuthenticated(string strAccessToken)
    {
        ClaimsIdentity identity = new(JwtTokenHelper.ParseClaimsFromJwtToken(strAccessToken), "jwt");
        ClaimsPrincipal user = new(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public void MarkUserAsLoggedOut()
    {
        SessionStorageService!.RemoveItemAsync("user-accesstoken");

        ClaimsIdentity identity = new();
        ClaimsPrincipal user = new(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }
    #endregion
}