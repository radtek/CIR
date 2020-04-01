using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class BodyParameterException : Exception
    {
        public string Body { get; set; }
        public BodyParameterException(string message, string body)
            : base(message)
        {
            Body = body;
        }
        public BodyParameterException(string message, string body, Exception innerException)
            : base(message, innerException)
        {
            Body = body;
        }
    }
}
