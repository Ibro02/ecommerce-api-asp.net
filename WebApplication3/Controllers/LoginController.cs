using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly DataContext _db;
        public readonly IConfiguration _config;
        public LoginController(IConfiguration configuration,DataContext db)
        {
  _db = db;
_config = configuration;
        }
       
        private string CreateToken(Login login)
        {
            List<Claim> claims = new (){ new Claim(ClaimTypes.Name, login.Username)};

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        [HttpPost]
        public ActionResult<Login> Post(Login login){
            var listOfUsers = new List<User>();
            foreach(var u in _db.Users)
            {
                listOfUsers.Add(u);
            }
            if (!listOfUsers.Where(x => x.Username == login.Username && x.Password == login.Password).Any())
                return NotFound();
            
                string token = CreateToken(login);
                return Ok(token);
                //listOfUsers.Where(x => x.Username == login.Username) - returns logged user
           
        }
    }
}
