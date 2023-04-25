using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioController : ControllerBase
{
    #region Publics
    [HttpGet]
    [Route("Index")]
    public string Index()
    {
        return "Hello, World";
    }
    #endregion
}