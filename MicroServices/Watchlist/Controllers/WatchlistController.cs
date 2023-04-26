using Microsoft.AspNetCore.Mvc;

namespace Watchlist.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WatchlistController : ControllerBase
{
    #region Publics
    [HttpGet]
    [Route("GetAllWatchlistForTheUser")]
    public string GetAllWatchlistForTheUser()
    {
        return "GetAllWatchlistForTheUser";
    }
    #endregion
}