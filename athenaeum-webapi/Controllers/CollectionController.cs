using athenaeum_webapi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace athenaeum_webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class CollectionController : ControllerBase
    {
        private readonly AthenaeumContext context;

        public CollectionController(AthenaeumContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksInDefaultCollection(int userId)
        {
            //var collection = await context.UserCollection.Include(i => i.Collection)
            //    .Where(x => x.UserId == userId).AsNoTracking().FirstOrDefaultAsync(); // TODO: modify database to have an "is default" column

            //var books = await context.BookInCollection
            //    .Include(i => i.Book) //.ThenInclude(j => j.BookPublishers).ThenInclude(k => k.Publisher)
            //    .Where(x => x.CollectionId == collection.CollectionId).AsNoTracking().ToListAsync();

            //return Ok(new { CollectionTitle = collection.Collection.Title, RecordCount = books.Count, Records = books });
            return BadRequest("Not implemented");
        }
    }
}
