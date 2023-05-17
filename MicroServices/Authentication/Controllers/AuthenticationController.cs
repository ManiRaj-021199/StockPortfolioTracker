using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioTracker.Common;

namespace Authentication.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = EntityUserRoles.APPLICATION)]
public class AuthenticationController : ControllerBase
{
    #region Fields
    private readonly IAuthenticationFacade? authenticationService;
    #endregion

    #region Constructors
    public AuthenticationController(IAuthenticationFacade authenticationService)
    {
        this.authenticationService = authenticationService;
    }
    #endregion

    #region Publics
    [HttpPost]
    [Route("RegisterUser")]
    public async Task<BaseApiResponseDto> RegisterUser([FromBody] UserRegisterDto userRegisterDto)
    {
        BaseApiResponseDto response = await authenticationService!.RegisterUser(userRegisterDto);

        return response;
    }

    [HttpPost]
    [Route("LoginUser")]
    public async Task<BaseApiResponseDto> LoginUser([FromBody] UserLoginDto userLoginDto)
    {
        BaseApiResponseDto response = await authenticationService!.LoginUser(userLoginDto);

        return response;
    }
    #endregion
}