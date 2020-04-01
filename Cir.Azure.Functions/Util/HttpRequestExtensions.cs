using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Azure.Functions
{
    static class HttpRequestExtensions
    {
        public static bool IsPostTunnelledThroughGet(this HttpRequest req)
        {
            return "POST".Equals(req.Method, StringComparison.InvariantCultureIgnoreCase)
                && req.Headers.ContainsKey("X-HTTP-Method-Override")
                && "GET".Equals(req.Headers["X-HTTP-Method-Override"], StringComparison.InvariantCultureIgnoreCase)
                && "application/x-www-form-urlencoded".Equals(req.ContentType, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
