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
    
    public class AiDamagesGetHandlerTest
    {
        private readonly AiDamagesGetHandler sut;
        private readonly Mock<ICirRepository> repo;
        private readonly Mock<IAIDamagesForCirConverter> converter;
        private readonly Mock<IHttpAuthorizer> authorizer;
        private readonly Mock<IQueryParameterGetter> queryParameterGetter;
        private readonly Mock<ILogger> logger;
        private readonly HttpRequest request;
        private readonly Fixture fixture;
        private readonly string turbineId;
        private readonly string cirId;
        private readonly string fileContent;
        private readonly AIDamagesForCir aiDamagesForCir;

        public AIDamages aiDamages { get; }

        public AiDamagesGetHandlerTest()
        {
            repo = new Mock<ICirRepository>();
            converter = new Mock<IAIDamagesForCirConverter>();
            authorizer = new Mock<IHttpAuthorizer>();
            queryParameterGetter = new Mock<IQueryParameterGetter>();
            logger = new Mock<ILogger>();

            var context = new DefaultHttpContext();
            request = context.Request;

            fixture = new Fixture();
            turbineId = fixture.Create<string>();
            cirId = fixture.Create<string>();
            fileContent = "";
            aiDamagesForCir = fixture.Create<AIDamagesForCir>();
            aiDamages = fixture.Create<AIDamages>();

            authorizer
                .Setup(a => a.IsAuthorizedAsync(It.IsAny<HttpRequest>()))
                .ReturnsAsync(true);

            queryParameterGetter
                .Setup(g => g.GetStringAsync("turbineId", request, true))
                .ReturnsAsync(turbineId);
            queryParameterGetter
                .Setup(g => g.GetStringAsync("cirId", request, true))
                .ReturnsAsync(cirId);

            repo
                .Setup(r => r.GetFileByCirAsync(turbineId, cirId, It.IsAny<string>()))
                .ReturnsAsync(fileContent);

            converter
                .Setup(c => c.Convert(It.IsAny<AIDamages>()))
                .Returns(aiDamagesForCir);

            sut = new AiDamagesGetHandler(
                authorizer.Object,
                queryParameterGetter.Object,
                repo.Object,
                converter.Object);
        }

        [Fact]
        public async Task ConverterException()
        {
            // Arrange
            var expected = new Exception();
            converter
                .Setup(c => c.Convert(null))
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
                .Setup(g => g.GetStringAsync("turbineId", request, true))
                .ThrowsAsync(expected);

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
                .Setup(g => g.GetStringAsync("cirId", request, true))
                .ThrowsAsync(expected);

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
                .Setup(r => r.GetFileByCirAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
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
                .Setup(r => r.GetFileByCirAsync(turbineId,cirId,  It.IsAny<string>()))
                .ReturnsAsync((string)null);

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
            Assert.Equal(aiDamagesForCir, await response.Content.ReadAsAsync<AIDamagesForCir>());
        }

    }
}
