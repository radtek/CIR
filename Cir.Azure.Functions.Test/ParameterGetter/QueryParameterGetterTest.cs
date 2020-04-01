using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Azure.Functions.Test.ParameterGetter
{
    
    public class QueryParameterGetterTest
    {
        [Fact]
        public async Task GetCollectionCaseInsensitive()
        {
            // Arrange
            var sut = new QueryParameterGetter();
            var context = new DefaultHttpContext();
            var request = context.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "ID", "1" },
                { "id", "2" },
                { "Id", "3" },
                { "iD", "4" }
            };
            request.Query = new QueryCollection(queryParameters);

            // Act
            var actual = await sut.GetCollectionAsync("id", request);

            // Assert
            Assert.Equal(new[] { "1", "2", "3", "4" }, actual as ICollection);
        }

        [Fact]
        public async Task GetCollectionIgnoreDuplicates()
        {
            // Arrange
            var sut = new QueryParameterGetter();
            var context = new DefaultHttpContext();
            var request = context.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "id", new []{ "1", "1" } }
            };
            request.Query = new QueryCollection(queryParameters);

            // Act
            var actual = await sut.GetCollectionAsync("id", request);

            // Assert
            Assert.Equal(new[] { "1" }, actual as ICollection);
        }

        [Fact]
        public async Task GetCollectionEmpty()
        {
            // Arrange
            var sut = new QueryParameterGetter();

            var context = new DefaultHttpContext();
            var request = context.Request;

            // Act
            var actual = await sut.GetCollectionAsync("id", request);

            // Assert
            Assert.Equal(0, actual.Count);
        }

        [Fact]
        public async Task GetStringEmpty()
        {
            // Arrange
            var sut = new QueryParameterGetter();
            var context = new DefaultHttpContext();
            var request = context.Request;

            // Act
            await Assert.ThrowsAsync<QueryParameterException>(() => sut.GetStringAsync("id", request));

            // Assert
        }

        [Fact]
        public async Task GetString()
        {
            // Arrange
            var sut = new QueryParameterGetter();
            var context = new DefaultHttpContext();
            var request = context.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "id", "my_id" }
            };
            request.Query = new QueryCollection(queryParameters);

            // Act
            string actual = await sut.GetStringAsync("id", request);

            // Assert
            Assert.Equal("my_id", actual);
        }

        [Fact]
        public async Task GetStringDuplicates()
        {
            // Arrange
            var sut = new QueryParameterGetter();
            var context = new DefaultHttpContext();
            var request = context.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "id", new []{ "1", "2" } }
            };
            request.Query = new QueryCollection(queryParameters);

            // Act
            await Assert.ThrowsAsync<QueryParameterException>(() => sut.GetStringAsync("id", request));

            // Assert
        }
        [Fact]
        public async Task GetLong()
        {
            // Arrange
            var sut = new QueryParameterGetter();
            var context = new DefaultHttpContext();
            var request = context.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "id", "123" }
            };
            request.Query = new QueryCollection(queryParameters);

            // Act
            long actual = await sut.GetValueAsync<long>("id", request);

            // Assert
            Assert.Equal(123, actual);
        }

        [Fact]
        public async Task GetLongMalformed()
        {
            // Arrange
            var sut = new QueryParameterGetter();
            var context = new DefaultHttpContext();
            var request = context.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "id", "not_a_long" }
            };
            request.Query = new QueryCollection(queryParameters);

            // Act
            await Assert.ThrowsAsync<QueryParameterException>(() => sut.GetValueAsync<long>("id", request));

            // Assert
        }

        [Fact]
        public async Task GetEnumerableNotInSet()
        {
            // Arrange
            var sut = new QueryParameterGetter();
            var context = new DefaultHttpContext();
            var request = context.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "letter", "c" }
            };
            request.Query = new QueryCollection(queryParameters);

            // Act
            await Assert.ThrowsAsync<QueryParameterException>(() => sut.GetEnumAsync("letter", new[] { "a", "b" }, request, true));

            // Assert
        }


        [Fact]
        public async Task GetEnumerableNotInSetWhenNotRequired()
        {
            // Arrange
            var sut = new QueryParameterGetter();
            var context = new DefaultHttpContext();
            var request = context.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "letter", "c" }
            };
            request.Query = new QueryCollection(queryParameters);

            // Act
            await Assert.ThrowsAsync<QueryParameterException>(() => sut.GetEnumAsync("letter", new[] { "a", "b" }, request, true));

            // Assert
        }


        [Fact]
        public async Task GetEnumerableNotPresentNotRequired()
        {
            // Arrange
            var sut = new QueryParameterGetter();
            var context = new DefaultHttpContext();
            var request = context.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
            };
            request.Query = new QueryCollection(queryParameters);

            // Act
            var result = await sut.GetEnumAsync("letter", new[] { "a", "b" }, request, false);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetEnumerableSuccess()
        {
            // Arrange
            var sut = new QueryParameterGetter();
            var context = new DefaultHttpContext();
            var request = context.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "letter", "b" }
            };
            request.Query = new QueryCollection(queryParameters);

            // Act
            var result = await sut.GetEnumAsync("letter", new[] { "a", "b" }, request, false);

            // Assert
            Assert.Equal("b", result);
        }

        [Fact]
        public async Task GetEnumerableDuplicates()
        {
            // Arrange
            var sut = new QueryParameterGetter();
            var context = new DefaultHttpContext();
            var request = context.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "letter", new[] {"a", "b" } }
            };
            request.Query = new QueryCollection(queryParameters);

            // Act
            await Assert.ThrowsAsync<QueryParameterException>(() =>  sut.GetEnumAsync("letter", new[] { "a", "b" }, request, false));

            // Assert
        }

    }
}
