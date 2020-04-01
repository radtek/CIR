using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Cir.Data.Access.Services;
using Cir.Data.Access.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Cir.Data.Access.Tests
{
    [TestClass]
    public class CirValidationServiceTests
    {
        private ICirValidationService _sut;
        private static Mock<ICirTemplateRepository> CirTemplateRepositoryMock;
        private static Mock<IValidationService> CirValidationServiceMock;
        private const string EXAMPLE_ID_1 = "1";
        private static BrandDataModel ExampleBrandDataModel => new BrandDataModel { Id = EXAMPLE_ID_1, Name = "" };
        private static CirTemplateDataModel ExampleCirTemplateDataModel => new CirTemplateDataModel { Id = EXAMPLE_ID_1, Name = "", CirBrandCollectionName = "", Schema = "", CirBrand = ExampleBrandDataModel };
        private static object ExampleJson => JsonConvert.SerializeObject(new { test = "json" });
        private static CirSubmissionData GetExampleItem(string id)
        {
            return new CirSubmissionData
            {
                Id = id,
                Schema = ExampleJson,
                Data = ExampleJson
            };
        }

        private static CirSubmissionData ExampleItem1 => GetExampleItem(EXAMPLE_ID_1);

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            CirTemplateRepositoryMock = new Mock<ICirTemplateRepository>();
           // CirTemplateRepositoryMock.Setup(r => r.GetTemplates(It.IsAny<List<string>>())).Returns(new List<CirTemplateDataModel> { ExampleCirTemplateDataModel });
            CirTemplateRepositoryMock.Setup(r => r.Get(It.IsAny<string>())).Returns(ExampleCirTemplateDataModel);
            CirTemplateRepositoryMock.Setup(r => r.Add(It.IsAny<CirTemplateDataModel>()));


            CirValidationServiceMock = new Mock<IValidationService>();
            string[] data = new string[1];
            data[0] = "12345";
            CirValidationServiceMock.Setup(r => r.Validate<TurbineNumberValidation>(data));
            
        }

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //   // _sut = new CirValidationService(CirTemplateRepositoryMock.Object, CirValidationServiceMock.Object);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(InvalidCastException), "Object contains not a valid JSON")]
        //public void  IsDataValid_ReturnsTrue()
        //{
        //    var isValid = _sut.ValidateData(ExampleItem1);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(InvalidCastException), "Object contains not a valid JSON")]
        //public void IsSchemaTemplateValid_ReturnsTrue()
        //{
        //    var isValid = _sut.IsSchemaTemplateValid(ExampleItem1);
        //}
    }
}
