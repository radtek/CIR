using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Cir.Data.Access.Helpers
{
    internal class HttpHelpers
    {
        private const string ApplicationJsonHeader = "application/json";

        public static StringContent CreateJsonStringContent(object content)
        {
            return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, ApplicationJsonHeader);
        }
    }
}
