using Domain.Exceptions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string userId)
            : base($"User with ID '{userId}' was not found.") { }
    }
}
