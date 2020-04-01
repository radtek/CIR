using AutoFixture;
using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
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
using System.Net.Http.Formatting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Azure.Functions.Test.HttpRequestHandler
{
    public class DefectDetectionHandlerTest
    {
        private readonly DefectDetectionHandler sut;
        private readonly Fixture fixture;
        private readonly Mock<IHttpAuthorizer> authorizer;
        private readonly Mock<HttpMessageHandler> httpMessageHandler;
        private readonly Mock<ILogger> logger;
        private readonly Mock<IDefectDetectionRequestConverter> requestConverter;
        private readonly Mock<IDefectDetectionItemConverter> itemConverter;
        private readonly Mock<IDefectDetectionItemRepository> repo;

        private readonly HttpRequest request;
        private readonly DefectDetectionRequest dto;
        private readonly CornisDefectDetectionRequest cornisRequestDto;
        private readonly CornisDefectDetectionResponse cornisResponseDto;
        private readonly DefectDetectionItem defectDetectionItem;

        public DefectDetectionHandlerTest()
        {
            fixture = new Fixture();
            authorizer = new Mock<IHttpAuthorizer>();
            logger = new Mock<ILogger>();
            requestConverter = new Mock<IDefectDetectionRequestConverter>();
            itemConverter = new Mock<IDefectDetectionItemConverter>();
            repo = new Mock<IDefectDetectionItemRepository>();
            httpMessageHandler = new Mock<HttpMessageHandler>();

            var context = new DefaultHttpContext();
            request = context.Request;

            var httpClient = new HttpClient(httpMessageHandler.Object);
            dto = fixture.Create<DefectDetectionRequest>();
            cornisRequestDto = fixture.Create<CornisDefectDetectionRequest>();
            cornisResponseDto = fixture.Create<CornisDefectDetectionResponse>();
            defectDetectionItem = fixture.Create<DefectDetectionItem>();

            requestConverter
                .Setup(c => c.Convert(It.IsAny<DefectDetectionRequest>()))
                .Returns(cornisRequestDto);

            itemConverter
                .Setup(c => c.Convert(It.IsAny<CornisDefectDetectionRequest>(), It.IsAny<CornisDefectDetectionResponse>()))
                .Returns(defectDetectionItem);
            
            httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(cornisResponseDto), Encoding.UTF8, "application/json")
                });

            request.Body =
                new MemoryStream(
                    Encoding.UTF8.GetBytes(
                        JsonConvert.SerializeObject(dto)));

            sut = new DefectDetectionHandler(
                authorizer.Object,
                httpClient,
                requestConverter.Object,
                itemConverter.Object,
                repo.Object);
        }

        [Fact]
        public async Task BadRequestBodyThrowsBodyParameterException()
        {
            // Arrange
            request.Body =
                new MemoryStream(
                    Encoding.UTF8.GetBytes("{}"));

            // Act
            await Assert.ThrowsAsync<BodyParameterException>(() => sut.HandleAuthorisedAsync(request, logger.Object));

            // Assert
        }

        [Fact]
        public async Task RequestBodyIsUsedAsConverterInput()
        {
            // Arrange
            DefectDetectionRequest actualConverterInput = null;
            requestConverter
                .Setup(c => c.Convert(It.IsAny<DefectDetectionRequest>()))
                .Callback<DefectDetectionRequest>(i => actualConverterInput = i);

            // Act
            await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.True(JToken.DeepEquals(JToken.FromObject(dto), JToken.FromObject(actualConverterInput)));
        }


        [Fact]
        public async Task ConverterOutputIsSentToCornis()
        {
            // Arrange
            string actualBody = null;
            httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Callback<HttpRequestMessage, CancellationToken>(async (r, _) => actualBody = await r.Content.ReadAsStringAsync())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(cornisResponseDto), Encoding.UTF8, "application/json")
                });

            // Act
            await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.True(JToken.DeepEquals(JToken.FromObject(cornisRequestDto), JToken.Parse(actualBody)));
        }

        [Fact]
        public async Task CornisOkResponseGiveOkResponse()
        {
            // Arrange

            // Act
            var response = await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CornisErrorResponseGiveInternalServerError()
        {
            // Arrange
            httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound
                });

            // Act
            var response = await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [Fact]
        public async Task CornisResponseIsStored()
        {

            // Arrange
            DefectDetectionItem actual = null;
            repo
                .Setup(r => r.SetAsync(It.IsAny<DefectDetectionItem>()))
                .Callback<DefectDetectionItem>(i => actual = i)
                .Returns(Task.CompletedTask);

            // Act
            await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.True(JToken.DeepEquals(JToken.FromObject(defectDetectionItem), JToken.FromObject(actual)));
        }
    }
}
