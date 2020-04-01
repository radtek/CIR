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
    public class VoCirListHandlerTest
    {
        private readonly Mock<ICirRepository> repo;
        private readonly Mock<IHttpAuthorizer> httpAuthorizer;
        private readonly Mock<ILogger> logger;
        private readonly Mock<IVoCirDetailsConverter> mockConverter;
        private readonly IVoCirDetailsConverter converter;
        private readonly IQueryParameterGetter parameterGetter;
        private HttpContext requestContext = new DefaultHttpContext();
        private HttpRequest request;
        private VoCirDetailsHandler voCirDetailsHandler;

        public VoCirListHandlerTest()
        {
            repo = new Mock<ICirRepository>();
            httpAuthorizer = new Mock<IHttpAuthorizer>();
            logger = new Mock<ILogger>();
            mockConverter = new Mock<IVoCirDetailsConverter>();
            converter = new VoCirDetailsConverter();
            parameterGetter = new QueryParameterGetter();
        }

        [Fact]
        public async Task NoTurbineIdInQuery()
        {
            // Arrange
            request = requestContext.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "foo", "bar" }
            };
            request.Query = new QueryCollection(queryParameters);
            voCirDetailsHandler = new VoCirDetailsHandler(repo.Object, converter, httpAuthorizer.Object, parameterGetter);

            // Act
            // Assert
            await Assert.ThrowsAsync<QueryParameterException>(() => voCirDetailsHandler.HandleAuthorisedAsync(request, logger.Object));
        }

        [Fact]
        public async Task GetAllAsyncThrows()
        {
            // Arrange
            request = requestContext.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "turbineId", "foo" }
            };
            request.Query = new QueryCollection(queryParameters);
            repo.Setup(x => x.GetAllAsync(It.IsAny<string>(), It.IsAny<ISpecification<JObject>>()))
                .ThrowsAsync(new Exception("bar"));
            voCirDetailsHandler = new VoCirDetailsHandler(repo.Object, converter, httpAuthorizer.Object, parameterGetter);

            // Act
            // Assert
            var e = await Assert.ThrowsAsync<Exception>(() => voCirDetailsHandler.HandleAuthorisedAsync(request, logger.Object));
            Assert.Equal("bar", e.Message);
        }

        [Fact]
        public async Task ConverterThrows()
        {
            // Arrange
            request = requestContext.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "turbineId", "foo" }
            };
            request.Query = new QueryCollection(queryParameters);
            mockConverter.Setup(x => x.Convert(It.IsAny<IList<JObject>>()))
                .Throws(new Exception("bar"));
            voCirDetailsHandler = new VoCirDetailsHandler(repo.Object, mockConverter.Object, httpAuthorizer.Object, parameterGetter);

            // Act
            // Assert
            var e = await Assert.ThrowsAsync<Exception>(() => voCirDetailsHandler.HandleAuthorisedAsync(request, logger.Object));
            Assert.Equal("bar", e.Message);
        }

        [Fact]
        public async Task ValidResponse()
        {
            // Arrange
            request = requestContext.Request;
            var queryParameters = new Dictionary<string, StringValues>
            {
                { "turbineId", "foo" }
            };
            request.Query = new QueryCollection(queryParameters);
            mockConverter.Setup(x => x.Convert(It.IsAny<IList<JObject>>()))
                .Returns(new VoCirDetailsDto { Cirs = new List<VoCirDetails>() });
            voCirDetailsHandler = new VoCirDetailsHandler(repo.Object, mockConverter.Object, httpAuthorizer.Object, parameterGetter);

            // Act
            var result = await voCirDetailsHandler.HandleAuthorisedAsync(request, logger.Object);
            var content = JsonConvert.DeserializeObject<VoCirListDto>(await result.Content.ReadAsStringAsync());

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(content);
            Assert.NotNull(content.Cirs);
            Assert.Empty(content.Cirs);
        }
    }
#endif
}
