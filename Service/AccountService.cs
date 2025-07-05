using Domain.Exceptions;
using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Service.Abstraction;
using Shared.DTO.Account;
using Shared.DTO.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;

        public AccountService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }
        public async Task<bool> CreateRoleAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Role name cannot be empty.");

            var roleExists = await RoleManager.RoleExistsAsync(roleName);
            if (roleExists)
                throw new RoleAlreadyExistsException(roleName);

            var result = await RoleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded)
                return true;

            var errors = result.Errors.Select(e => e.Description);
            throw new CreateRoleFailedException(errors);
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

            var result = await UserManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                throw new CreateUserFailedException(result.Errors.Select(e => e.Description));

            var roleExists = await RoleManager.RoleExistsAsync(dto.Role);
            if (!roleExists)
                throw new RoleNotFoundException(dto.Role);

            var roleResult = await UserManager.AddToRoleAsync(user, dto.Role);
            if (!roleResult.Succeeded)
                throw new AddUserToRoleFailedException(roleResult.Errors.Select(e => e.Description));

            return true;
        }
        public async Task<bool> AddUserToRoleAsync(string userId, string roleName)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("User ID and role name cannot be null or empty.");

            var user = await GetUserOrThrowAsync(userId);

            var roleExists = await RoleManager.RoleExistsAsync(roleName);
            if (!roleExists)
                throw new RoleNotFoundException(roleName);

            var result = await UserManager.AddToRoleAsync(user, roleName);
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

            var result = await UserManager.CreateAsync(user, password);
            if (result.Succeeded)
                return true;

            var errorMessages = result.Errors.Select(e => e.Description);
            throw new CreateUserFailedException(errorMessages);
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await GetUserOrThrowAsync(userId);
            var result = await UserManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<ApplicationUserDto> GetUserByIdAsync(string userId)
        {
            var user = await GetUserOrThrowAsync(userId);
            return new ApplicationUserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedAt = user.CreatedAt
            };
        }

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
            return await UserManager.GetRolesAsync(user);
        }

        public async Task<bool> IsUserInRoleAsync(string userId, string roleName)
        {
            var user = await GetUserOrThrowAsync(userId);
            return await UserManager.IsInRoleAsync(user, roleName);
        }

        public async Task<bool> RemoveUserFromRoleAsync(string userId, string roleName)
        {
            var user = await GetUserOrThrowAsync(userId);

            if (!await UserManager.IsInRoleAsync(user, roleName))
                throw new UserNotInRoleException(userId, roleName);

            var result = await UserManager.RemoveFromRoleAsync(user, roleName);
            if (result.Succeeded)
                return true;

            throw new RemoveUserFromRoleFailedException(userId, roleName);
        }

        private async Task<ApplicationUser> GetUserOrThrowAsync(string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);
            return user ?? throw new UserNotFoundException(userId);
        }
    }
}
