using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Service;
using Service.Abstraction;
using Shared.DTO.Account;
using Shared.DTO.ApplicationUser;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IAccountService _accountService;

        // This controller will handle user account operations such as registration, login, and profile management.
        // Currently, it is empty and can be filled with methods for handling user accounts.

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _accountService.RegisterUserAsync(dto);
            return Created();
        }
        // Example method for user login
        [HttpPost("login")]
        public async Task<ActionResult<ApplicationUserDto>> Login(LoginDto loginDto)
        {
            return await _accountService.Login(loginDto);
        }
    }
}
