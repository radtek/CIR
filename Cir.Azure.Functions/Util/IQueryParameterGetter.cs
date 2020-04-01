using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    public interface IQueryParameterGetter
    {
        Task<IList<string>> GetCollectionAsync(string parameterName, HttpRequest request);
        Task<IList<T>> GetCollectionAsync<T>(string parameterName, HttpRequest request);
        Task<string> GetStringAsync(string parameterName, HttpRequest request, bool required = true);
        Task<T> GetValueAsync<T>(string parameterName, HttpRequest request, bool required = true);
        Task<string> GetEnumAsync(string parameterName, IList<string> acceptedValues, HttpRequest request, bool required = true);
    }
}
