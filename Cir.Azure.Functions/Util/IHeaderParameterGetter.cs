using Microsoft.AspNetCore.Http;

namespace Cir.Azure.Functions
{
    interface IHeaderParameterGetter
    {
        string GetString(string parameterName, HttpRequest request);
    }
}
