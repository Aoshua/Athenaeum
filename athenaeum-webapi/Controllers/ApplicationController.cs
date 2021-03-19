using athenaeum_webapi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace athenaeum_webapi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApplicationController : ControllerBase
    {
        private readonly AthenaeumContext _context;

        public ApplicationController(AthenaeumContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TestConnection()
        {
            return Ok("API connected successfully");
        }

        [HttpGet]
        public IActionResult TestDatabase()
        {
            var user = _context.User.Include(i => i.Collections).ThenInclude(it => it.Collection).FirstOrDefault();
            return Ok("Connected to DB successfully");
        }
    }
}
