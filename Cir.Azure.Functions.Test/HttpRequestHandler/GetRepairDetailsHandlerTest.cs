using AutoFixture;
using AutoFixture.AutoMoq;
using Cir.Repository;
using ExpectedObjects;
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
    public class GetRepairDetailsHandlerTest
    {
        private readonly GetRepairDetailsHandler sut;
        private readonly Mock<ICirRepository> repo;
        private readonly Mock<IRepairDetailsConverter> converter;
        private readonly Mock<IHttpAuthorizer> authorizer;
        private readonly Mock<IQueryParameterGetter> parameterGetter;
        private readonly Mock<ILogger> logger;
        private readonly Fixture fixture;
        private readonly HttpRequest request;
        private readonly string turbineId;
        private readonly string repairId;
        private readonly JObject repair;
        private readonly RepairDetailsDto dto;

        public GetRepairDetailsHandlerTest()
        {
            repo = new Mock<ICirRepository>();
            converter = new Mock<IRepairDetailsConverter>();
            authorizer = new Mock<IHttpAuthorizer>();
            parameterGetter = new Mock<IQueryParameterGetter>();
            logger = new Mock<ILogger>();

            fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            repair = fixture.Create<JObject>();
            dto = fixture.Create<RepairDetailsDto>();

            turbineId = fixture.Create<string>();
            repairId = fixture.Create<string>();

            var context = new DefaultHttpContext();
            request = context.Request;

            authorizer
                .Setup(a => a.IsAuthorizedAsync(It.IsAny<HttpRequest>()))
                .ReturnsAsync(true);

            parameterGetter
                .Setup(g => g.GetString("turbineId", request, true))
                .Returns(turbineId);

            parameterGetter
                .Setup(g => g.GetString("repairId", request, true))
                .Returns(repairId);

            repo
                .Setup(r => r.GetExactlyOneAsync(turbineId, It.IsAny<ISpecification<JObject>>()))
                .ReturnsAsync(repair);

            converter
                .Setup(c => c.Convert(repair))
                .Returns(dto);

            sut = new GetRepairDetailsHandler(
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
            var content = await response.Content.ReadAsAsync<RepairDetailsDto>();
            dto
                .ToExpectedObject()
                .ShouldEqual(content);
        }

        [Fact]
        public async Task Specification()
        {
            // Arrange
            var spec = new AndSpecification<JObject>(
                new RepairSpecification(),
                new CirIdSpecification(repairId));

            // Act
            var response = await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            repo
                .Verify(r => r.GetExactlyOneAsync(turbineId, It.Is<ISpecification<JObject>>(
                    s => s.ToString() == spec.ToString())));
        }

      
        [Fact]
        public async Task ConverterException()
        {
            // Arrange
            var expected = new Exception();
            converter
                .Setup(c => c.Convert(repair))
                .Throws(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetTurbineIdException()
        {
            // Arrange
            var expected = new Exception();
            parameterGetter
                .Setup(g => g.GetString("turbineId", request, true))
                .Throws(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetRepairIdException()
        {
            // Arrange
            var expected = new Exception();
            parameterGetter
                .Setup(g => g.GetString("repairId", request, true))
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
                .Setup(r => r.GetExactlyOneAsync(It.IsAny<string>(), It.IsAny<ISpecification<JObject>>()))
                .ReturnsAsync((JObject)null);

            // Act
            var response = await sut.HandleAuthorisedAsync(request, logger.Object);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
#endif
}
