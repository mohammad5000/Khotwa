using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class RemoveUserFromRoleFailedException : BadRequestException
    {
        public RemoveUserFromRoleFailedException(string userId, string roleName)
            : base($"Failed to remove user '{userId}' from role '{roleName}'.")
        {
        }
    }
}
