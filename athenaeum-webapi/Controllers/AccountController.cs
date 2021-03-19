using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace athenaeum_webapi.Controllers
{
    [Authorize]
    public class AccountController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Authenticate(string email, string password)
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
