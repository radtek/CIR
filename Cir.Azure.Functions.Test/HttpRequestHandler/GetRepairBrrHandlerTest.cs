using AutoFixture;
using AutoFixture.AutoMoq;
using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Azure.Functions.Test.HttpRequestHandler
{
    
    public class GetRepairBrrHandlerTest
    {
        private readonly GetRepairBrrHandler sut;
        private readonly HttpRequest request;
        private readonly Mock<IBrrRepository> repo;
        private readonly Mock<IBrrConverter> converter;
        private readonly Mock<IHttpAuthorizer> authorizer;
        private readonly Mock<IQueryParameterGetter> parameterGetter;
        private readonly Mock<ILogger> logger;
        private readonly Fixture fixture;
        private readonly IList<string> turbineIds;
        private readonly IList<string> repairIds;
        private readonly IList<JObject> repoRepairs;
        private readonly RepairBrrDto dto;

        public GetRepairBrrHandlerTest()
        {
            fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            repo = new Mock<IBrrRepository>();
            converter = new Mock<IBrrConverter>();
            authorizer = new Mock<IHttpAuthorizer>();
            parameterGetter = new Mock<IQueryParameterGetter>();
            logger = new Mock<ILogger>();

            turbineIds = fixture.Create<IList<string>>();
            repairIds = fixture.Create<IList<string>>();
            repoRepairs = fixture.Create<IList<JObject>>();
            dto = fixture.Create<RepairBrrDto>();

            var context = new DefaultHttpContext();
            request = context.Request;

            authorizer
                .Setup(a => a.IsAuthorizedAsync(It.IsAny<HttpRequest>()))
                .ReturnsAsync(true);

            parameterGetter
                .Setup(g => g.GetCollectionAsync("turbineId", request))
                .ReturnsAsync(turbineIds);

            parameterGetter
                .Setup(g => g.GetCollectionAsync("repairId", request))
                .ReturnsAsync(repairIds);

            
            repo
                .Setup(r => r.GetAllAsync(turbineIds, repairIds))
                .ReturnsAsync(repoRepairs);

            converter
                .Setup(c => c.Convert(repoRepairs))
                .Returns(dto);


            sut = new GetRepairBrrHandler(
                repo.Object,
                converter.Object,
                authorizer.Object,
                parameterGetter.Object);
        }

        [Fact]
        public async Task SuccessfullFlow()
        {
            // Arrange

            // Act
            var response = await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(dto, await response.Content.ReadAsAsync<RepairBrrDto>());
        }

        [Fact]
        public async Task GetTurbineId()
        {
            // Arrange
            var expected = new Exception();
            parameterGetter
                .Setup(g => g.GetCollectionAsync("turbineId", request))
                .ThrowsAsync(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetRepairId()
        {
            // Arrange
            var expected = new Exception();
            parameterGetter
                .Setup(g => g.GetCollectionAsync("repairId", request))
                .ThrowsAsync(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task ConverterException()
        {
            // Arrange
            var expected = new Exception();
            converter
                .Setup(c => c.Convert(repoRepairs))
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
                .Setup(r => r.GetAllAsync(turbineIds, repairIds))
                .ThrowsAsync(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object));

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
