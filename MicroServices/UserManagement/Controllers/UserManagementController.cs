using Microsoft.AspNetCore.Mvc;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Logic;

namespace UserManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserManagementController : ControllerBase
{
    #region Fields
    private readonly IUserManagementService? userManagementService;
    #endregion

    #region Constructors
    public UserManagementController(IUserManagementService userManagementService)
    {
        this.userManagementService = userManagementService;
    }
    #endregion

    #region Publics
    [HttpGet]
    [Route("GetAllUsers")]
    public async Task<BaseApiResponseDto> GetAllUsers()
    {
        BaseApiResponseDto response = await userManagementService!.GetAllUsers();

        return response;
    }

    [HttpGet]
    [Route("GetUserByEmail/{strEmail}")]
    public async Task<BaseApiResponseDto> GetUserByEmail(string strEmail)
    {
        BaseApiResponseDto response = await userManagementService!.GetUserByEmail(strEmail);

        return response;
    }
    #endregion
}