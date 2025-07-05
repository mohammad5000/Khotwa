﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.Base
{
    public abstract class ConflictException : Exception
    {
        protected ConflictException(string message)
            : base(message)
        {
        }
    }
}
