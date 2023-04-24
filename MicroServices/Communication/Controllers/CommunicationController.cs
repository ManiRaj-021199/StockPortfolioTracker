using Microsoft.AspNetCore.Mvc;

namespace Communication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommunicationController : ControllerBase
{
    #region Publics
    [HttpGet]
    [Route("Index")]
    public string Index()
    {
        return "Hello, World!";
    }
    #endregion
}