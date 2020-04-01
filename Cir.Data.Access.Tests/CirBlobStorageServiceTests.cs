using Cir.Data.Access.DataAccess;
using Cir.Data.Access.DataAccessDynamic;
using Cir.Data.Access.Models;
using Cir.Data.Access.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cir.Data.Access.Models.Authorization;

namespace Cir.Data.Access.Tests
{
    [TestClass]
    public class CirBlobStorageServiceTests
    {
        private ICirBlobImageService _sut;
        private static Mock<ICirImageStorageRepository> CirImageStorageRepositoryMock;
        private static Mock<ICirTemplateRepository> CirTemplateRepositoryMock;
        private static Mock<IGroupUserBrandRepository> GroupUserBrandRepositoryMock;
        private static Mock<ICirValidationService> ValidationServiceMock;
        private static Mock<ICirSubmissionService> CirSubmissionServiceMock;
        private static Mock<ICirSubmissionDataDynamicRepository> DataDynamicRepositoryMock;
        private static Mock<ICirTemplateService> CirTemplateServiceMock;
        private const string UNEXPECTED_EXCEPTION_MESSAGE = "Unexpected exception occured during test. ";
        private static string ExampleId => "1";
        private static ImageDataModel ImageDataModelExample => new ImageDataModel { BinaryData = "", CirId = ExampleId,  Url = "", BinaryDataUrl = "", BlobGuid = Guid.NewGuid().ToString(), ImageId = Guid.NewGuid().ToString(), TemplateId = "" };
        private static Uri UriExample => new Uri(Environment.CurrentDirectory);

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            CirImageStorageRepositoryMock = new Mock<ICirImageStorageRepository>();
            CirImageStorageRepositoryMock.Setup(r => r.GetBlobUriByImageUrl(It.IsAny<string>())).Returns(UriExample.ToString);
            CirImageStorageRepositoryMock.Setup(r => r.GetAllBlobsUriByCirID(It.IsAny<string>())).ReturnsAsync(new List<Uri> { UriExample });
            CirImageStorageRepositoryMock.Setup(r => r.Add(It.IsAny<ImageDataModel>())).Returns(ImageDataModelExample);
            CirImageStorageRepositoryMock.Setup(r => r.DeleteImageData(It.IsAny<ImageDataModel>()));
            CirImageStorageRepositoryMock.Setup(r => r.DeleteAllImages(It.IsAny<string>()));

            GroupUserBrandRepositoryMock = new Mock<IGroupUserBrandRepository>();
            CirTemplateRepositoryMock = new Mock<ICirTemplateRepository>();

            CirSubmissionServiceMock = new Mock<ICirSubmissionService>();
            CirSubmissionServiceMock.Setup(r => r.Get(It.IsAny<string>(), It.IsAny<string>())).Returns(new CirSubmissionData { ImageReferences = new List<ImageDataModel>() });
            CirSubmissionServiceMock.Setup(r => r.Update(It.IsAny<CirSubmissionData>(), string.Empty)).Returns(new CirSubmissionData());

            DataDynamicRepositoryMock = new Mock<ICirSubmissionDataDynamicRepository>();

            CirTemplateServiceMock = new Mock<ICirTemplateService>();
        }

        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    _sut = new CirBlobImageService(CirImageStorageRepositoryMock.Object, CirSubmissionServiceMock.Object,
        //        DataDynamicRepositoryMock.Object, CirTemplateServiceMock.Object);
        //}

        //[TestMethod]
        //public async Task GetAll_ReturnsAllUri()
        //{
        //    var uriList = await _sut.GetAll(string.Empty);

        //    uriList.ForEach(uri => Assert.AreEqual(uri, UriExample));
        //}

        //[TestMethod]
        //public void Add_ReturnsImageDataList()
        //{
        //    var imageData = _sut.Add(ImageDataModelExample, string.Empty);

        //    Assert.AreEqual(imageData.CirId, ExampleId);
        //}

        //[TestMethod]
        //public async Task DeleteBlob_DoesNotThrowException()
        //{
        //    try
        //    {
        //        await _sut.DeleteBlob(ExampleId);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail(UNEXPECTED_EXCEPTION_MESSAGE + e.Message);
        //    }
        //}

        //[TestMethod]
        //public async Task DeleteAllBlob_DoesNotThrowException()
        //{
        //    try
        //    {
        //        await _sut.DeleteAllBlob(ExampleId);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail(UNEXPECTED_EXCEPTION_MESSAGE + e.Message);
        //    }
        //}
    }
}
