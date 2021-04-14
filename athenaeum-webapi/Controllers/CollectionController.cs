using athenaeum_webapi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetDefaultCollection(int userId)
        {
            // TODO: modify database to have an "is default" column
            var collection = await context.UserCollection.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            var collectionId = collection.CollectionId;

            return Ok(collection);
        }
    }
}
