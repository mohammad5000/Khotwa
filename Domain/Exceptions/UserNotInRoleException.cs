using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UserNotInRoleException : BadRequestException
    {
        public UserNotInRoleException(string userId, string roleName)
            : base($"User with ID '{userId}' is not in role '{roleName}'.")
        {
        }
    }
}
