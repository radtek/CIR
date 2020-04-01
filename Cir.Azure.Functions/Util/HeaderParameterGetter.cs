using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class HeaderParameterGetter: IHeaderParameterGetter
    {
        public string GetString(string parameterName, HttpRequest request)
        {
            string value = request.Headers.FirstOrDefault(x => x.Key.Equals(parameterName, StringComparison.OrdinalIgnoreCase)).Value;
            if (string.IsNullOrEmpty(value))
            {
                throw new HeaderParameterException(
                    $"Request must contain exactly one header parameter named {parameterName}.",
                    request.Headers);
            }

            return value;
        }
    }
}
