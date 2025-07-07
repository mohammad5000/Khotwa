using Domain.Exceptions;
using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Service.Abstraction;
using Shared.DTO.Account;
using Shared.DTO.ApplicationUser;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        public AccountService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Role name cannot be empty.");

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (roleExists)
                throw new RoleAlreadyExistsException(roleName);

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded)
                return true;

            var errors = result.Errors.Select(e => e.Description);
            throw new CreateRoleFailedException(errors);
        }

        public async Task<ApplicationUserDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                throw new UserNotFoundException(loginDto.Email);

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result)
                throw new UserNotFoundException(loginDto.Email);

            return new ApplicationUserDto
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = await _tokenService.CreateToken(user),
            };
        }

        public async Task<bool> RegisterUserAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                throw new CreateUserFailedException(result.Errors.Select(e => e.Description));

            var roleExists = await _roleManager.RoleExistsAsync(dto.Role);
            if (!roleExists)
                throw new RoleNotFoundException(dto.Role);

            var roleResult = await _userManager.AddToRoleAsync(user, dto.Role);
            if (!roleResult.Succeeded)
                throw new AddUserToRoleFailedException(roleResult.Errors.Select(e => e.Description));

            return true;
        }

        public async Task<bool> AddUserToRoleAsync(string userId, string roleName)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("User ID and role name cannot be null or empty.");

            var user = await GetUserOrThrowAsync(userId);

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
                throw new RoleNotFoundException(roleName);

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
                return true;

            var errorMessages = result.Errors.Select(e => e.Description);
            throw new AddUserToRoleFailedException(errorMessages);
        }

        public async Task<bool> CreateUserAsync(string userName, string email, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
                return true;

            var errorMessages = result.Errors.Select(e => e.Description);
            throw new CreateUserFailedException(errorMessages);
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await GetUserOrThrowAsync(userId);
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
        
        public async Task<ApplicationUserDto> GetUserByIdAsync(string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            return new ApplicationUserDto
            {
                Id = user.Id,
                Email = user.Email,
                //UserName = user.UserName
            };
        }

        // public async Task<ApplicationUserDto> GetUserByIdAsync(string userId)
        // {
        //     var user = await GetUserOrThrowAsync(userId);
        //     return new ApplicationUserDto
        //     {
        //         Email = user.Email,
        //         FirstName = user.FirstName,
        //         LastName = user.LastName,
        //     };
        // }


        public async Task<string> GetUserEmailAsync(string userId)
        {
            var user = await GetUserOrThrowAsync(userId);
            return user.Email;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await GetUserOrThrowAsync(userId);
            return $"{user.FirstName} {user.LastName}".Trim();
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(string userId)
        {
            var user = await GetUserOrThrowAsync(userId);
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<bool> IsUserInRoleAsync(string userId, string roleName)
        {
            var user = await GetUserOrThrowAsync(userId);
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<bool> RemoveUserFromRoleAsync(string userId, string roleName)
        {
            var user = await GetUserOrThrowAsync(userId);

            if (!await _userManager.IsInRoleAsync(user, roleName))
                throw new UserNotInRoleException(userId, roleName);

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (result.Succeeded)
                return true;

            throw new RemoveUserFromRoleFailedException(userId, roleName);
        }

        private async Task<ApplicationUser> GetUserOrThrowAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user ?? throw new UserNotFoundException(userId);
        }
    }
}
