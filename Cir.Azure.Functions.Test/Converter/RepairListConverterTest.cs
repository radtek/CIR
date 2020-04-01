using AutoFixture;
using AutoFixture.AutoMoq;
using DeepEqual.Syntax;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Azure.Functions.Test.Converter
{
    
    public class RepairListConverterTest
    {
        private RepairListConverter sut;
        private JObject repair1;
        private JObject repair2;
        private Repair dto1;
        private Repair dto2;
        private Fixture fixture;
        
        public RepairListConverterTest()
        {
            fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var repair1Text = System.IO.File.ReadAllText("Repairs/repair1.json");
            var repair2Text = System.IO.File.ReadAllText("Repairs/repair2.json");
            repair1 = JObject.Parse(repair1Text);
            repair2 = JObject.Parse(repair2Text);

            dto1 = new Repair
            {
                BladeId =    repair1["cirSubmissionData"]["data"]["txtBladeSerialNumber"].Value<string>(),
                DamageGuid = repair1["cirSubmissionData"]["data"]["imagecomponentKey"]["damageGuid"].Value<string>(),
                DamageId =   repair1["cirSubmissionData"]["data"]["imagecomponentKey"]["damageId"].Value<string>(),
                Date =       repair1["cirSubmissionData"]["data"]["dtInspectionDate"].Value<string>(),
                TurbineId =  repair1["cirSubmissionData"]["data"]["txtTurbineNumber"].Value<string>(),
                RepairId =   repair1["cirSubmissionData"]["id"].Value<string>(),
            };

            dto2 = new Repair
            {
                BladeId =    repair2["cirSubmissionData"]["data"]["txtBladeSerialNumber"].Value<string>(),
                DamageGuid = repair2["cirSubmissionData"]["data"]["imagecomponentKey"]["damageGuid"].Value<string>(),
                DamageId =   repair2["cirSubmissionData"]["data"]["imagecomponentKey"]["damageId"].Value<string>(),
                Date =       repair2["cirSubmissionData"]["data"]["dtInspectionDate"].Value<string>(),
                TurbineId =  repair2["cirSubmissionData"]["data"]["txtTurbineNumber"].Value<string>(),
                RepairId =   repair2["cirSubmissionData"]["id"].Value<string>(),
            };

            sut = new RepairListConverter();
        }
        [Fact]
        public void Null()
        {
            Assert.Throws<ArgumentNullException>(() => sut.Convert(null));
        }

        [Fact]
        public void EmptyList()
        {
            // Arrange
            var expected = new RepairListDto
            {
                Repairs = new List<Repair>()
            };

            // Act
            var actual = sut.Convert(new JObject[] { });

            // Assert
            actual.ShouldDeepEqual(expected);
        }

        [Fact]
        public void Ok()
        {
            // Arrange
            var expected = new RepairListDto
            {
                Repairs = new List<Repair>
                {
                    dto1
                }
            };

            // Act
            var actual = sut.Convert(new JObject[] { repair1 });

            // Assert
            actual.ShouldDeepEqual(expected);
        }

        [Fact]
        public void PreserveOrder()
        {
            // Arrange
            var expected = new RepairListDto
            {
                Repairs = new List<Repair>
                {
                    dto1,
                    dto2
                }
            };

            // Act
            var actual = sut.Convert(new JObject[] { repair1, repair2});

            // Assert
            actual.ShouldDeepEqual(expected);
        }
    }
}
