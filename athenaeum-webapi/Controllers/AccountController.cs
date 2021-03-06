﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace athenaeum_webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly Data.AthenaeumContext context;
        private readonly IConfiguration config;

        public AccountController(Data.AthenaeumContext context, IConfiguration configuration) //Services.AppSettings appSettings)
        {
            this.context = context;
            config = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] Credentials credentials)
        {
            var allegedUser = await context.User.Where(x => x.Email == credentials.Email).AsNoTracking().FirstOrDefaultAsync();
            if (allegedUser != null)
            {
                var passHash = Services.Cryptographer.ComputeSha256Hash(credentials.Password + allegedUser.Salt).ToUpper(); //MyPass111

                if (allegedUser.Password.ToUpper() == passHash) // Login succeeds
                {
                    return Ok(new
                    {
                        User = new { UserId = allegedUser.UserId, FullName = allegedUser.FullName, Email = allegedUser.Email },
                        Token = GetUserToken(allegedUser.UserId)
                    });
                }
                else // Login failed
                {
                    return BadRequest(new { Message = "Invalid credentials." });
                }
            } else
            {
                return BadRequest(new { Message = "Invalid credentials." });
            }
                
        }

        #region Internal Methods
        private object GetUserToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = config.GetSection("AppSettings").GetChildren().FirstOrDefault().Value;
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var writtenToken = tokenHandler.WriteToken(token);

            return new
            {
                AccessToken = writtenToken,
                TokenType = "bearer",
                ExpiresOn = token.ValidTo,
            };
        }
        #endregion

        #region Models
        public class Credentials
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        #endregion
    }
}
