using Domain.Exceptions;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Seeders
{
    public static class RoleSeeder
    {
        private static readonly string[] Roles = new[] { "Customer", "User", "Supervisor", "Admin"};

        public static async Task SeedAsync(IAccountService accountService)
        {
            foreach (var role in Roles)
            {
                try
                {
                    await accountService.CreateRoleAsync(role);
                }
                catch (RoleAlreadyExistsException)
                {
                    // Ignore if already exists
                }
            }
        }
    }
}
