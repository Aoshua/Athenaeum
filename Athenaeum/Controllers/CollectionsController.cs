using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Athenaeum.Data.Repositories;
using Athenaeum.Services;
using Microsoft.AspNetCore.Mvc;

namespace Athenaeum.Controllers
{
    public class CollectionsController : Controller
    {
        private IRepositoryWrapper _repo;

        public CollectionsController(IRepositoryWrapper repository)
        {
            _repo = repository;
        }

        public async Task<IActionResult> CollectionsGrid()
        {
            if (!string.IsNullOrEmpty(Request.Cookies["UserId"]))
            {
                var userId = int.Parse(Request.Cookies["UserId"]);
                var userCollections = await _repo.UserCollection.GetUserCollectionsAsync(userId);

                var collections = new List<Models.Collection>();
                foreach (var userCollection in userCollections)
                {
                    var tempCollection = await _repo.Collection.GetCollectionById(userCollection.CollectionId);
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
