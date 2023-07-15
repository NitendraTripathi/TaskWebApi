using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TaskWebApiCore.Model;
using TaskWebApiCore.Services;

namespace TaskWebApiCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserRepo _userRepo;
    

        public UserController(IUserRepo userRepo )
        {

            _userRepo = userRepo;
         

        }
        [HttpPost()]
        public async Task<IActionResult> LoginUser(User user)
        {
            var userR = await _userRepo.Loginuser(user);
            return Ok(userR);
        }

        [HttpPost()]
        public IActionResult AddUser(User user)
        {
            var userR = _userRepo.AddUser(user);
            return Ok(userR);
        }
        //edit book
        [HttpPut("")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            var userR = _userRepo.UpdateUser(user);
            return Ok(userR);
        }
        //get
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var usersR = _userRepo.GetUsers();
            return Ok(usersR);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserByid(int id)
        {
            if (id < 0)
            {
                return BadRequest("Please provide a valaid user id");
            }
            else
            {
                return Ok(_userRepo.GetUserById(id));
            }

        }
        //delete book
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (id < 0)
            {
                return BadRequest("Please provide a valaid user id");
            }
            else
            {
                _userRepo.DeleteUser(id);
                return Ok();
            }

        }
    }
}
