using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Account
{
    public class RegisterDto
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public required string Email { get; set; }

        [Required]
        [Length(3, 20, ErrorMessage = "First name must be between 3 and 20 characters")]
        public string FirstName { get; set; }

        [Required]
        [Length(3, 20, ErrorMessage = "First name must be between 3 and 20 characters")]
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
    }
}
