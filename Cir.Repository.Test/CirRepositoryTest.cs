using AutoFixture;
using AutoFixture.AutoMoq;
using Cir.BlobStorage;
using Cir.BlobStorage.FileHandlerNS;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Repository.Test
{
    public class CirRepositoryTest
    {
        private readonly CirRepository sut;
        private readonly Fixture fixture;
        private readonly Mock<IFSNodeNavigator> navigator;
        private readonly Mock<IFileFactory> fileFactory;
        private readonly Mock<IFileHandlerFactory> fileHandlerFactory;
        private readonly Mock<IFileHandler> fileHandler;

        private Action<JObject> action;

        public CirRepositoryTest()
        {
            fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            navigator = new Mock<IFSNodeNavigator>();
            fileFactory = new Mock<IFileFactory>();
            fileHandlerFactory = new Mock<IFileHandlerFactory>();
            fileHandler = new Mock<IFileHandler>();
            action = null;

            fileHandlerFactory
                .Setup(f => f.CreateLastModifiedFileHandler(It.IsAny<Action<JObject>>()))
                .Callback<Action<JObject>>(a => action = a)
                .Returns(fileHandler.Object);

            sut = new CirRepository(
                navigator.Object,
                fileFactory.Object,
                fileHandlerFactory.Object);
        }
        [Fact]
        public async Task GetAllSingleCir()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            var cir = JObject.Parse(@"{""a"": 1}");

            navigator
                .Setup(n => n.RunAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IFileHandler>()))
                .Callback(() => action(cir))
                .Returns(Task.CompletedTask);

            // Act
            var cirs = await sut.GetAllAsync(turbineId, null);

            // Assert
            Assert.Equal(1, cirs.Count);
            Assert.True(JToken.DeepEquals(cir, cirs.Single()));
        }

        [Fact]
        public async Task GetAllSingleCirFromList()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            var cir = JObject.Parse(@"{""a"": 1}");

            navigator
                .Setup(n => n.RunAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IFileHandler>()))
                .Callback(() => action(cir))
                .Returns(Task.CompletedTask);

            // Act
            var cirs = await sut.GetAllAsync(new[] { turbineId }, null);

            // Assert
            Assert.Equal(1, cirs.Count);
            Assert.True(JToken.DeepEquals(cir, cirs.Single()));
        }

        [Fact]
        public async Task GetAllMultipleCirs()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            var cir1 = JObject.Parse(@"{""a"": 1}");
            var cir2 = JObject.Parse(@"{""a"": 2}");

            navigator
                .Setup(n => n.RunAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IFileHandler>()))
                .Callback(() => { action(cir1); action(cir2); })
                .Returns(Task.CompletedTask);

            // Act
            var cirs = await sut.GetAllAsync(turbineId, null);

            // Assert
            Assert.Equal(2, cirs.Count);
            Assert.Contains(cirs, c => JToken.DeepEquals(cir1, c));
            Assert.Contains(cirs, c => JToken.DeepEquals(cir2, c));
        }
        [Fact]
        public async Task GetAllMultipleCirsFromList()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            var cir1 = JObject.Parse(@"{""a"": 1}");
            var cir2 = JObject.Parse(@"{""a"": 2}");

            navigator
                .Setup(n => n.RunAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IFileHandler>()))
                .Callback(() => { action(cir1); action(cir2); })
                .Returns(Task.CompletedTask);

            // Act
            var cirs = await sut.GetAllAsync(new[] { turbineId }, null);

            // Assert
            Assert.Equal(2, cirs.Count);
            Assert.Contains(cirs, c => JToken.DeepEquals(cir1, c));
            Assert.Contains(cirs, c => JToken.DeepEquals(cir2, c));
        }

        [Fact]
        public async Task GetAllMultipleCirsFromListWithMultipleTurbines()
        {
            // Arrange
            var turbineId1 = fixture.Create<string>();
            var turbineId2 = fixture.Create<string>();
            var cir1 = JObject.Parse(@"{""a"": 1}");
            var cir2 = JObject.Parse(@"{""a"": 2}");
            var cir3 = JObject.Parse(@"{""a"": 3}");
            int callCount = 0;

            navigator
                .Setup(n => n.RunAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IFileHandler>()))
                .Callback(() =>
                {
                    switch (callCount++)
                    {
                        case 0:
                            action(cir1);
                            break;
                        case 1:
                            action(cir2);
                            action(cir3);
                            break;
                        default:
                            throw new Exception("unexpected invocation");
                    }
                })
                .Returns(Task.CompletedTask);

            // Act
            var cirs = await sut.GetAllAsync(new[] { turbineId1, turbineId2 }, null);

            // Assert
            Assert.Equal(3, cirs.Count);
            Assert.Contains(cirs, c => JToken.DeepEquals(cir1, c));
            Assert.Contains(cirs, c => JToken.DeepEquals(cir2, c));
            Assert.Contains(cirs, c => JToken.DeepEquals(cir3, c));
        }

        [Fact]
        public async Task UseCorrectFileHandlerWithNavigator()
        {
            // Arrange
            string turbineId = fixture.Create<string>();

            // Act
            var cirs = await sut.GetAllAsync(turbineId, null);

            // Assert
            navigator
                .Verify(n => n.RunAsync(It.IsAny<string>(), It.IsAny<int>(), fileHandler.Object), Times.Once());
        }

        [Fact]
        public async Task UseCorrectPatternAndGroupingWithNavigator()
        {
            // Arrange
            string turbineId = fixture.Create<string>();

            // Act
            var cirs = await sut.GetAllAsync(turbineId, null);

            // Assert
            navigator
                .Verify(n => n.RunAsync($"{turbineId}/CIR/*/RevisionHistory/*", 1, It.IsAny<IFileHandler>()), Times.Once());
        }

        [Fact]
        public async Task ThrowsOnNullTurbineId()
        {
            // Arrange

            // Act
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.GetAllAsync((string)null, null));

            // Assert
        }

        [Fact]
        public async Task FiltersBySpec()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            var cir1 = JObject.Parse(@"{""a"": 1}");
            var cir2 = JObject.Parse(@"{""a"": 2}");
            var spec = new Mock<ISpecification>();
            bool func(JObject cir) => cir["a"].Value<int>() == 1;

            spec
                .Setup(s => s.ToFunc())
                .Returns(func);

            navigator
                .Setup(n => n.RunAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IFileHandler>()))
                .Callback(() => { action(cir1); action(cir2); })
                .Returns(Task.CompletedTask);

            // Act
            var cirs = await sut.GetAllAsync(turbineId, spec.Object);

            // Assert
            Assert.Equal(1, cirs.Count);
            Assert.True(JToken.DeepEquals(cir1, cirs.First()));
        }

        [Fact]
        public async Task FiltersBySpecTriangulated()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            var cir1 = JObject.Parse(@"{""a"": 1}");
            var cir2 = JObject.Parse(@"{""a"": 2}");
            var spec = new Mock<ISpecification>();
            bool func(JObject cir) => cir["a"].Value<int>() == 2;

            spec
                .Setup(s => s.ToFunc())
                .Returns(func);

            navigator
                .Setup(n => n.RunAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IFileHandler>()))
                .Callback(() => { action(cir1); action(cir2); })
                .Returns(Task.CompletedTask);

            // Act
            var cirs = await sut.GetAllAsync(turbineId, spec.Object);

            // Assert
            Assert.Equal(1, cirs.Count);
            Assert.True(JToken.DeepEquals(cir2, cirs.First()));
        }

        [Fact]
        public async Task GetExactlyOneThrowsOnMultiple()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            var cir1 = JObject.Parse(@"{""a"": 1}");
            var cir2 = JObject.Parse(@"{""a"": 2}");

            navigator
                .Setup(n => n.RunAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<IFileHandler>()))
                .Callback(() => { action(cir1); action(cir2); })
                .Returns(Task.CompletedTask);

            // Act
            await Assert.ThrowsAsync<Exception>(() => sut.GetExactlyOneAsync(turbineId, null));

            // Assert
        }

        [Fact]
        public async Task GetExactlyOneReturnsNullOnNone()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            // Act
            var result = await sut.GetExactlyOneAsync(turbineId, null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetFileByCirAsyncTest()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            var cirId = fixture.Create<string>();
            var filename = fixture.Create<string>();
            var fileContent = fixture.Create<string>();
            var file = new Mock<IFile>();
            var expectedPath = $"{turbineId}/CIR/{cirId}/{filename}";

            fileFactory
                .Setup(f => f.CreateFile(expectedPath))
                .Returns(file.Object);

            file
                .Setup(f => f.GetTextAsync())
                .Callback(() => 
                    file
                        .SetupGet(f => f.Text)
                        .Returns(fileContent))
                .Returns(Task.CompletedTask);

            // Act
            var result = await sut.GetFileByCirAsync(turbineId, cirId, filename);

            // Assert
            Assert.Equal(fileContent, result);
        }

        [Fact]
        public async Task StoreFileByCirAsyncTest()
        {
            // Arrange
            var turbineId = fixture.Create<string>();
            var cirId = fixture.Create<string>();
            var filename = fixture.Create<string>();
            var fileContent = fixture.Create<string>();
            var file = new Mock<IFile>();
            var expectedPath = $"{turbineId}/CIR/{cirId}/{filename}";

            fileFactory
                .Setup(f => f.CreateFile(expectedPath))
                .Returns(file.Object);

            // Act
            var result = await sut.StoreFileByCirAsync(turbineId, cirId, filename, fileContent);

            // Assert
            file
                .Verify(f => f.WriteTextAsync(fileContent), Times.Once());
        }
    }


}
