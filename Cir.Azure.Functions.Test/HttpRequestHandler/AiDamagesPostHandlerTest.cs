using AutoFixture;
using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Azure.Functions.Test.HttpRequestHandler
{
    public class AiDamagesPostHandlerTest
    {
        private readonly Mock<ICirRepository> cirRepo;
        private readonly Mock<IQueryParameterGetter> parameterGetter;
        private readonly Mock<ILogger> logger;
        private readonly Mock<IHttpAuthorizer> httpAuthorizer;
        private readonly Mock<IDefectDetectionItemRepository> defectDetectionItemRepo;
        private readonly Fixture fixture;
        private AiDamagesPostHandler aiDamagesHandler;
        private AIDamages requestObject;
        private HttpContext requestContext = new DefaultHttpContext();
        private HttpRequest request;

        public AiDamagesPostHandlerTest()
        {
            cirRepo = new Mock<ICirRepository>();
            defectDetectionItemRepo = new Mock<IDefectDetectionItemRepository>();
            parameterGetter = new Mock<IQueryParameterGetter>();
            logger = new Mock<ILogger>();
            httpAuthorizer = new Mock<IHttpAuthorizer>();
            fixture = new Fixture();
        }

        [Fact]
        public async Task MalformedRequestObject()
        {
            // Arrange
            request = requestContext.Request;
            var dummyObject = new DummyObject { Test = "lkasjd" };
            request.Body = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dummyObject)));
            aiDamagesHandler = new AiDamagesPostHandler(cirRepo.Object, defectDetectionItemRepo.Object, httpAuthorizer.Object, parameterGetter.Object);

            // Act
            var result = await aiDamagesHandler.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task NoTurbineId()
        {
            // Arrange
            request = requestContext.Request;
            requestObject = fixture.Create<AIDamages>();
            requestObject.TurbineId = null;
            request.Body = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(requestObject)));
            aiDamagesHandler = new AiDamagesPostHandler(cirRepo.Object, defectDetectionItemRepo.Object, httpAuthorizer.Object, parameterGetter.Object);

            // Act
            var result = await aiDamagesHandler.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task NoCirId()
        {
            // Arrange
            request = requestContext.Request;
            requestObject = fixture.Create<AIDamages>();
            requestObject.CirId = null;
            request.Body = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(requestObject)));
            aiDamagesHandler = new AiDamagesPostHandler(cirRepo.Object, defectDetectionItemRepo.Object, httpAuthorizer.Object, parameterGetter.Object);

            // Act
            var result = await aiDamagesHandler.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task FailedStoring()
        {
            // Arrange
            request = requestContext.Request;
            requestObject = fixture.Create<AIDamages>();
            request.Body = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(requestObject)));
            cirRepo.Setup(x => x.StoreFileByCirAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(false);
            aiDamagesHandler = new AiDamagesPostHandler(cirRepo.Object, defectDetectionItemRepo.Object, httpAuthorizer.Object, parameterGetter.Object);

            // Act
            var result = await aiDamagesHandler.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
        }

        [Fact]
        public async Task ValidCall()
        {
            // Arrange
            request = requestContext.Request;
            requestObject = fixture.Create<AIDamages>();
            request.Body = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(requestObject)));
            cirRepo.Setup(x => x.StoreFileByCirAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true);
            aiDamagesHandler = new AiDamagesPostHandler(cirRepo.Object, defectDetectionItemRepo.Object, httpAuthorizer.Object, parameterGetter.Object);

            // Act
            var result = await aiDamagesHandler.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task DeletesDefectDetectionItem()
        {
            // Arrange
            request = requestContext.Request;
            requestObject = fixture.Create<AIDamages>();
            request.Body = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(requestObject)));
            cirRepo.Setup(x => x.StoreFileByCirAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true);
            aiDamagesHandler = new AiDamagesPostHandler(cirRepo.Object, defectDetectionItemRepo.Object, httpAuthorizer.Object, parameterGetter.Object);

            // Act
            await aiDamagesHandler.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            defectDetectionItemRepo
                .Verify(r => r.DeleteAsync(requestObject.Id), Times.Once);
        }

        private class DummyObject
        {
            public string Test { get; set; }
        }
    }
}
