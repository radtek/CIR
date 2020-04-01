using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class PathParameterException : Exception
    {
        public string Value { get; set; }
        public PathParameterException(string message, string value)
            : base(message)
        {
            Value = value;
        }
    }
}
