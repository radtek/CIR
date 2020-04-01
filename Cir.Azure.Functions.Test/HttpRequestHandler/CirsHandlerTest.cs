using AutoFixture;
using Cir.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Azure.Functions.Test.HttpRequestHandler
{
    public class CirsHandlerTest
    {
        private readonly CirsHandler sut;
        private readonly Mock<ICirRepository> repo;
        private readonly Mock<IBirRepository> birRepo;
        private readonly Mock<IHttpAuthorizer> authorizer;
        private readonly Mock<IQueryParameterGetter> parameterGetter;
        private readonly Mock<ISpecificationBuilderFactory> specBuilderFactory;
        private readonly Mock<ILogger> logger;
        private readonly Mock<IConverter> converter;
        private readonly Mock<ISpecificationBuilder> specBuilder;
        private readonly Mock<ISpecification> spec;
        private readonly Fixture fixture;


        private readonly HttpRequest request;
        private readonly JObject dto;

        public CirsHandlerTest()
        {
            fixture = new Fixture();
            repo = new Mock<ICirRepository>();
            birRepo = new Mock<IBirRepository>();
            authorizer = new Mock<IHttpAuthorizer>();
            parameterGetter = new Mock<IQueryParameterGetter>();
            specBuilderFactory = new Mock<ISpecificationBuilderFactory>();
            logger = new Mock<ILogger>();
            converter = new Mock<IConverter>();
            specBuilder = new Mock<ISpecificationBuilder>();
            spec = new Mock<ISpecification>();

            var context = new DefaultHttpContext();
            request = context.Request;

            var turbineIds = fixture.Create<IList<string>>();
            var format = fixture.Create<string>();
            var hasDamages = fixture.Create<bool?>();
            var cirs = fixture.CreateMany<JObject>(1).ToList();
            var birs = fixture.CreateMany<Repository.Bir>(1).ToList();
            dto = JObject.Parse("{\"dummyProperty\": \"dummyValue\"}");

            parameterGetter
                .Setup(p => p.GetCollectionAsync("turbineId", It.IsAny<HttpRequest>()))
                .ReturnsAsync(turbineIds);
            parameterGetter
                .Setup(p => p.GetEnumAsync("format", It.IsAny<IList<string>>(), It.IsAny<HttpRequest>(), true))
                .ReturnsAsync(format);
            parameterGetter
                .Setup(p => p.GetValueAsync<bool?>("hasDamages", It.IsAny<HttpRequest>(), false))
                .ReturnsAsync(hasDamages);

            specBuilderFactory
                .Setup(f => f.Create())
                .Returns(specBuilder.Object);

            specBuilder
                .Setup(b => b.Build())
                .Returns(spec.Object);
            specBuilder
                .Setup(b => b.BladeInspection())
                .Returns(specBuilder.Object);
            specBuilder
                .Setup(b => b.CirGuid(It.IsAny<string>()))
                .Returns(specBuilder.Object);
            specBuilder
                .Setup(b => b.CirIds(It.IsAny<IList<int>>()))
                .Returns(specBuilder.Object);
            specBuilder
                .Setup(b => b.Damages(It.IsAny<bool?>()))
                .Returns(specBuilder.Object);

            birs.First().RelatedCirs = new List<int>();

            repo
                .Setup(r => r.GetAllAsync(turbineIds, spec.Object))
                .ReturnsAsync(cirs);

            birRepo
                .Setup(r => r.GetAsync(turbineIds, null, It.IsAny<IList<int>>(), null, true))
                .ReturnsAsync(birs);

            converter
                .SetupGet(c => c.Format)
                .Returns(format.ToLower());
            converter
                .Setup(c => c.Convert(cirs))
                .Returns(dto);
            converter
                .Setup(c => c.Convert(cirs[0]))
                .Returns(dto);




            sut = new CirsHandler(
                repo.Object,
                birRepo.Object,
                new[] { converter.Object },
                authorizer.Object,
                parameterGetter.Object,
                specBuilderFactory.Object);
        }

        [Fact]
        public async Task Success()
        {
            // Arrange

            // Act
            var result = await sut.HandleAuthorisedAsync(request, logger.Object, null);

            // Assert
            Assert.Equal(dto.ToString(), await result.Content.ReadAsStringAsync());
        }


        [Fact]
        public async Task GetTurbineIdException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            parameterGetter
                .Setup(p => p.GetCollectionAsync("turbineId", It.IsAny<HttpRequest>()))
                .ThrowsAsync(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, null));

            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public async Task GetFormatException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            parameterGetter
                .Setup(p => p.GetEnumAsync("format", It.IsAny<IList<string>>(), It.IsAny<HttpRequest>(), true))
                .ThrowsAsync(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, null));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetHasDamagesException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            parameterGetter
                .Setup(p => p.GetValueAsync<bool?>("hasDamages", It.IsAny<HttpRequest>(), false))
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
                .Setup(r => r.GetAllAsync(It.IsAny<IList<string>>(), It.IsAny<ISpecification>()))
                .ThrowsAsync(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, null));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task SpecBuilderFactoryException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            specBuilderFactory
                .Setup(f => f.Create())
                .Throws(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, null));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task SpecBuilderBuildException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            specBuilder
                .Setup(b => b.Build())
                .Throws(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, null));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task ListConverterException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            converter
                .Setup(c => c.Convert(It.IsAny<JObject>()))
                .Throws(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, "123"));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task SingleConverterException()
        {
            // Arrange
            var expected = fixture.Create<Exception>();
            converter
                .Setup(c => c.Convert(It.IsAny<IList<JObject>>()))
                .Throws(expected);

            // Act
            var actual = await Assert.ThrowsAsync<Exception>(() => sut.HandleAuthorisedAsync(request, logger.Object, null));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task SingleConverterUsedWhenCirIdIsGiven()
        {
            // Arrange

            // Act
            await sut.HandleAuthorisedAsync(request, logger.Object, "123");

            // Assert
            converter
                .Verify(c => c.Convert(It.IsAny<JObject>()));
        }

        [Fact]
        public async Task ListConverterUsedWhenCirIdIsOmitted()
        {
            // Arrange

            // Act
            await sut.HandleAuthorisedAsync(request, logger.Object, null);

            // Assert
            converter
                .Verify(c => c.Convert(It.IsAny<IList<JObject>>()));
        }

        [Fact]
        public async Task UsesCorrectSpecification()
        {
            // Arrange
            string cirGuid = "123";
            bool? hasDamages = true;

            var specBuilder = new Mock<ISpecificationBuilder>(MockBehavior.Strict);
            specBuilder
                .Setup(b => b.BladeInspection())
                .Returns(specBuilder.Object);
            specBuilder
                .Setup(b => b.CirIds(It.IsAny<IList<int>>()))
                .Returns(specBuilder.Object);
            specBuilder
                .Setup(b => b.CirGuid(cirGuid))
                .Returns(specBuilder.Object);
            specBuilder
                .Setup(b => b.Damages(hasDamages))
                .Returns(specBuilder.Object);
            specBuilder
                .Setup(b => b.Build())
                .Returns(spec.Object);

            specBuilderFactory
                .Setup(f => f.Create())
                .Returns(specBuilder.Object);

            // Act
            await sut.HandleAuthorisedAsync(request, logger.Object, cirGuid);

            // Assert
            specBuilder
                .Verify(b => b.BladeInspection());
            specBuilder
                .Verify(b => b.CirIds(It.IsAny<IList<int>>()));
            specBuilder
                .Verify(b => b.CirGuid(cirGuid));
            specBuilder
                .Verify(b => b.Damages(hasDamages));
            specBuilder
                .Verify(b => b.Build(), Times.Once);
        }

    }
}
