using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public class DemoNotFoundException : NotFoundException
    {
        public DemoNotFoundException(int id)
            : base($"Demo with ID {id} was not found.")
        {
        }
    }
}
