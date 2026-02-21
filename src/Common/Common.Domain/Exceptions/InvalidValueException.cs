using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Exceptions
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException()
        {
            
        }
        public InvalidValueException(string message) : base(message)
        { 
            
        }
    }
}
