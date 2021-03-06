﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPattern
{
    [Authorize]
    [Produces("application/json")]
    [Route("api")]
    public class ApiController : Controller
    {
        private readonly IConfiguration _configuration;
        public ApiController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet("Test")]
        public IActionResult Test()
        {
            var userName = User.Identity.Name;

            return Ok($"Super secret content, I hope you've got clearance for this {userName}...");
        }
        [Authorize(Policy = "TrainedStaffOnly")]
        [HttpPost("DeleteUser")]
        public IActionResult DeleteUser(string username)
        {
            // go wild, delete the user, do what you have to...
            return Ok("Deleted");
        }
        // GET: /<controller>/
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (request.Username == "Jon" && request.Password == "Again, not for production use, DEMO ONLY!")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username),
                    new Claim("CompletedBasicTraining", ""),
                    new Claim(CustomClaimTypes.EmploymentCommenced,
                                new DateTime(2018,6,29).ToString(),
                                ClaimValueTypes.DateTime)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Could not verify username and password");
        }
        public class TokenRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
