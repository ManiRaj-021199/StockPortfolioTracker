using Microsoft.AspNetCore.Mvc;
using StockPortfolioTracker.Common;

namespace UserManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientManagementController : ControllerBase
{
    #region Fields
    private readonly IClientManagementFacade clientManagementFacade;
    #endregion

    #region Constructors
    public ClientManagementController(IClientManagementFacade clientManagementFacade)
    {
        this.clientManagementFacade = clientManagementFacade;
    }
    #endregion

    #region Publics
    [HttpGet]
    [Route("GetClientByEmail/{email}")]
    public async Task<BaseApiResponseDto> GetClientByEmail(string email)
    {
        BaseApiResponseDto response = await clientManagementFacade.GetClientByEmail(email);

        return response;
    }
    #endregion
}