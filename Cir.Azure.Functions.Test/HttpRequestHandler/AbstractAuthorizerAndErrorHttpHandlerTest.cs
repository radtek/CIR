using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Azure.Functions.Test.HttpRequestHandler
{

    public class AbstractAuthorizerAndErrorHttpHandlerTest
    {
        private readonly Mock<AbstractAuthorizerAndErrorHttpHandler> sut;

        private readonly Mock<IHttpAuthorizer> authorizer;
        private readonly Mock<ILogger> logger;
        private readonly Fixture fixture;

        public AbstractAuthorizerAndErrorHttpHandlerTest()
        {
            fixture = new Fixture();
            authorizer = new Mock<IHttpAuthorizer>();
            authorizer
                .Setup(a => a.IsAuthorizedAsync(It.IsAny<HttpRequest>()))
                .ReturnsAsync(true);
            logger = new Mock<ILogger>();
            sut = new Mock<AbstractAuthorizerAndErrorHttpHandler>(authorizer.Object);
        }

        [Fact]
        public async Task AuthorizationException()
        {
            // Arrange
            authorizer
                .Setup(a => a.IsAuthorizedAsync(It.IsAny<HttpRequest>()))
                .ThrowsAsync(new Exception());

            // Act
            var response = await sut.Object.HandleAsync(null, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

        }

        [Fact]
        public async Task AuthorizationFailed()
        {
            // Arrange
            authorizer
                .Setup(a => a.IsAuthorizedAsync(It.IsAny<HttpRequest>()))
                .ReturnsAsync(false);

            var sut = new Mock<AbstractAuthorizerAndErrorHttpHandler>(authorizer.Object);

            // Act
            var response = await sut.Object.HandleAsync(null, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.Equal("vestas_consumer", response.Headers.WwwAuthenticate.Single().Scheme);
        }

        [Fact]
        public async Task QueryParameterException()
        {
            // Arrange
            sut
                .Setup(s => s.HandleAuthorisedAsync(It.IsAny<HttpRequest>(), It.IsAny<ILogger>(), null))
                .ThrowsAsync(
                    fixture.Create<QueryParameterException>());

            // Act
            var response = await sut.Object.HandleAsync(null, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task PathParameterException()
        {
            // Arrange
            sut
                .Setup(s => s.HandleAuthorisedAsync(It.IsAny<HttpRequest>(), It.IsAny<ILogger>(), null))
                .ThrowsAsync(
                    fixture.Create<PathParameterException>());

            // Act
            var response = await sut.Object.HandleAsync(null, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task BodyParameterException()
        {
            // Arrange
            sut
                .Setup(s => s.HandleAuthorisedAsync(It.IsAny<HttpRequest>(), It.IsAny<ILogger>(), null))
                .ThrowsAsync(
                    fixture.Create<BodyParameterException>());

            // Act
            var response = await sut.Object.HandleAsync(null, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public async Task GeneralException()
        {
            // Arrange
            sut
                .Setup(s => s.HandleAuthorisedAsync(It.IsAny<HttpRequest>(), It.IsAny<ILogger>(), null))
                .ThrowsAsync(
                    fixture.Create<Exception>());

            // Act
            var response = await sut.Object.HandleAsync(null, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }

}
