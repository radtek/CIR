using AutoFixture;
using AutoFixture.AutoMoq;
using Cir.Azure.Functions.DTO;
using Cir.BlobStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Azure.Functions.Test.HttpRequestHandler
{
    public class UploadBladeTagHandlerTest
    {
        private readonly UploadBladeTagHandler sut;
        private readonly HttpRequest request;
        private readonly Mock<IHttpAuthorizer> authorizer;
        private readonly Mock<IQueryParameterGetter> parameterGetter;
        private readonly Mock<IFileFactory> fileFactory;
        private readonly Mock<ILogger> logger;
        private readonly Mock<HttpMessageHandler> httpMessageHandler;
        private readonly Mock<HttpResponseMessage> httpResponseMessage;
        private readonly Mock<IFile> file;
        private readonly Fixture fixture;
        private readonly CornisOCRResponse cornisOCRResponse;

        public UploadBladeTagHandlerTest()
        {
            fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            authorizer = new Mock<IHttpAuthorizer>();
            parameterGetter = new Mock<IQueryParameterGetter>();
            fileFactory = new Mock<IFileFactory>();
            httpMessageHandler = new Mock<HttpMessageHandler>();
            httpResponseMessage = new Mock<HttpResponseMessage>();
            file = new Mock<IFile>();
            logger = new Mock<ILogger>();

            var httpClient = new HttpClient(httpMessageHandler.Object);

            var context = new DefaultHttpContext();
            request = context.Request;

            authorizer
                .Setup(a => a.IsAuthorizedAsync(It.IsAny<HttpRequest>()))
                .ReturnsAsync(true);

            parameterGetter
                .Setup(g => g.GetStringAsync("turbineId", request, true))
                .ReturnsAsync("1234");

            parameterGetter
                .Setup(g => g.GetStringAsync("cirId", request, true))
                .ReturnsAsync("4321");

            sut = new UploadBladeTagHandler(
                authorizer.Object,  
                fileFactory.Object,
                parameterGetter.Object,
                httpClient);

            cornisOCRResponse = fixture.Create<CornisOCRResponse>();
        }

        [Fact]
        public async Task SuccessfullFlow()
        {
            // Arrange
            var stream = new MemoryStream(Encoding.UTF8.GetBytes("Test Content"));
            fileFactory.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(file.Object);
            request.Body = stream;
            httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(cornisOCRResponse))
                });

            // Act
            var response = await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            file.Verify(m => m.DeleteFile(), Times.Once());
        }
        
        [Fact]
        public async Task MissingBody()
        {
            // Arrange
            request.Body = new MemoryStream(Encoding.UTF8.GetBytes(""));
            fileFactory.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(file.Object);


            // Act
            var response = await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            file.Verify(m => m.DeleteFile(), Times.Once());
        }

        [Fact]
        public async Task UnsuccessfulRequestFromCornis()
        {
            // Arrange
            var stream = new MemoryStream(Encoding.UTF8.GetBytes("Test Content"));
            fileFactory.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(file.Object);
            request.Body = stream;
            httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest
                });


            // Act
            var response = await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            file.Verify(m => m.DeleteFile(), Times.Once());
        }

        [Fact]
        public async Task NoImagesFromCornis()
        {
            // Arrange
            var stream = new MemoryStream(Encoding.UTF8.GetBytes("Test Content"));
            fileFactory.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(file.Object);
            var cornisNoImages = fixture.Create<CornisOCRResponse>();
            cornisNoImages.Images.Clear();
            request.Body = stream;
            httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(cornisNoImages))
                });


            // Act
            var response = await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            file.Verify(m => m.DeleteFile(), Times.Once());
        }
    }
}
