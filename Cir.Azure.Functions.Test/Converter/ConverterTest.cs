using ExpectedObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Cir.Azure.Functions.Test.Converter
{

    public class ConverterTests
    {
        public static IEnumerable<object[]> Suts =>
            new[]
            {
                    new object[] { typeof(CirIdConverter),        "Converter/CirIdConverter/"},
                    new object[] { typeof(CirDetailsConverter),   "Converter/CirDetailsConverter/"},
                    new object[] { typeof(CirDamagesConverter),   "Converter/CirDamagesConverter/"},
                    new object[] { typeof(CirImageUrlsConverter), "Converter/CirImageUrlsConverter/" }

            };

        private JObject Parse(string text)
        {
            using (var reader =
                    new JsonTextReader(new StringReader(text))
                    {
                        DateParseHandling = DateParseHandling.None
                    }) 
            {
                return JObject.Load(reader);
            }
        }

        [Theory]
        [MemberData(nameof(Suts))]
        public void NullSingle(Type type, string jsonPath)
        {
            // Arrange
            var sut = (IConverter)Activator.CreateInstance(type);

            // Act
            Assert.Throws<ArgumentNullException>(() => sut.Convert((JObject)null));

            // Assert
        }

        [Theory]
        [MemberData(nameof(Suts))]
        public void NullList(Type type, string jsonPath)
        {
            // Arrange
            var sut = (IConverter)Activator.CreateInstance(type);

            // Act
            Assert.Throws<ArgumentNullException>(() => sut.Convert((IList<JObject>)null));

            // Assert
        }

        [Theory]
        [MemberData(nameof(Suts))]
        public void EmptyList(Type type, string jsonPath)
        {
            // Arrange
            var sut = (IConverter)Activator.CreateInstance(type);
            var emptyList = new JObject[0];
            var expected = Parse("{\"data\": []}");

            // Act
            var actual = sut.Convert(emptyList);

            // Assert
            Assert.True(JToken.DeepEquals(expected, actual));
        }

        [Theory]
        [MemberData(nameof(Suts))]
        public void SingleListValid(Type type, string jsonPath)
        {
            // Arrange
            var sut = (IConverter)Activator.CreateInstance(type);
            var inputText = System.IO.File.ReadAllText($"{jsonPath}/valid_1.json");
            var inputJson = Parse(inputText);
            var expectedText = System.IO.File.ReadAllText($"{jsonPath}/valid_1_expected.json");
            var expected = Parse(expectedText);
            var singleValid = new JObject[]
            {
                inputJson
            };

            // Act
            var actual = sut.Convert(singleValid);

            // Assert
            Assert.True(JToken.DeepEquals(expected, actual));
        }

        [Theory]
        [MemberData(nameof(Suts))]
        public void SingleSingleValid(Type type, string jsonPath)
        {
            // Arrange
            var sut = (IConverter)Activator.CreateInstance(type);
            var inputText = System.IO.File.ReadAllText($"{jsonPath}/valid_1.json");
            var inputJson = Parse(inputText);
            var expectedText = System.IO.File.ReadAllText($"{jsonPath}/valid_1_single_expected.json");
            var expected = Parse(expectedText);

            // Act
            var actual = sut.Convert(inputJson);

            // Assert
            Assert.True(JToken.DeepEquals(expected, actual));
        }



        [Theory]
        [MemberData(nameof(Suts))]
        public void MultipleValid(Type type, string jsonPath)
        {
            // Arrange
            var sut = (IConverter)Activator.CreateInstance(type);
            var input1Text = System.IO.File.ReadAllText($"{jsonPath}/valid_1.json");
            var input1Json = Parse(input1Text);
            var input2Text = System.IO.File.ReadAllText($"{jsonPath}/valid_2.json");
            var input2Json = Parse(input2Text);
            var expectedText = System.IO.File.ReadAllText($"{jsonPath}/valid_1_2_expected.json");
            var expected = Parse(expectedText);
            var multipleValid = new JObject[]
            {
                input1Json,
                input2Json
            };

            // Act
            var actual = sut.Convert(multipleValid);

            // Assert
            Assert.True(JToken.DeepEquals(expected, actual));
        }

    }
}
