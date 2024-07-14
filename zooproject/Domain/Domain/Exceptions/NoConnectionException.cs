using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Exceptions
{
    public class NoConnectionException : Exception
    {
        public NoConnectionException(string? message) : base(message)
        {
        }
    }
}
