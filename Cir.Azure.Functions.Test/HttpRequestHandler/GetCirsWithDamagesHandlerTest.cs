using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Azure.Functions.Test.HttpRequestHandler
{
#if false
    public class GetCirsWithDamagesHandlerTest
    {
        private readonly Mock<ICirRepository> repo;
        private readonly Mock<IHttpAuthorizer> httpAuthorizer;
        private readonly Mock<ILogger> logger;
        private readonly Mock<ICirsWithDamagesConverter> mockConverter;
        private readonly ICirsWithDamagesConverter converter;
        private readonly IQueryParameterGetter parameterGetter;
        private HttpContext requestContext = new DefaultHttpContext();
        private HttpRequest request;
        private GetCirsWithDamagesHandler getCirsWithDamagesHandler;

        public GetCirsWithDamagesHandlerTest()
        {
            repo = new Mock<ICirRepository>();
            httpAuthorizer = new Mock<IHttpAuthorizer>();
            logger = new Mock<ILogger>();
            mockConverter = new Mock<ICirsWithDamagesConverter>();
            converter = new CirWithDamagesConverter();
            parameterGetter = new QueryParameterGetter();
        }

        [Fact]
        public async Task NoIdInQuery()
        {
            // Arrange
            request = requestContext.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "foo", "bar" }
            };
            request.Query = new QueryCollection(queryParameters);
            getCirsWithDamagesHandler = new GetCirsWithDamagesHandler(repo.Object, converter, httpAuthorizer.Object, parameterGetter);

            // Act
            // Assert
            await Assert.ThrowsAsync<QueryParameterException>(() => getCirsWithDamagesHandler.HandleAuthorisedAsync(request, logger.Object));
        }

        [Fact]
        public async Task GetAllAsyncThrows()
        {
            // Arrange
            request = requestContext.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "id", "foo" }
            };
            request.Query = new QueryCollection(queryParameters);
            repo.Setup(x => x.GetAllAsync(It.IsAny<string>(), It.IsAny<ISpecification<JObject>>()))
                .ThrowsAsync(new Exception("bar"));
            getCirsWithDamagesHandler = new GetCirsWithDamagesHandler(repo.Object, converter, httpAuthorizer.Object, parameterGetter);

            // Act
            // Assert
            var e = await Assert.ThrowsAsync<Exception>(() => getCirsWithDamagesHandler.HandleAuthorisedAsync(request, logger.Object));
            Assert.Equal("bar", e.Message);
        }

        [Fact]
        public async Task ConverterThrows()
        {
            // Arrange
            request = requestContext.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "id", "foo" }
            };
            request.Query = new QueryCollection(queryParameters);
            mockConverter.Setup(x => x.Convert(It.IsAny<IList<JObject>>()))
                .Throws(new Exception("bar"));
            getCirsWithDamagesHandler = new GetCirsWithDamagesHandler(repo.Object, mockConverter.Object, httpAuthorizer.Object, parameterGetter);

            // Act
            // Assert
            var e = await Assert.ThrowsAsync<Exception>(() => getCirsWithDamagesHandler.HandleAuthorisedAsync(request, logger.Object));
            Assert.Equal("bar", e.Message);
        }

        [Fact]
        public async Task ValidResponse()
        {
            // Arrange
            request = requestContext.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "id", "foo" }
            };
            request.Query = new QueryCollection(queryParameters);
            mockConverter.Setup(x => x.Convert(It.IsAny<IList<JObject>>()))
                .Returns(new CirWithDamagesDto { Cirs = new List<CirWithDamages>() });
            getCirsWithDamagesHandler = new GetCirsWithDamagesHandler(repo.Object, mockConverter.Object, httpAuthorizer.Object, parameterGetter);

            // Act
            var result = await getCirsWithDamagesHandler.HandleAuthorisedAsync(request, logger.Object);
            var content = JsonConvert.DeserializeObject<CirWithDamagesDto>(await result.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(content);
            Assert.NotNull(content.Cirs);
            Assert.Empty(content.Cirs);
        }
    }
#endif
}
