using System;
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
                var collection = await _context.Collection.Where(x => x.CollectionId == collectionId).FirstOrDefaultAsync();
                var books = await _context.view_BookInCollection_Publisher.Where(x => x.CollectionId == collectionId).ToListAsync();

                //var vm = new ShowBooksVM
                //{
                //    CollectionTitle = collection.Title,
                //    Books = CodeUtility.SerializeObject(books).ToString()
                //};

                return View("BooksInCollection", CodeUtility.SerializeObject(new { Title = collection.Title, Books = books}));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult ShowCreateBook(int collectionId)
        {
            return View("CreateBook", collectionId);
        }

        public async Task<IActionResult> AddBook(string bookTitle, int? pageCount, string seriesTitle, int? seriesOrder, string genres, int? publisherId, DateTime? publicationDate, DateTime? purchaseDate, string purchaseLocation, DateTime? startedDate, DateTime? completedDate, string notes, string collectionId)
        {
            // Lots of complicated add logic
            return RedirectToAction("ShowBooks", int.Parse(collectionId));
        }
    }

    public class ShowBooksVM
    {
        public string CollectionTitle { get; set; }
        public string Books { get; set; }
    }
}