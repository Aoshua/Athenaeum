using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Athenaeum.Data;
using Athenaeum.Data.Repositories;
using Athenaeum.Models;
using Athenaeum.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Athenaeum.Controllers
{
    public class CollectionsController : Controller
    {
        private IRepositoryWrapper _repo;
        private AthenaeumContext _context;

        public CollectionsController(AthenaeumContext context, IRepositoryWrapper repository)
        {
            _context = context;
            _repo = repository;
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
                return View(CodeUtility.SerializeObject(collections)); //return View(collections);
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
                //var books =
                //    from collectedBooks in _context.BookInCollection
                //    join userBooks in _context.UserBook on collectedBooks.BookId equals userBooks.BookId
                //    select new { BookInCollectionId = collectedBooks.BookInCollectionId, BookId = collectedBooks.BookId,
                //                PublisherId = collectedBooks.PublisherId, PublicationDate = collectedBooks.PublicationDate,
                //                PurchaseDate = collectedBooks.PurchaseDate, CollectionId = collectedBooks.CollectionId,
                //                PurchaseLocation = collectedBooks.PurchaseLocation, UserBookId = userBooks.UserBookId,
                //                UserId = userBooks.UserId, StartedDate = userBooks.StartedDate, CompletedDate = userBooks.CompletedDate};

                var books = await _repo.BookInCollection.GetBooksInCollectionAsync(collectionId);

                return RedirectToAction("Login", "Account");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
