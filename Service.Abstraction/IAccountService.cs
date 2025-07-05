using Shared.DTO.Account;
using Shared.DTO.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction
{
    public interface IAccountService
    {
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> RegisterUserAsync(RegisterDto dto);
        Task<string> GetUserNameAsync(string userId);
        Task<string> GetUserEmailAsync(string userId);
        Task<ApplicationUserDto> GetUserByIdAsync(string userId);
        Task<bool> IsUserInRoleAsync(string userId, string roleName);
        Task<IEnumerable<string>> GetUserRolesAsync(string userId);
        Task<bool> AddUserToRoleAsync(string userId, string roleName);
        Task<bool> RemoveUserFromRoleAsync(string userId, string roleName);
        Task<bool> CreateUserAsync(string userName, string email, string password);
        Task<bool> DeleteUserAsync(string userId);
       // Task<bool> UpdateUserEmailAsync(string userId, string newEmail);
    }
}
