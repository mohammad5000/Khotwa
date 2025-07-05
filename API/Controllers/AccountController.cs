using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Shared.DTO.Account;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // This controller will handle user account operations such as registration, login, and profile management.
        // Currently, it is empty and can be filled with methods for handling user accounts.
        
        // Example method for user registration
        [HttpPost("register")]
        public IActionResult Register(RegisterDto userDto)
        {
            // Logic for registering a new user
            return Ok("User registered successfully.");
        }
        // Example method for user login
        [HttpPost("login")]
        public IActionResult Login([FromBody] object loginDto)
        {
            // Logic for user login
            return Ok("User logged in successfully.");
        }
    }
}
