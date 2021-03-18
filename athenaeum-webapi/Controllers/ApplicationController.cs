using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace athenaeum_webapi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class ApplicationController : Controller
    {
        [AllowAnonymous]
        public IActionResult TestConnection()
        {
            return Ok("Connection success!");
        }
    }
}
