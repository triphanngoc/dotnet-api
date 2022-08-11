using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BooksApi.Core.Models;
using BooksApi.Core.Services;
using Microsoft.AspNetCore.Authorization;
using BooksApi.Core.Models.User;

namespace UsersApi.Controllers
{   
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
           
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
           _userService.GetUsers();


        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]  
        [Route("register")]
        public ActionResult<User> Create(User User)
        {
            _userService.CreateUser(User);

            return CreatedAtRoute("GetUser", new { id = User.Id.ToString() }, User);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User UserIn)
        {
            var User = _userService.GetUser(id);

            if (User == null)
            {
                return NotFound();
            }

            _userService.UpdateUser(id, UserIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var User = _userService.GetUser(id);

            if (User == null)
            {
                return NotFound();
            }

            _userService.RemoveUser(id);

            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Login([FromBody] User user)
        {
            var token = _userService.Authenticate(user.Email, user.Password);
            
            if(token == null)            
                return Unauthorized();
            return Ok(new { token, user });
        }
    }
}
