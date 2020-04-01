using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class ConvertException: Exception
    {
        public ConvertException(string message, string source, Exception innerException)
            : base(message, innerException)
        {
            Source = source;
        }
    }
}
