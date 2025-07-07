using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class RoleAlreadyExistsException : ConflictException
    {
        public RoleAlreadyExistsException(string roleName)
            : base($"Role '{roleName}' already exists.") { }
    }
}
