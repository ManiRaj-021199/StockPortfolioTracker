using System.Net;
using Microsoft.AspNetCore.Components;
using StockPortfolioTracker.Common;
using HttpMethods = StockPortfolioTracker.Common.HttpMethods;

namespace StockPortfolioTracker.Web;

public class RegisterBase : ComponentBase
{
    #region Properties
    protected UserRegisterDto? UserRegisterDto { get; set; }

    protected string? Message { get; set; }
    protected string? MessageStyleClass { get; set; }
    #endregion

    #region Protecteds
    protected override void OnInitialized()
    {
        this.UserRegisterDto = new UserRegisterDto();
    }

    protected async Task RegisterUser()
    {
        if(this.UserRegisterDto!.Password != this.UserRegisterDto.ConfirmPassword)
        {
            this.Message = "Passwords Mismatch. Please check Passwords.";
            this.MessageStyleClass = "btn-danger";
            return;
        }

        BaseApiResponseDto response = await HttpClientHelper.MakeApiRequest(AuthenticationEndPoints.RegisterUser, HttpMethods.Post, string.Empty, this.UserRegisterDto!);

        this.Message = response.ResponseMessage;

        switch(response.ResponseCode)
        {
            case HttpStatusCode.OK:
                this.MessageStyleClass = "btn-success";
                break;
            default:
                this.MessageStyleClass = "btn-danger";
                break;
        }
    }
    #endregion
}