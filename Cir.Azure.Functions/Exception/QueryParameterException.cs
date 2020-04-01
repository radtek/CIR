using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class QueryParameterException: Exception
    {
        public string QueryString { get; set; }
        public QueryParameterException(string message, string queryString)
            : base(message)
        {
            QueryString = queryString;
        }
    }
}
