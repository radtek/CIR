using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Cir.BlobStorage.ErrorHandlerNS;
using Cir.BlobStorage.FileHandlerNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cir.BlobStorage.Test
{
    [TestClass]
    public class FSNodeNavigatorTest
    {
        private FSNodeNavigator sut;
        private Mock<IFSNodeLister> lister;
        private Mock<IErrorHandler> errorHandler;
        private string[] fileSystem;
        private IDictionary<string, IFSNode> fsNodes;

        private IFSNode GetFSNode(string fullPath)
        {
            if (!fsNodes.ContainsKey(fullPath))
            {
                if (fullPath.EndsWith("/"))
                {
                    var dir = new Mock<IDirectory>();
                    dir.SetupGet(d => d.FullPath)
                        .Returns(fullPath);
                    fsNodes[fullPath] = dir.Object;
                }
                else
                {
                    var file = new Mock<IFile>();
                    file.SetupGet(f => f.FullPath)
                        .Returns(fullPath);
                    fsNodes[fullPath] = file.Object;
                }
            }
            return fsNodes[fullPath];
        }


        private void SetupFileSystem(string[] fileSystem)
        {
            this.fileSystem = fileSystem;

            lister
                .Setup(l => l.ListAsync(It.IsAny<string>(), It.IsAny<IContinuationToken>()))
                .ReturnsAsync(
                    (string prefix, IContinuationToken token) =>
                        new FSNodeListerResult
                        {
                            Result =
                                fileSystem.Where(fullPath => fullPath.StartsWith(prefix))
                                            .Select(fullPath =>
                                            {
                                                int idx = fullPath.IndexOf('/', prefix.Length);
                                                if (idx < 0)
                                                {
                                                    return fullPath;
                                                }
                                                else
                                                {
                                                    return fullPath.Substring(0, idx + 1);
                                                }

                                            })
                                            .Distinct()
                                            .Select(s => GetFSNode(s))
                                            .ToArray(),
                            ContinuationToken = null
                        }
                );
        }


        [TestInitialize]
        public void Setup()
        {
            fsNodes = new Dictionary<string, IFSNode>(1000);
            lister = new Mock<IFSNodeLister>();
            errorHandler = new Mock<IErrorHandler>();
            sut = new FSNodeNavigator(new List<IFSNodeLister> { lister.Object }, errorHandler.Object);
        }


        [TestMethod]
        public async Task AllFilesInSpecificFolder()
        {
            // Arrange
            SetupFileSystem(new[]
            {
                "file4",
                "dir1/file1",
                "dir1/file2",
                "dir2/file3"
            });
            var fileHandler = new Mock<IFileHandler>();

            // Act
            await sut.RunAsync("dir1/*", -1, fileHandler.Object);

            // Assert
            fileHandler.Verify(f => f.HandleAsync((new[] { (IFile)GetFSNode("dir1/file1") })));
            fileHandler.Verify(f => f.HandleAsync((new[] { (IFile)GetFSNode("dir1/file2") })));
            fileHandler.VerifyNoOtherCalls();
        }


        [TestMethod]
        public async Task AllFilesInFolderWithWildcardInPath()
        {
            // Arrange
            SetupFileSystem(new[]
            {
                "dir1/file4",
                "dir1/a/file1",
                "dir1/b/file2",
                "dir2/a/file3",
                "file4"
            });
            var fileHandler = new Mock<IFileHandler>();

            // Act
            await sut.RunAsync("dir1/*/*", -1, fileHandler.Object);

            // Assert
            fileHandler.Verify(f => f.HandleAsync((new[] { (IFile)GetFSNode("dir1/a/file1") })));
            fileHandler.Verify(f => f.HandleAsync((new[] { (IFile)GetFSNode("dir1/b/file2") })));
            fileHandler.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task AllFilesInSpecificFolderGrouped()
        {
            // Arrange
            SetupFileSystem(new[]
            {
                "dir1/",
                "dir1/file1",
                "dir1/file2",
                "dir2",
                "dir2/file3",
                "file4"
            });
            var expected = new[]
            {
                (IFile)GetFSNode("dir1/file1"),
                (IFile)GetFSNode("dir1/file2")
            };
            var fileHandler = new Mock<IFileHandler>();

            // Act
            await sut.RunAsync("dir1/*", 0, fileHandler.Object);

            // Assert
            fileHandler.Verify(f => f.HandleAsync(
                It.Is<IReadOnlyCollection<IFile>>(
                    l => AreEqualFileLists(l, expected))));
            fileHandler.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task AllFilesInFolderWithWildcardInPathGrouped()
        {
            // Arrange
            SetupFileSystem(new[]
            {
                "image/red/triangle/1.jpg",
                "image/red/triangle/2.jpg",
                "image/red/square/1.jpg",
                "image/red/square/2.jpg",
                "image/blue/triangle/1.jpg",
                "image/blue/triangle/2.jpg",
                "image/blue/square/1.jpg",
                "image/green/triangle/1.jpg",

                "dummy",
                "image/red/dummy",
                "image/blue/dummy",
                "image/red/triangle/dummy"

            });

            var expected1 = new[]
            {
                (IFile)GetFSNode("image/red/square/1.jpg"),
                (IFile)GetFSNode("image/red/square/2.jpg")
            };
            var expected2 = new[]
            {
                (IFile)GetFSNode("image/blue/square/1.jpg")
            };

            var fileHandler = new Mock<IFileHandler>();

            // Act
            await sut.RunAsync("image/*/square/*", 1, fileHandler.Object);

            // Assert
            fileHandler.Verify(f => f.HandleAsync(
                It.Is<IReadOnlyCollection<IFile>>(
                    l => AreEqualFileLists(l, expected1))));
            fileHandler.Verify(f => f.HandleAsync(
                It.Is<IReadOnlyCollection<IFile>>(
                    l => AreEqualFileLists(l, expected2))));


            fileHandler.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task ManyDirectoriesGrouped()
        {
            // Arrange
            SetupFileSystem(new[]
            {
                "color/red/shape/triangle/image/1.jpg",
                "color/red/shape/triangle/image/2.jpg",
                "color/blue/shape/triangle/image/1.jpg",
                "color/blue/shape/triangle/image/3.jpg",
                "color/green/shape/square/image/1.jpg",
            });

            var expected1 = new[]
            {
                (IFile)GetFSNode("color/red/shape/triangle/image/1.jpg"),
                (IFile)GetFSNode("color/red/shape/triangle/image/2.jpg"),
            };
            var expected2 = new[]
            {
                (IFile)GetFSNode("color/blue/shape/triangle/image/1.jpg"),
                (IFile)GetFSNode("color/blue/shape/triangle/image/3.jpg"),
            };

            var fileHandler = new Mock<IFileHandler>();

            // Act
            await sut.RunAsync("color/*/shape/triangle/image/*", 1, fileHandler.Object);

            // Assert
            fileHandler.Verify(f => f.HandleAsync(
                It.Is<IReadOnlyCollection<IFile>>(
                    l => AreEqualFileLists(l, expected1))));

            fileHandler.Verify(f => f.HandleAsync(
                It.Is<IReadOnlyCollection<IFile>>(
                    l => AreEqualFileLists(l, expected2))));


            fileHandler.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task ManyDirectoriesGrouped2()
        {
            // Arrange
            SetupFileSystem(new[]
            {
                "color/red/shape/triangle/image/1.jpg",
                "color/red/shape/triangle/image/2.jpg",
                "color/blue/shape/triangle/image/1.jpg",
                "color/blue/shape/triangle/image/3.jpg",
                "color/green/shape/square/image/1.jpg",
            });

            var expected1 = new[]
            {
                (IFile)GetFSNode("color/red/shape/triangle/image/1.jpg"),
                (IFile)GetFSNode("color/red/shape/triangle/image/2.jpg"),
            };
            var expected2 = new[]
            {
                (IFile)GetFSNode("color/blue/shape/triangle/image/1.jpg"),
                (IFile)GetFSNode("color/blue/shape/triangle/image/3.jpg"),
            };
            var expected3 = new[]
{
                (IFile)GetFSNode("color/green/shape/square/image/1.jpg")
            };

            var fileHandler = new Mock<IFileHandler>();

            // Act
            await sut.RunAsync("color/*/shape/*/image/*", 1, fileHandler.Object);

            // Assert
            fileHandler.Verify(f => f.HandleAsync(
                It.Is<IReadOnlyCollection<IFile>>(
                    l => AreEqualFileLists(l, expected1))));

            fileHandler.Verify(f => f.HandleAsync(
                It.Is<IReadOnlyCollection<IFile>>(
                    l => AreEqualFileLists(l, expected2))));

            fileHandler.Verify(f => f.HandleAsync(
                It.Is<IReadOnlyCollection<IFile>>(
                    l => AreEqualFileLists(l, expected3))));


            fileHandler.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task ManyDirectoriesGrouped3()
        {
            // Arrange
            SetupFileSystem(new[]
            {
                "color/red/shape/triangle/image/1.jpg",
                "color/red/shape/triangle/image/2.jpg",
                "color/blue/shape/triangle/image/1.jpg",
                "color/blue/shape/triangle/image/3.jpg",
                "color/green/shape/triangle/image/1.jpg",
                "color/green/shape/square/image/1.jpg",
            });

            var expected1 = new[]
            {
                (IFile)GetFSNode("color/red/shape/triangle/image/1.jpg"),
                (IFile)GetFSNode("color/red/shape/triangle/image/2.jpg"),
            };
            var expected2 = new[]
            {
                (IFile)GetFSNode("color/blue/shape/triangle/image/1.jpg"),
                (IFile)GetFSNode("color/blue/shape/triangle/image/3.jpg"),
            };
            var expected3 = new[]
            {
                (IFile)GetFSNode("color/green/shape/triangle/image/1.jpg")
            };
            var expected4 = new[]
            {
                (IFile)GetFSNode("color/green/shape/square/image/1.jpg")
            };

            var fileHandler = new Mock<IFileHandler>();

            // Act
            await sut.RunAsync("color/*/shape/*/image/*", 2, fileHandler.Object);

            // Assert
            fileHandler.Verify(f => f.HandleAsync(
                It.Is<IReadOnlyCollection<IFile>>(
                    l => AreEqualFileLists(l, expected1))));

            fileHandler.Verify(f => f.HandleAsync(
                It.Is<IReadOnlyCollection<IFile>>(
                    l => AreEqualFileLists(l, expected2))));

            fileHandler.Verify(f => f.HandleAsync(
                It.Is<IReadOnlyCollection<IFile>>(
                    l => AreEqualFileLists(l, expected3))));

            fileHandler.Verify(f => f.HandleAsync(
                It.Is<IReadOnlyCollection<IFile>>(
                    l => AreEqualFileLists(l, expected4))));


            fileHandler.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task FileHandlerThrows()
        {
            // Arrange
            SetupFileSystem(new[]
            {
                "image/1.jpg",
                "image/2.jpg"
            });


            var fileHandler = new Mock<IFileHandler>();
            fileHandler
                .Setup(f => f.HandleAsync(It.IsAny<IReadOnlyCollection<IFile>>()))
                .ThrowsAsync(new Exception());

            // Act
            await sut.RunAsync("image/*", -1, fileHandler.Object);

            // Assert
            errorHandler.Verify(e => e.OnException(It.IsAny<Exception>()), Times.Exactly(2));
        }

        [TestMethod]
        public async Task FileHandlerThrowsAggregated()
        {
            // Arrange
            SetupFileSystem(new[]
            {
                "image/1.jpg",
                "image/2.jpg"
            });


            var fileHandler = new Mock<IFileHandler>();
            fileHandler
                .Setup(f => f.HandleAsync(It.IsAny<IReadOnlyCollection<IFile>>()))
                .ThrowsAsync(new Exception());

            // Act
            await sut.RunAsync("image/*", 0, fileHandler.Object);

            // Assert
            errorHandler.Verify(e => e.OnException(It.IsAny<Exception>()), Times.Exactly(1));
        }

        private bool AreEqualFileLists(IReadOnlyCollection<IFile> files1, IReadOnlyCollection<IFile> files2)
        {
            if (files1.Count != files2.Count)
            {
                return false;
            }

            foreach (var f1 in files1)
            {
                if (files2.Where(f2 => f2.FullPath == f1.FullPath)
                          .Count() != 1)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
