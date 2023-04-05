using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    #region Publics
    [HttpGet]
    [Route("Index")]
    public string Index()
    {
        return "Authentication Api";
    }
    #endregion
}