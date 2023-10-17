//using Microsoft.AspNetCore.Mvc;
//using WebApplication3.Data;
//using WebApplication3.Models;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace WebApplication3.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CommentController : ControllerBase
//    {
//        private readonly DataContext _db;

//        public CommentController(DataContext db)
//        {
//                _db = db;
//        }
//        // GET: api/<CommentController>
//        [HttpGet]
//        public ActionResult<List<Comment>> Get()
//        {
//           if (_db.Comments.ToList().Any())
//            {
//                return Ok(_db.Comments.ToList());
//            }

//           return NoContent();
//        }

//        // GET api/<CommentController>/5
//        [HttpGet("{id}")]
//        public ActionResult Get(int id)
//        {
//            if (_db.Comments.ToList().Where(x=>x.Id==id).Any())
//            {
//                return Ok(_db.Comments.ToList().Where(x=>x.Id == id));
//            }

//            return NotFound();
//        }

//        // POST api/<CommentController>
//        [HttpPost]
//        public ActionResult Post([FromBody] Comment value)
//        {
//            try
//            {
//                _db.Comments.Add(value);
//                _db.SaveChanges();
//                return Ok(value);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        // PUT api/<CommentController>/5
//        //[HttpPut("{id}")]
//        //public void Put(int id, [FromBody] string value)
//        //{
//        //}

//        // DELETE api/<CommentController>/5
//        [HttpDelete("{id}")]
//        public ActionResult Delete(int id)
//        {
//            try
//            {
//                _db.Comments.Where(x=>x.Id == id);
//                _db.Remove(id);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//    }
//}
