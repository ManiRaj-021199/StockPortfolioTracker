using Microsoft.AspNetCore.Mvc;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Logic;

namespace Authentication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    #region Fields
    private readonly IAuthenticationService? authenticationService;
    #endregion

    #region Constructors
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }
    #endregion

    #region Publics
    [HttpPost]
    [Route("RegisterUser")]
    public async Task<BaseApiResponseDto> RegisterUser([FromBody] UserDto userDto)
    {
        BaseApiResponseDto response = await this.authenticationService!.RegisterUser(userDto);

        return response;
    }
    #endregion
}