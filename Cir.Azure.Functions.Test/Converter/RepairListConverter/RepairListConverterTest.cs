﻿using ExpectedObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
#if false
namespace Cir.Azure.Functions.Test.Converter
{
    public class RepairListConverterList
    {
        private readonly RepairListConverter sut;
        private const string JsonPath = "Converter/VoCirDetailsConverter/json";

        public RepairListConverterList()
        {
            sut = new RepairListConverter();
        }

        [Fact]
        public void Null()
        {
            // Arrange

            // Act
            Assert.Throws<ArgumentNullException>(() => sut.Convert(null));

            // Assert
        }

        [Fact]
        public void EmptyList()
        {
            // Arrange
            var emptyList = new JObject[0];
            var expected = new RepairListDto
            {
                Repairs = new List<Repair>()
            };

            // Act
            var actual = sut.Convert(emptyList);

            // Assert
            expected
                .ToExpectedObject()
                .ShouldEqual(actual);
        }

        [Fact]
        public void SingleValid()
        {
            // Arrange
            var inputText = System.IO.File.ReadAllText($"{JsonPath}/valid_1.json");
            var inputJson = JObject.Parse(inputText);
            var expectedText = System.IO.File.ReadAllText($"{JsonPath}/valid_1_expected.json");
            var expected = JsonConvert.DeserializeObject<RepairListDto>(expectedText);
            var singleValid = new JObject[]
            {
                inputJson
            };

            // Act
            var actual = sut.Convert(singleValid);

            // Assert
            expected
                .ToExpectedObject()
                .ShouldEqual(actual);
        }

        [Fact]
        public void SingleBad()
        {
            // Arrange
            var inputText = "{}";
            var inputJson = JObject.Parse(inputText);
            var singleBad = new JObject[]
            {
                inputJson
            };

            // Act
            Assert.Throws<ConvertException>(() => sut.Convert(singleBad));

            // Assert
        }

        [Fact]
        public void MultipleValid()
        {
            // Arrange
            var input1Text = System.IO.File.ReadAllText($"{JsonPath}/valid_1.json");
            var input1Json = JObject.Parse(input1Text);
            var input2Text = System.IO.File.ReadAllText($"{JsonPath}/valid_2.json");
            var input2Json = JObject.Parse(input2Text);
            var expectedText = System.IO.File.ReadAllText($"{JsonPath}/valid_1_2_expected.json");
            var expected = JsonConvert.DeserializeObject<RepairListDto>(expectedText);
            var multipleValid = new JObject[]
            {
                input1Json,
                input2Json
            };

            // Act
            var actual = sut.Convert(multipleValid);

            // Assert
            expected
                .ToExpectedObject()
                .ShouldEqual(actual);
        }

        [Fact]
        public void MultipleMixed()
        {
            // Arrange
            var input1Text = System.IO.File.ReadAllText($"{JsonPath}/valid_1.json");
            var input1Json = JObject.Parse(input1Text);
            var input2Text = "{}";
            var input2Json = JObject.Parse(input2Text);
            var multipleMixed = new JObject[]
            {
                input1Json,
                input2Json
            };

            // Act
            Assert.Throws<ConvertException>(() => sut.Convert(multipleMixed));

            // Assert
        }
    }
}
#endif