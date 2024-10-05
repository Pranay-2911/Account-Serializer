using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializer.Exceptions
{
    internal class InvalidAccountIdException : Exception
    {
        public InvalidAccountIdException(string message) : base(message)
        { 
        }  
    }
}
