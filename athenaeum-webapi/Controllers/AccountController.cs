using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace athenaeum_webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        public class Credentials
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] Credentials credentials)
        {
            return Ok();
        } 

        //public class LoginAttempt
        //{
        //    public string Email { get; set; }
        //    public string Passwor
        //}
    }
}
