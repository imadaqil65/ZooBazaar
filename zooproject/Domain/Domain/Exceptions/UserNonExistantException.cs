using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Exceptions
{
    public class UserNonExistantException : Exception
    {
        public UserNonExistantException(string? message) : base(message)
        {
        }
    }
}
