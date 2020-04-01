using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Cir.Repository;
using ExpectedObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Cir.Azure.Functions.Test.HttpRequestHandler
{
#if false

    public class GetRepairListHandlerTest
    {
        private readonly GetRepairListHandler sut;
        private readonly Mock<IHttpAuthorizer> authorizer;
        private readonly Mock<ICirRepository> repo;
        private readonly Mock<IRepairListConverter> converter;
        private readonly Mock<IQueryParameterGetter> queryParameterGetter;
        private readonly Mock<ILogger> logger;

        private readonly Fixture fixture;
        private readonly HttpRequest request;
        private readonly IList<string> turbineIds;
        private readonly IList<JObject> repoRepairs;
        private readonly RepairListDto dtoRepairs;

        public GetRepairListHandlerTest()
        {
            repo = new Mock<ICirRepository>();
            converter = new Mock<IRepairListConverter>();
            authorizer = new Mock<IHttpAuthorizer>();
            queryParameterGetter = new Mock<IQueryParameterGetter>();
            logger = new Mock<ILogger>();

            fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var context = new DefaultHttpContext();
            request = context.Request;

            turbineIds = fixture.Create<IList<string>>();
            repoRepairs = fixture.Create<IList<JObject>>();
            dtoRepairs = fixture.Create<RepairListDto>();

            authorizer
                .Setup(a => a.IsAuthorizedAsync(It.IsAny<HttpRequest>()))
                .ReturnsAsync(true);

            queryParameterGetter
                .Setup(g => g.GetCollection("id", request))
                .Returns(turbineIds);

            repo
                .Setup(r => r.GetAllAsync(turbineIds, It.IsAny<ISpecification<JObject>>()))
                .ReturnsAsync(repoRepairs);

            converter
                .Setup(c => c.Convert(repoRepairs))
                .Returns(dtoRepairs);

            sut = new GetRepairListHandler(
                repo.Object,
                converter.Object,
                authorizer.Object,
                queryParameterGetter.Object);
        }

        [Fact]
        public async Task SuccessfullFlow()
        {
            // Arrange

            // Act
            var response = await sut.HandleAuthorisedAsync(request, logger.Object);
            
            // Assert
            var content = await response.Content.ReadAsAsync<RepairListDto>();
            dtoRepairs
                .ToExpectedObject()
                .ShouldEqual(content);
        }

        [Fact]
        public async Task GetIdCollectionException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            queryParameterGetter
                .Setup(g => g.GetCollection("id", request))
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
                .Setup(r => r.GetAllAsync(It.IsAny<IList<string>>(), It.IsAny<ISpecification<JObject>>()))
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
            var expected = fixture.Create<Exception>();
            converter
                .Setup(c => c.Convert(It.IsAny<IList<JObject>>()))
                .Throws(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object));

            // Assert
            Assert.Equal(expected, actual);
        }
    }
#endif
}
