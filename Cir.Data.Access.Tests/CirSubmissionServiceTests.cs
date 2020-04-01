using Cir.Data.Access.DataAccess;
using Cir.Data.Access.DataAccessDynamic;
using Cir.Data.Access.Models;
using Cir.Data.Access.Services;
using Cir.Data.Access.Services.Integration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cir.Data.Access.Models.Authorization;

namespace Cir.Data.Access.Tests
{
    [TestClass]
    public class CirSubmissionServiceTests
    {
        private ICirSubmissionService _sut;
        private static Mock<ICirTemplateRepository> CirTemplateRepositoryMock;
        private static Mock<ICirTemplateService> CirTemplateServiceMock;
        private static Mock<IGroupUserBrandRepository> GroupUserBrandRepositoryMock;
        private static Mock<ICirValidationService> ValidationServiceMock;
        private static Mock<ICirSubmissionDataDynamicRepository> DataDynamicRepositoryMock;
        private static Mock<ICirSubmissionHistoricDataRepository> HistoricDataRepositoryMock;
        private static Mock<IInspecToolsIntegrationService> InspecToolsSericeMock;
        private static Mock<ICirIdRepository> CirIdRepository;
        private static Mock<ICirLockService> CirLockService;

        private static object ExampleJson => JsonConvert.SerializeObject(new { test = "json" });
        private const string EXAMPLE_ID_1 = "1";
        private const string EXAMPLE_ID_2 = "2";
        private const string UNEXPECTED_EXCEPTION_MESSAGE = "Unexpected exception occured during test. ";

        private static CirSubmissionData GetExampleItem(string id)
        {
            return new CirSubmissionData
            {
                Id = id,
                Schema = ExampleJson,
                Data = ExampleJson
            };
        }

        private static List<CirSubmissionData> GetExampleItems => new List<CirSubmissionData> { ExampleItem1, ExampleItem2 };
        private static CirSubmissionData ExampleItem1 => GetExampleItem(EXAMPLE_ID_1);
        private static CirSubmissionData ExampleItem2 => GetExampleItem(EXAMPLE_ID_2);
        private static BrandDataModel ExampleBrandDataModel => new BrandDataModel { Id = EXAMPLE_ID_1, Name = "" };
        private static CirTemplateDataModel ExampleCirTemplateDataModel => new CirTemplateDataModel { Id = EXAMPLE_ID_1, Name = "", CirBrandCollectionName = "", Schema = "", CirBrand = ExampleBrandDataModel };

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            CirTemplateRepositoryMock = new Mock<ICirTemplateRepository>();
            //CirTemplateRepositoryMock.Setup(r => r.GetTemplates(It.IsAny<List<string>>())).Returns(new List<CirTemplateDataModel> { ExampleCirTemplateDataModel });
            CirTemplateRepositoryMock.Setup(r => r.Get(It.IsAny<string>())).Returns(ExampleCirTemplateDataModel);
            CirTemplateRepositoryMock.Setup(r => r.Add(It.IsAny<CirTemplateDataModel>()));

            GroupUserBrandRepositoryMock = new Mock<IGroupUserBrandRepository>();
            GroupUserBrandRepositoryMock.Setup(r => r.GetAssignedBrandsIdsByUserEmailOrGroupName(It.IsAny<UserInformation>())).Returns(new System.Threading.Tasks.Task<List<string>>(() => { return new List<string>();}));
            GroupUserBrandRepositoryMock.Setup(r => r.Add(It.IsAny<GroupUserBrand>()));

            ValidationServiceMock = new Mock<ICirValidationService>();
            ValidationServiceMock.Setup(v => v.ValidateData(It.IsAny<CirSubmissionData>())).Returns(new List<string>());
            ValidationServiceMock.Setup(v => v.IsSchemaTemplateValid(It.IsAny<CirSubmissionData>())).Returns(true);

            DataDynamicRepositoryMock = new Mock<ICirSubmissionDataDynamicRepository>();
            DataDynamicRepositoryMock.Setup(r => r.Get(It.IsAny<string>(), It.IsAny<string>())).Returns((string id, string templateId) => GetExampleItems.First(item => item.Id.Equals(id)));
            DataDynamicRepositoryMock.Setup(r => r.GetAll(It.IsAny<string>())).Returns(GetExampleItems.AsQueryable());
            //DataDynamicRepositoryMock.Setup(r => r.GetAllRelatedToUser(It.IsAny<string>(), It.IsAny<IEnumerable<string>>())).Returns(GetExampleItems.Cast<CirSubmissionSyncData>().ToList());
            DataDynamicRepositoryMock.Setup(r => r.GetAllBySyncData(It.IsAny<List<CirSubmissionSyncData>>())).Returns(GetExampleItems);
            DataDynamicRepositoryMock.Setup(r => r.Add(It.IsAny<CirSubmissionData>(), It.IsAny<string>()));
            DataDynamicRepositoryMock.Setup(r => r.Update(It.IsAny<CirSubmissionData>(), It.IsAny<string>()));
            DataDynamicRepositoryMock.Setup(r => r.Delete(It.IsAny<string>(), It.IsAny<string>()));

            HistoricDataRepositoryMock = new Mock<ICirSubmissionHistoricDataRepository>();
            InspecToolsSericeMock = new Mock<IInspecToolsIntegrationService>();

            CirTemplateServiceMock = new Mock<ICirTemplateService>();

            CirIdRepository = new Mock<ICirIdRepository>();
            CirLockService = new Mock<ICirLockService>();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //_sut = new CirSubmissionService(CirTemplateServiceMock.Object,
            //    CirTemplateRepositoryMock.Object, 
            //    ValidationServiceMock.Object, 
            //    DataDynamicRepositoryMock.Object,
            //    HistoricDataRepositoryMock.Object,
            //    InspecToolsSericeMock.Object,
            //    CirIdRepository.Object);
        }

        //[TestMethod]
        //public void Get_ReturnsItem()
        //{
        //    var item = ExampleItem1;
        //    var id = ExampleItem1.Id;
        //    var templateId = EXAMPLE_ID_1;

        //    var cirSubmissionData = _sut.Get(id, templateId);

        //    Assert.IsInstanceOfType(cirSubmissionData, typeof(CirSubmissionData));
        //    Assert.AreEqual(item.Schema, cirSubmissionData.Schema);
        //    Assert.AreEqual(item.Data, cirSubmissionData.Data);
        //    Assert.AreEqual(item.Partition, cirSubmissionData.Partition);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(InvalidOperationException), "Sequence contains no matching element")]
        //public void Get_ThrowsException()
        //{
        //    var id = Guid.NewGuid().ToString();
        //    var templateId = EXAMPLE_ID_1;

        //    var cirSubmissionData = _sut.Get(id, templateId);
        //}

        //[TestMethod]
        //public void GetAll_ReturnsAllItems()
        //{
        //    var templateId = EXAMPLE_ID_1;

        //    var items = _sut.GetAll(templateId).ToList();

        //    CollectionAssert.AllItemsAreInstancesOfType(items, typeof(CirSubmissionData));
        //    CollectionAssert.AllItemsAreUnique(items);
        //    Assert.IsTrue(items.Any(item => item.Id == EXAMPLE_ID_1));
        //    Assert.IsTrue(items.Any(item => item.Id == EXAMPLE_ID_2));
        //}

        //[TestMethod]
        //public async Task SyncRequest_ReturnsListOfItemsToSyncAsync()
        //{
        //    var items = await _sut.SyncRequest(new UserInformation() { DisplayName = EXAMPLE_ID_1 }, new List<CirSubmissionData> { GetExampleItem("3"), GetExampleItem("4") });

        //    Assert.IsTrue(items..Count() == 4);
        //}

        //[TestMethod]
        //public async Task SyncRequest_ReturnsNoItemsToSyncAsync()
        //{
        //    var items = await _sut.SyncRequest(new UserInformation() { DisplayName = EXAMPLE_ID_1 }, GetExampleItems);

        //    Assert.IsTrue(!items.Any());
        //}

        //[TestMethod]
        //public void SyncUpdate_DoesNotThrowExceptionWithUpdateObject()
        //{
        //    var item = ExampleItem1;

        //    item.CreatedOn = item.ModifiedOn = DateTime.Now;

        //    try
        //    {
        //        _sut.SyncUpdate(item, string.Empty);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail(UNEXPECTED_EXCEPTION_MESSAGE + e.Message);
        //    }
        //}

        //[TestMethod]
        //public void SyncUpdate_DoesNotThrowExceptionWithInsertObject()
        //{
        //    var item = ExampleItem1;

        //    item.CreatedOn = DateTime.Now;
        //    item.ModifiedOn = DateTime.Now.AddDays(1);

        //    try
        //    {
        //        _sut.SyncUpdate(item, string.Empty);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail(UNEXPECTED_EXCEPTION_MESSAGE + e.Message);
        //    }
        //}

        //[TestMethod]
        //public void Add_DoesNotThrowException()
        //{
        //    try
        //    {
        //        _sut.Add(ExampleItem1);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail(UNEXPECTED_EXCEPTION_MESSAGE + e.Message);
        //    }
        //}

        //[TestMethod]
        //public void Update_DoesNotThrowException()
        //{
        //    try
        //    {
        //        _sut.Update(ExampleItem1, string.Empty);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail(UNEXPECTED_EXCEPTION_MESSAGE + e.Message);
        //    }
        //}

        //[TestMethod]
        //public void Delete_DoesNotThrowException()
        //{
        //    try
        //    {
        //        _sut.Delete(Guid.NewGuid().ToString(), "");
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail(UNEXPECTED_EXCEPTION_MESSAGE + e.Message);
        //    }
        //}
    }
}
