using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Athenaeum.Data;
using Athenaeum.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Athenaeum.Controllers
{
    public class CollectionsController : Controller
    {
        //private IRepositoryWrapper _repo;
        private readonly AthenaeumContext _context;

        public CollectionsController(AthenaeumContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CollectionsGrid()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["UserId"]))
            {
                var userId = int.Parse(Request.Cookies["UserId"]);
                var userCollections = await _context.UserCollection.Where(x => x.UserId == userId).ToListAsync();

                var collections = new List<Models.Collection>();
                foreach (var userCollection in userCollections)
                {
                    var tempCollection = await _context.Collection.Where(x => x.CollectionId == userCollection.CollectionId).FirstOrDefaultAsync();
                    collections.Add(tempCollection);
                }

                collections.OrderBy(x => x.StartDate);
                return View(CodeUtility.SerializeObject(collections));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public async Task<IActionResult> ShowBooks(int collectionId)
        {
            if (!string.IsNullOrEmpty(Request.Cookies["UserId"]))
            {
                var userId = int.Parse(Request.Cookies["UserId"]);
                var books = await _context.view_BookInCollection_UserBook.Where(x => x.CollectionId == collectionId).ToListAsync();

                return RedirectToAction("Login", "Account");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
