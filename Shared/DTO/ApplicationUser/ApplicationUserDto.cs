namespace Shared.DTO.ApplicationUser
{
    public class ApplicationUserDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Token { get; set; }
    }
}
