using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cir.Azure.Functions
{
    static class JTokenExtensions
    {
        public static T ValueOrDefault<T>(this JToken token)
        {
            try
            {
                return token.Value<T>();
            }
            catch
            {
                return default(T);
            }
        }
    }
}
