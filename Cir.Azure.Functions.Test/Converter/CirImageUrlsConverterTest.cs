using AutoFixture;
using DeepEqual.Syntax;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Azure.Functions.Test.Converter
{
#if false
    public class CirImageUrlsConverterTest
    {
        private CirImageUrlsConverter sut;
        private Fixture fixture;
        private dynamic cir1;
        private CirImageUrls dto1;
        
       
        public CirImageUrlsConverterTest()
        {
            fixture = new Fixture();

            // cir 1 + dto 1
            cir1 = new ExpandoObject();
            cir1.cirSubmissionData = new ExpandoObject();
            cir1.cirSubmissionData.imageReferences = new[]
            {
                new ExpandoObject()
            };
            cir1.cirSubmissionData.imageReferences[0].imageId = fixture.Create<string>();
            cir1.cirSubmissionData.imageReferences[0].url = fixture.Create<string>();
            dto1 = new CirImageUrls
            {
                Images = new List<CirImageUrl>
                {
                    new CirImageUrl
                    {
                        Id = cir1.cirSubmissionData.imageReferences[0].imageId,
                        Url = cir1.cirSubmissionData.imageReferences[0].url
                    }
                }
            };


            sut = new CirImageUrlsConverter();
        }

        [Fact]
        // TODO[ExpectedException(typeof(ArgumentNullException))]
        public void Null()
        {
            Assert.Throws<ArgumentNullException>(() => sut.Convert(null));
        }

        [Fact]
        public void Ok()
        {
            // Arrange

            // Act
            CirImageUrls actual = sut.Convert(cir1);

            // Assert
            actual.ShouldDeepEqual(dto1);
        }

        [Fact]
        //[ExpectedException(typeof(ConvertException))]
        public void MissingCirSubmissionData()
        {
            // Arrange
            dynamic cir = new ExpandoObject();

            // Act
            Assert.Throws<ConvertException>(() => sut.Convert(cir));

            // Assert
        }

        [Fact]
        //[ExpectedException(typeof(ConvertException))]
        public void MissingImageReferences()
        {
            // Arrange
            dynamic cir = new ExpandoObject();
            cir.cirSubmissionData = new ExpandoObject();

            // Act
            Assert.Throws<ConvertException>(() => sut.Convert(cir));

            // Assert
        }

        [Fact]
        public void EmptyCirSubmissionData()
        {
            // Arrange
            dynamic cir = new ExpandoObject();
            cir.cirSubmissionData = new ExpandoObject();
            cir.cirSubmissionData.imageReferences = new ExpandoObject[]
            {
            };
            var expected = new CirImageUrls
            {
                Images = new List<CirImageUrl>()
            };

            // Act
            CirImageUrls actual = sut.Convert(cir);

            // Assert
            actual.IsDeepEqual(expected);
        }

        [Fact]
        //[ExpectedException(typeof(ConvertException))]
        public void MissingImageId()
        {
            // Arrange
            dynamic cir = new ExpandoObject();
            cir.cirSubmissionData = new ExpandoObject();
            cir.cirSubmissionData.imageReferences = new[]
            {
                new ExpandoObject()
            };
            cir.cirSubmissionData.imageReferences[0].url = fixture.Create<string>();


            // Act
            Assert.Throws<ConvertException>(() => sut.Convert(cir));

            // Assert
        }

        [Fact]
        //[ExpectedException(typeof(ConvertException))]
        public void MissingUrl()
        {
            // Arrange
            dynamic cir = new ExpandoObject();
            cir.cirSubmissionData = new ExpandoObject();
            cir.cirSubmissionData.imageReferences = new[]
            {
                new ExpandoObject()
            };
            cir.cirSubmissionData.imageReferences[0].imageId = fixture.Create<string>();


            // Act
            Assert.Throws<ConvertException>(() => sut.Convert(cir));

            // Assert
        }

    }
#endif
}
