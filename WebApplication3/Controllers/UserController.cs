using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly DataContext _db;
 
        public UserController(DataContext db)
        {
            _db = db;
           
        }
        [HttpGet]
        public ActionResult GetAllUsernames() { 
        var listOfUsernames = new List<string>();
        foreach (var user in _db.Users)
            {
                listOfUsernames.Add(user.Username);
            }
            return Ok(listOfUsernames);
        }

        // GET: api/<UserController>
        [Authorize]
        [HttpGet("/api/[controller]")]
        public ActionResult<List<User>> GetAll()
        {
            try
            {
                List<User> users = _db.Users.ToList();
                if (users != null && users.Count>0)
                {
                    return Ok(users);
                }
                    return NotFound("There are no users in DataBase!");
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }

      
        }


        // GET api/Users
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
            return _db.Users.ToList().Find(u => u.Id == id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/Users
        [HttpPost]
        public ActionResult Post([FromBody] User value)
        {
            try
            {
            _db.Add(value);
            _db.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/User/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put([FromBody] User value, int id)
        {
            var userList = _db.Users.ToList().Where(x=>x.Id == id).FirstOrDefault<User>();
            if (userList != null) {

                userList.FirstName = value.FirstName;
                userList.LastName = value.LastName;
                userList.Email = value.Email;
                userList.Password = value.Password;
                userList.Description = value.Description;
                userList.Phone = value.Phone;   
                userList.CityId = value.CityId;
                userList.Username = value.Username;

            }
            

        _db.SaveChanges();
            
          
        }

        // DELETE api/<UserController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _db.Users.Where(x=>x.Id == id).ExecuteDelete();
            _db.SaveChanges();
        }
    }
}
    
