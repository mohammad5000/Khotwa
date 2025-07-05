using Domain.Exceptions;
using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Service.Abstraction;
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

        public async Task<bool> AddUserToRoleAsync(string userId, string roleName)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("User ID and role name cannot be null or empty.");

            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

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
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            var result = await UserManager.DeleteAsync(user);
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

        public async Task<string> GetUserEmailAsync(string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            return user.Email;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            return user.UserName;
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            return await UserManager.GetRolesAsync(user);
        }

        public async Task<bool> IsUserInRoleAsync(string userId, string roleName)
        {
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            return await UserManager.IsInRoleAsync(user, roleName);
        }

        public async Task<bool> RemoveUserFromRoleAsync(string userId, string roleName)
        {
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            var result = await UserManager.RemoveFromRoleAsync(user, roleName);
            return result.Succeeded;
        }
    }

}
