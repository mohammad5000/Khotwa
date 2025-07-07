using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class RoleNotFoundException : NotFoundException
    {
        public RoleNotFoundException(string roleName)
            : base($"Role '{roleName}' was not found.") { }
    }
}
