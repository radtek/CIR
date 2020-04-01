using AutoFixture;
using Cir.BlobStorage;
using Cir.BlobStorage.FileHandlerNS;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Repository.Test
{
    public class BirRepositoryTest
    {
        private readonly BirRepository sut;
        private readonly Fixture fixture;
        private readonly Mock<IFSNodeNavigator> navigator;
        private readonly Mock<IMetadataGetter> metadataGetter;
        private readonly Mock<IFileHandlerFactory> fileHandlerFactory;
        private readonly Mock<IFileCollector> fileHandler;

        public BirRepositoryTest()
        {
            fixture = new Fixture();
            navigator = new Mock<IFSNodeNavigator>();
            metadataGetter = new Mock<IMetadataGetter>();
            fileHandlerFactory = new Mock<IFileHandlerFactory>();
            fileHandler = new Mock<IFileCollector>();

            fileHandlerFactory
                .Setup(f => f.CreateAggregateFileHandler())
                .Returns(fileHandler.Object);

            fileHandler
                .SetupGet(h => h.Files)
                .Returns(new List<IFile>());

            sut = new BirRepository(
                navigator.Object,
                metadataGetter.Object,
                fileHandlerFactory.Object);
        }

        [Fact]
        public async Task ThrowsOnNullTurbineId()
        {
            // Arrange
            string turbineId = null;
            var modifiedYears = fixture.Create<List<int>>();

            // Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetAsync(turbineId, null, new int[] { }, null, false));

            // Assert
            Assert.Equal("turbineId", exception.ParamName);
        }

        [Fact]
        public async Task ThrowsOnNullModifiedYears()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            int[] modifiedYears = null;

            // Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetAsync(turbineId, null, modifiedYears, null, false));

            // Assert
            Assert.Equal("modifiedYears", exception.ParamName);
        }

        [Fact]
        public async Task UseCorrectPatternAndGroupingWithNavigator()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            var modifiedYears = fixture.Create<List<int>>();

            // Act
            await sut.GetAsync(turbineId, null, modifiedYears, null, false);

            // Assert
            navigator
                .Verify(n => n.RunAsync($"{turbineId}/BIR/PDF/*", -1, It.IsAny<IFileHandler>()), Times.Once);
        }

        [Fact]
        public async Task UseCorrectFileHandlerWithNavigator()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            var modifiedYears = fixture.Create<List<int>>();
       
            // Act
            await sut.GetAsync(turbineId, null, modifiedYears, null, false);
       
            // Assert
            navigator
                .Verify(n => n.RunAsync(It.IsAny<string>(), It.IsAny<int>(), fileHandler.Object), Times.Once);
        }
    }
}
