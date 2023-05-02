using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockPortfolioTracker.Common;
using StockPortfolioTracker.Logic;

namespace UserManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserManagementController : ControllerBase
{
    #region Fields
    private readonly IUserManagementFacade? userManagementService;
    #endregion

    #region Constructors
    public UserManagementController(IUserManagementFacade userManagementService)
    {
        this.userManagementService = userManagementService;
    }
    #endregion

    #region Publics
    [HttpGet, Authorize(Roles = EntityUserRoles.SUPERUSER)]
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

    [HttpGet]
    [Route("GetUserByUserId/{nUserId}")]
    public async Task<BaseApiResponseDto> GetUserByUserId(int nUserId)
    {
        BaseApiResponseDto response = await userManagementService!.GetUserByUserId(nUserId);

        return response;
    }
    #endregion
}