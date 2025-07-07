using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class CreateRoleFailedException : BadRequestException
    {
        public CreateRoleFailedException(IEnumerable<string> errors)
            : base($"Failed to create role: {string.Join(", ", errors)}") { }
    }
}
