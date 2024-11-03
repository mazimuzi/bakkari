using bakkari.Models;
using bakkari.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bakkari.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        [Authorize]

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        [HttpGet("{username}")]

        public async Task<ActionResult<UserDTO>> GetUser(string username)
        {
            UserDTO? user = await _userService.GetUserAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{username}")]

        public async Task<IActionResult> PutUser(string username, User user)
        {
            if (username != user.UserName)
            {
                return BadRequest();
            }

            if (await _userService.UpdateUserAsync(user))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> PostUser(User user)
        {
            UserDTO? newUser = await _userService.NewUserAsync(user);

            if (newUser == null)
            {
                return Problem("Username not available", statusCode: 400);
            }
            return CreatedAtAction("GetUser", new { username = user.UserName }, user);
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            if (await _userService.DeleteUserAsync(username))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
