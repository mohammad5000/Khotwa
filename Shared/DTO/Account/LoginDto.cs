using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Account;

public class LoginDto
{    
    public required string Email { get; set; }
    public required string Password { get; set; }
}
