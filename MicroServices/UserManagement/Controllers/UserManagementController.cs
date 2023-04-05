using Microsoft.AspNetCore.Mvc;

namespace UserManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {
        #region Publics
        [HttpGet]
        [Route("Index")]
        public string Index()
        {
            return "User Management Api";
        }
        #endregion
    }
}