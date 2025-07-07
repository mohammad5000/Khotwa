using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class AddUserToRoleFailedException : Exception
    {
        public AddUserToRoleFailedException(IEnumerable<string> errors)
            : base($"Failed to add user to role: {string.Join(", ", errors)}") { }
    }
}
