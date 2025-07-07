using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class CreateUserFailedException : BadRequestException
    {
        public CreateUserFailedException(IEnumerable<string> errors)
            : base($"User creation failed: {string.Join(", ", errors)}") { }
    }
}
