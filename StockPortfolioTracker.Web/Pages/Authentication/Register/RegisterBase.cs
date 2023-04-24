using Microsoft.AspNetCore.Components;
using StockPortfolioTracker.Common;
using HttpMethods = StockPortfolioTracker.Common.HttpMethods;

namespace StockPortfolioTracker.Web;

public class RegisterBase : ComponentBase
{
    #region Properties
    protected UserRegisterDto? UserRegisterDto { get; set; }

    [Inject]
    private NavigationManager? NavigationManager { get; set; }
    #endregion

    #region Protecteds
    protected override void OnInitialized()
    {
        this.UserRegisterDto = new UserRegisterDto();
    }

    protected async Task RegisterUserAsync()
    {
        BaseApiResponseDto response = await HttpClientHelper.MakeApiRequest(AuthenticationEndPoints.RegisterUser, HttpMethods.Post, this.UserRegisterDto!);

        this.NavigationManager!.NavigateTo("login");
    }
    #endregion
}