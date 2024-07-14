using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Exceptions
{
    public class SqlException : Exception
    {
        public SqlException(string? message) : base(message)
        {
        }
    }
}
