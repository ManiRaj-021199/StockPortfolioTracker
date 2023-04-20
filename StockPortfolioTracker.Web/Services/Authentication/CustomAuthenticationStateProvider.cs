using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;

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
        string strUserEmail = await SessionStorageService!.GetItemAsync<string>("user-email");
        ClaimsIdentity identity;

        if(!string.IsNullOrEmpty(strUserEmail))
        {
            identity = new ClaimsIdentity(new[]
                                          {
                                              new Claim(ClaimTypes.Name, strUserEmail)
                                          }, "apiauth_type");
        }
        else identity = new ClaimsIdentity();

        ClaimsPrincipal user = new(identity);

        return await Task.FromResult(new AuthenticationState(user));
    }

    public void MarkUserAsAuthenticated(string strEmail)
    {
        ClaimsIdentity identity = new(new[]
                                      {
                                          new Claim(ClaimTypes.Name, strEmail)
                                      }, "apiauth_type");
        ClaimsPrincipal user = new(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public void MarkUserAsLoggedOut()
    {
        SessionStorageService!.RemoveItemAsync("user-email");

        ClaimsIdentity identity = new();
        ClaimsPrincipal user = new(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }
    #endregion
}