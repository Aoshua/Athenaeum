using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Athenaeum.Controllers
{
    public class AccountController : Controller
    {
        private readonly Data.AthenaeumContext _context;

        public AccountController(Data.AthenaeumContext context)
        {
            _context = context;
        }

        public IActionResult Login(bool? hasError = false, string message = "")
        {
            ViewBag.HasError = hasError;
            if (message.Length > 0)
                ViewBag.Message = message;

            return View();
        }

        public async Task<IActionResult> AttemptLogin(string email, string password)
        {
            var allegedUser = await _context.User.Where(x => x.Email == email).FirstOrDefaultAsync();
            var passHash = Services.Cryptographer.ComputeSha256Hash(password + allegedUser.Salt);
            if(allegedUser.Password == passHash)
            {
                Response.Cookies.Append("UserId", allegedUser.UserId.ToString());
                return RedirectToAction("CollectionsGrid", "Collections");
            } else
            {
                // Login failed
                return RedirectToAction("Login", "Account", true, "Failed to authenticate.");
            }
        }
    }
}
