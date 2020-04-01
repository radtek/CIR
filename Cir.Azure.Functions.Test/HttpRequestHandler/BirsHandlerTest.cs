using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Cir.Azure.Functions;
using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Cir.Azure.Functions.Test.HttpRequestHandler
{
    public class BirsHandlerTest
    {
        private BirsHandler sut;
        private readonly Fixture fixture;
        private readonly Mock<IBirRepository> repo;
        private readonly Mock<IBirConverter> converter;
        private readonly Mock<IHttpAuthorizer> authorizer;
        private readonly Mock<IQueryParameterGetter> parameterGetter;
        private readonly Mock<ILogger> logger;

        private readonly IList<string> turbineIds;
        private readonly bool? isAnnual;
        private readonly IList<int> modifiedYears;
        private readonly string format;
        private readonly Repository.Bir bir;
        private readonly IList<Repository.Bir> birs;
        private readonly JObject dto;
        private readonly HttpRequest request;


        public BirsHandlerTest()
        {
            fixture = new Fixture();

            repo = new Mock<IBirRepository>();
            converter = new Mock<IBirConverter>();
            authorizer = new Mock<IHttpAuthorizer>();
            parameterGetter = new Mock<IQueryParameterGetter>();
            logger = new Mock<ILogger>();

            turbineIds = fixture.Create<IList<string>>();
            isAnnual = fixture.Create<bool?>();
            modifiedYears = fixture.Create<List<int>>();
            format = fixture.Create<string>();
            bir = fixture.Create<Repository.Bir>();
            birs = new[] { bir };
            dto = JObject.Parse("{\"c\": \"d\"}");
            var context = new DefaultHttpContext();
            request = context.Request;

            parameterGetter
                .Setup(g => g.GetCollectionAsync("turbineId", It.IsAny<HttpRequest>()))
                .ReturnsAsync(turbineIds);
            parameterGetter
                .Setup(g => g.GetValueAsync<bool?>("isAnnual", It.IsAny<HttpRequest>(), false))
                .ReturnsAsync(isAnnual);
            parameterGetter
                .Setup(g => g.GetCollectionAsync<int>("modifiedYears", It.IsAny<HttpRequest>()))
                .ReturnsAsync(modifiedYears);
            parameterGetter
                .Setup(g => g.GetEnumAsync("format", It.IsAny<IList<string>>(), It.IsAny<HttpRequest>(), false))
                .ReturnsAsync(format);

            repo
                .Setup(r => r.GetAsync(turbineIds, isAnnual, modifiedYears, It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(birs);

            converter
                .Setup(c => c.Convert(bir))
                .Returns(dto);
            converter
                .Setup(c => c.Convert(birs))
                .Returns(dto);


            sut = new BirsHandler(
                repo.Object,
                converter.Object,
                authorizer.Object,
                parameterGetter.Object
                );
        }


        [Fact]
        public async Task SuccessList()
        {
            // Arrange
            converter
                .Setup(c => c.Convert(It.IsAny<Repository.Bir>()))
                .Throws(new Exception("should not convert single object when requesting list"));

            // Act
            var result = await sut.HandleAuthorisedAsync(request, logger.Object, null);

            // Assert
            Assert.Equal(dto.ToString(), await result.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task SuccessSingle()
        {
            // Arrange
            converter
                .Setup(c => c.Convert(It.IsAny<IList<Repository.Bir>>()))
                .Throws(new Exception("should not convert list of objects when requesting single"));

            // Act
            var result = await sut.HandleAuthorisedAsync(request, logger.Object, "123");

            // Assert
            Assert.Equal(dto.ToString(), await result.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task ParameterTurbineIdException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            parameterGetter
                .Setup(g => g.GetCollectionAsync("turbineId", It.IsAny<HttpRequest>()))
                .ThrowsAsync(expected);
            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, null));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task ParameterIsAnnualException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            parameterGetter
                .Setup(g => g.GetValueAsync<bool?>("isAnnual", It.IsAny<HttpRequest>(), false))
                .ThrowsAsync(expected);
            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, null));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task ParameterModifiedYearsException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            parameterGetter
                .Setup(g => g.GetCollectionAsync<int>("modifiedYears", It.IsAny<HttpRequest>()))
                .ThrowsAsync(expected);
            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, null));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task ParameterFormatException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            parameterGetter
                .Setup(g => g.GetEnumAsync("format", It.IsAny<IList<string>>(), It.IsAny<HttpRequest>(), false))
                .ThrowsAsync(expected);
            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, null));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task RepoException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            repo
                .Setup(r => r.GetAsync(It.IsAny<IList<string>>(), It.IsAny<bool?>(), It.IsAny<IList<int>>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Throws(expected);
            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, null));

            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public async Task ConverterExceptionSingle()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            converter
                .Setup(c => c.Convert(It.IsAny<Repository.Bir>()))
                .Throws(expected);
            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, "123"));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task ConverterExceptionMany()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            converter
                .Setup(c => c.Convert(It.IsAny<IList<Repository.Bir>>()))
                .Throws(expected);
            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, null));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task NotFoundSingle()
        {
            // Arrange
            repo
                .Setup(r => r.GetAsync(It.IsAny<List<string>>(), It.IsAny<bool?>(), It.IsAny<IList<int>>(), It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(new List<Repository.Bir>());

            // Act
            var result = await sut.HandleAuthorisedAsync(request, logger.Object, "123");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }


        [Fact]
        public async Task NotFoundMany()
        {
            // Arrange
            repo
                .Setup(r => r.GetAsync(It.IsAny<string>(), It.IsAny<bool?>(), It.IsAny<IList<int>>(), It.IsAny<string>(), It.IsAny<bool>()))
                .ReturnsAsync(new List<Repository.Bir>());
            converter
                .Setup(c => c.Convert(new List<Repository.Bir>()))
                .Returns(dto);

            // Act
            var result = await sut.HandleAuthorisedAsync(request, logger.Object, null);

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(dto.ToString(), await result.Content.ReadAsStringAsync());
        }
        



    }
}
