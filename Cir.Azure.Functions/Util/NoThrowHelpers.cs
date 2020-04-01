using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    static class NoThrowHelpers
    {
        public static string ToString(dynamic value)
        {
            try
            {
                return JsonConvert.SerializeObject(value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string ToString(Func<dynamic> f)
        {
            try
            {
                return JsonConvert.SerializeObject(f());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
