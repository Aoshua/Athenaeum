using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Athenaeum.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Athenaeum.Controllers
{
    public class CollectionsController : Controller
    {
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
                return View(collections);
            } else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
