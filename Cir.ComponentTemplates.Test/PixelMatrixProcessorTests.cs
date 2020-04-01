using System;
using System.Linq;
using Cir.ComponentTemplates.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cir.ComponentTemplates.Test
{
    [TestClass]
    public class PixelMatrixProcessorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GivenNullPixelMatrix_ThenProcessorShouldThrowArgumentException() 
        {
            var sut = new PixelMatrixProcessor();

            sut.ProcessMatrix(null, new Section[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GivenEmptyPixelMatrix_ThenProcessorShouldThrowArgumentOutOfRangeException()
        {
            var sut = new PixelMatrixProcessor();

            sut.ProcessMatrix(new int[0][][], new Section[0]);
        }

        [TestMethod]
        public void GivenPixelMatrix_ThenProcessorShouldDeserializeItToColors()
        {
            var matrix = new[]
            {
                new[]
                {
                    new[] { -1, 45 },
                    new[] { 1, 4 }
                },
                new []
                {
                    new[] { -1, 16 },
                    new[] { 5, 8 }
                },
                new[]
                {
                    new [] { -2, 5 }
                }
            };
            var sections = new[]
            {
                new Section {Id = -2, Color = SeverityColors.AssignedColor },
                new Section {Id = 1, Color = SeverityColors.Severity1},
                new Section {Id = 5, Color = SeverityColors.Severity5}
            };
            var sut = new PixelMatrixProcessor();
            var result = sut.ProcessMatrix(matrix, sections);
            var row = result.First().ToList();

            Assert.IsTrue(row.Take(45).All(s => s == string.Empty));
            Assert.IsTrue(row.Skip(45).Take(4).All(s => s == SeverityColors.Severity1));
            Assert.IsTrue(row.Skip(49).Take(16).All(s => s == string.Empty));
            Assert.IsTrue(row.Skip(65).Take(8).All(s => s == SeverityColors.Severity5));
            Assert.IsTrue(row.Skip(73).Take(5).All(s => s == SeverityColors.AssignedColor));
        }
    }
}
