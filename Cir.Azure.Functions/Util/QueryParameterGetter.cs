using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class QueryParameterGetter : IQueryParameterGetter
    {
        private async Task<IEnumerable<KeyValuePair<string, StringValues>>> GetParametersAsync(HttpRequest request)
        {
            if (request.IsPostTunnelledThroughGet())
            {
                return await request.ReadFormAsync();
            }
            else
            {
                return request.Query;
            }
        }


        public async Task<IList<string>> GetCollectionAsync(string parameterName, HttpRequest request)
        {
            return (await GetParametersAsync(request))
                .Where(k => parameterName.Equals(k.Key, StringComparison.InvariantCultureIgnoreCase))
                .SelectMany(k => k.Value)
                .Distinct()
                .ToList();
        }

        public async Task<IList<T>> GetCollectionAsync<T>(string parameterName, HttpRequest request)
        {
            return (await GetCollectionAsync(parameterName, request))
                .Select(s => Convert<T>(s, parameterName, request))
                .ToList();
        }

        public async Task<string> GetStringAsync(string parameterName, HttpRequest request, bool required = true)
        {
            var strings = await GetCollectionAsync(parameterName, request);

            if ((required && strings.Count == 0) ||
                (strings.Count > 1))
            {
                throw new QueryParameterException(
                    $"Request must contain {(required ? "exactly" : "at most")} one query parameter named {parameterName}. Contained {strings.Count}.",
                    NoThrowHelpers.ToString(() => request.Query));
            }

            return strings.FirstOrDefault();
        }

        public async Task<T> GetValueAsync<T>(string parameterName, HttpRequest request, bool required = true)
        {
            var value = await GetStringAsync(parameterName, request, required);
            return Convert<T>(value, parameterName, request);
        }

        public async Task<string> GetEnumAsync(string parameterName, IList<string> acceptedValues, HttpRequest request, bool required = true)
        {
            var value = await GetStringAsync(parameterName, request, required);
            if (value != null)
            {
                if (acceptedValues.Any(v => string.Equals(v, value, StringComparison.InvariantCultureIgnoreCase)))
                {
                    return value.ToLower();
                }
                else
                {
                    throw new QueryParameterException(
                        $"parameter {parameterName} had unsupported value {value.ToLower()}. Supported values: {NoThrowHelpers.ToString(() => acceptedValues.ToList())}.",
                        NoThrowHelpers.ToString(() => request.Query));
                }
            }
            return null;
        }

        private T Convert<T>(string value, string parameterName, HttpRequest request)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)converter.ConvertFromInvariantString(value);
            }
            catch
            {
                throw new QueryParameterException(
                    $"Unable to parse value of query parameter {parameterName}. Value was '{value}'.",
                    NoThrowHelpers.ToString(() => request.Query));
            }
        }
    }
}
