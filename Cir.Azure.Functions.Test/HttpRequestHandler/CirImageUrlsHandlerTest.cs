using AutoFixture;
using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Azure.Functions.Test.HttpRequestHandler
{
#if false
    public class CirImageUrlsHandlerTest
    {
        private readonly CirImageUrlsHandler sut;
        private readonly Mock<ICirRepository> repo;
        private readonly Mock<ICirImageUrlsConverter> converter;
        private readonly Mock<IHttpAuthorizer> authorizer;
        private readonly Mock<IQueryParameterGetter> queryParameterGetter;
        private readonly Mock<ILogger> logger;
        private readonly HttpRequest request;
        private readonly Fixture fixture;
        private readonly string turbineId;
        private readonly string cirId;
        private readonly JObject cir;
        private readonly CirImageUrls dto;

        public CirImageUrlsHandlerTest()
        {
            repo = new Mock<ICirRepository>();
            converter = new Mock<ICirImageUrlsConverter>();
            authorizer = new Mock<IHttpAuthorizer>();
            queryParameterGetter = new Mock<IQueryParameterGetter>();
            logger = new Mock<ILogger>();

            var context = new DefaultHttpContext();
            request = context.Request;

            fixture = new Fixture();
            turbineId = fixture.Create<string>();
            cirId = fixture.Create<string>();
            cir = new JObject();
            dto = fixture.Create<CirImageUrls>();

            authorizer
                .Setup(a => a.IsAuthorizedAsync(It.IsAny<HttpRequest>()))
                .ReturnsAsync(true);

            queryParameterGetter
                .Setup(g => g.GetString("turbineId", request, true))
                .Returns(turbineId);
            queryParameterGetter
                .Setup(g => g.GetString("cirId", request, true))
                .Returns(cirId);

            repo
                .Setup(r => r.GetExactlyOneAsync(turbineId, It.IsAny<ISpecification<JObject>>()))
                .ReturnsAsync(cir);

            converter
                .Setup(c => c.Convert(cir))
                .Returns(dto);

            sut = new CirImageUrlsHandler(
                repo.Object,
                converter.Object,
                authorizer.Object,
                queryParameterGetter.Object);
        }

        [Fact]
        public async Task ConverterException()
        {
            // Arrange
            var expected = new Exception();
            converter
                .Setup(c => c.Convert(cir))
                .Throws(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetTurbineId()
        {
            // Arrange
            var expected = new Exception();
            queryParameterGetter
                .Setup(g => g.GetString("turbineId", request, true))
                .Throws(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetCirId()
        {
            // Arrange
            var expected = new Exception();
            queryParameterGetter
                .Setup(g => g.GetString("cirId", request, true))
                .Throws(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task RepositoryException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            repo
                .Setup(r => r.GetExactlyOneAsync(It.IsAny<string>(), It.IsAny<ISpecification<JObject>>()))
                .ThrowsAsync(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task RepositoryNullResult()
        {
            // Arrange
            repo
                .Setup(r => r.GetExactlyOneAsync(turbineId, It.IsAny<ISpecification<JObject>>()))
                .ReturnsAsync((JObject)null);

            // Act
            var response = await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task SuccessfullFlow()
        {
            // Arrange

            // Act
            var response = await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(dto, await response.Content.ReadAsAsync<CirImageUrls>());
        }

    }
#endif
}
