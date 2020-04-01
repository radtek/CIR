using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Cir.Data.Access.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Cir.Data.Access.Models.Authorization;
using System.Threading.Tasks;

namespace Cir.Data.Access.Tests
{
    [TestClass]
    public class HotlistServiceTest
    {
        private IHotlistService _sut;
        private static Mock<IGroupUserBrandRepository> GroupUserBrandRepositoryMock;
        private static Mock<IHotlistRepository> HotlistRepositoryMock;

        private const string EXAMPLE_ID_1 = "1";
        private const string EXAMPLE_ID_2 = "2";
        private const string EXAMPLE_BRAND_NAME = "exampleBrandName";
        private const string EXAMPLE_TEMPLATE_NAME = "exampleTemplateName";
        private const string EXAMPLE_USER_GROUP_NAME = "exampleUserGroupName";
        private const long ExampleHotItemId = 246;
        private static BrandDataModel ExampleBrandDataModel => new BrandDataModel { Id = EXAMPLE_ID_1, Name = EXAMPLE_BRAND_NAME };
        private static CirTemplateDataModel ExampleCirTemplateDataModel => new CirTemplateDataModel { Id = EXAMPLE_ID_1, Name = EXAMPLE_TEMPLATE_NAME, CirBrandCollectionName = "", Schema = "", CirBrand = ExampleBrandDataModel };
        private static HotlistDataModel ExampleHotlistDataModel => new HotlistDataModel
        {
            Id = EXAMPLE_ID_1,
            CirTemplate = ExampleCirTemplateDataModel,
            Brand = ExampleBrandDataModel,
            Email = "cim-hotlist@vestas.com",
            ReportType = "Main Bearing",
            VestasItemNumber = "60079255",
            VestasItemName = "BEARING 240/630 ECJ/W33C2 RE10",
            ManufacturerName = "SKF",
            HotItemDisplay = "60079255 [Main Bearing]: BEARING 240/630 ECJ/W33C2 RE10",
            HotItemId = ExampleHotItemId,
            ReportTypeId = 6
        };

        private static GroupUserBrand Example1GroupUserBrand => new GroupUserBrand { Id = EXAMPLE_ID_1, Name = EXAMPLE_USER_GROUP_NAME, Brands = new List<string> { EXAMPLE_ID_2 } };
        private static GroupUserBrand Example2GroupUserBrand => new GroupUserBrand { Id = EXAMPLE_ID_2, Name = EXAMPLE_USER_GROUP_NAME, Brands = new List<string> { EXAMPLE_ID_1, EXAMPLE_ID_2 } };

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            GroupUserBrandRepositoryMock = new Mock<IGroupUserBrandRepository>();
            GroupUserBrandRepositoryMock.Setup(r => r.GetAssignedBrandsIdsByUserEmailOrGroupName(It.Is<UserInformation>(userEmailOrGroupName => userEmailOrGroupName.DisplayName == EXAMPLE_ID_1))).Returns(new Task<List<string>>(() => { return new List<string> { EXAMPLE_ID_1 }; }));
            GroupUserBrandRepositoryMock.Setup(r => r.GetAssignedBrandsIdsByUserEmailOrGroupName(It.Is<UserInformation>(userEmailOrGroupName => userEmailOrGroupName.DisplayName != EXAMPLE_ID_1))).Returns(new Task<List<string>>(() => { return new List<string> (); }));
            GroupUserBrandRepositoryMock.Setup(r => r.Add(It.IsAny<GroupUserBrand>()));
            GroupUserBrandRepositoryMock.Setup(r => r.Update(It.IsAny<GroupUserBrand>()));
            GroupUserBrandRepositoryMock.Setup(r => r.GetUserGroupByEmailOrGroupName(It.Is<string>(userEmailOrGroupName => userEmailOrGroupName == EXAMPLE_ID_1))).Returns(Example1GroupUserBrand);
            GroupUserBrandRepositoryMock.Setup(r => r.GetUserGroupByEmailOrGroupName(It.Is<string>(userEmailOrGroupName => userEmailOrGroupName != EXAMPLE_ID_1))).Returns(Example2GroupUserBrand);

            HotlistRepositoryMock = new Mock<IHotlistRepository>();
            HotlistRepositoryMock.Setup(r => r.Get(It.IsAny<string>())).Returns(ExampleHotlistDataModel);
            HotlistRepositoryMock.Setup(r => r.GetAll()).Returns(new List<HotlistDataModel> { ExampleHotlistDataModel });
            HotlistRepositoryMock.Setup(r => r.Add(It.IsAny<HotlistDataModel>()));
            HotlistRepositoryMock.Setup(r => r.Delete(It.IsAny<string>()));
            HotlistRepositoryMock.Setup(r => r.GetByHotItemId(It.IsAny<long>())).Returns(ExampleHotlistDataModel);
            HotlistRepositoryMock.Setup(r => r.Update(It.IsAny<HotlistDataModel>()));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new HotlistService(HotlistRepositoryMock.Object, GroupUserBrandRepositoryMock.Object);
        }

        [TestMethod]
        public void Get_ReturnsHotlistObject()
        {
            var hotlist = _sut.Get(EXAMPLE_ID_1);

            Assert.AreEqual(hotlist.HotItemId, ExampleHotItemId);
        }

        [TestMethod]
        public void GetAll_ReturnsHotlistCollection()
        {
            var hotlists = _sut.GetAll();

            hotlists.ToList().ForEach(hotlist => Assert.AreEqual(hotlist.HotItemId, ExampleHotItemId));

            Assert.IsTrue(hotlists.Count() == 1);
        }

        [TestMethod]
        public void Add_AddsHotlistWithHotItemIdIncrementationNotTriggered()
        {
           var hotItemAdded = _sut.Add(ExampleHotlistDataModel);

            Assert.IsTrue(hotItemAdded.HotItemId == ExampleHotItemId);
        }

        [TestMethod]
        public void Add_AddsHotlistWithoutHotItemIdIncrementationTriggered()
        {
            var exampleHotlistDataModelTmp = ExampleHotlistDataModel;

            exampleHotlistDataModelTmp.HotItemId = 0;

            var hotItemAdded = _sut.Add(exampleHotlistDataModelTmp);

            Assert.IsTrue(hotItemAdded.HotItemId == ExampleHotItemId + 1);
        }

        [TestMethod]
        public void GetTableDataByUserId_ReturnsBrandObject()
        {
            var list = _sut.GetTableData(new List<string> { EXAMPLE_ID_1 });

            Assert.IsTrue(list.Any(hotlist => ((HotlistDataModel)hotlist).HotItemId == ExampleHotItemId));
        }

        [TestMethod]
        public void GetByHotItemId_ReturnsBrandObject()
        {
            var hotItem = _sut.GetByHotItemId(ExampleHotItemId);

            Assert.AreEqual(hotItem.Id, EXAMPLE_ID_1);
        }
    }
}
