using Microsoft.AspNetCore.Http;
using System;

namespace Cir.Azure.Functions
{
    class HeaderParameterException: Exception
    {
        public IHeaderDictionary Headers { get; set; }
        public HeaderParameterException(string message, IHeaderDictionary headers)
            : base(message)
        {
            Headers = headers;
        }
    }
}
