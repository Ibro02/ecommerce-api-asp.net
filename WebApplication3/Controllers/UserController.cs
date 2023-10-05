using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private List<User> _user = new List<User>() {
        new User(),
        new User(2, "Eldar", "Dautovic")
        };
        // GET: api/<UserController>
        [HttpGet("/api/[controller]")]
        public ActionResult<List<User>> Get()
        {
            return _user;
        }

        // GET api/Users
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _user[id];
        }

        // POST api/Users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
