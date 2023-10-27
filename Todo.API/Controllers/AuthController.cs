using Microsoft.AspNetCore.Mvc;
using Todo.API.Repositories;
using Todo.API.Models;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredentials credentials)
        {
            var user = _authService.Authenticate(credentials.Username, credentials.Password);

            if (user == null)
                return Unauthorized();

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        // POST api/auth/register
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            var result = await _authService.Register(user);
            if (!result)
                return BadRequest();

            return StatusCode(201);
        }
    }
}
