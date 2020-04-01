using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Cir.Data.Access.Models.Authorization;
using Cir.Data.Access.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cir.Data.Access.Tests
{
    [TestClass]
    public class CirBrandServiceTests
    {
        private ICirBrandService _sut;
        private static Mock<IGroupUserBrandRepository> GroupUserBrandRepositoryMock;
        private static Mock<IBrandDataRepository> BrandDataRepositoryMock;

        private const string EXAMPLE_ID_1 = "1";
        private const string EXAMPLE_ID_2 = "2";
        private const string EXAMPLE_BRAND_NAME = "exampleBrandName";
        private const string EXAMPLE_TEMPLATE_NAME = "exampleTemplateName";
        private const string EXAMPLE_USER_GROUP_NAME = "exampleUserGroupName";
        private static BrandDataModel ExampleBrandDataModel => new BrandDataModel { Id = EXAMPLE_ID_1, Name = EXAMPLE_BRAND_NAME };
        private static CirTemplateDataModel ExampleCirTemplateDataModel => new CirTemplateDataModel { Id = EXAMPLE_ID_1, Name = EXAMPLE_TEMPLATE_NAME, CirBrandCollectionName = "", Schema = "", CirBrand = ExampleBrandDataModel };
        private static GroupUserBrand Example1GroupUserBrand => new GroupUserBrand { Id = EXAMPLE_ID_1, Name = EXAMPLE_USER_GROUP_NAME, Brands = new List<string> { EXAMPLE_ID_2 } };
        private static GroupUserBrand Example2GroupUserBrand => new GroupUserBrand { Id = EXAMPLE_ID_2, Name = EXAMPLE_USER_GROUP_NAME, Brands = new List<string> { EXAMPLE_ID_1, EXAMPLE_ID_2 } };

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            GroupUserBrandRepositoryMock = new Mock<IGroupUserBrandRepository>();
            GroupUserBrandRepositoryMock.Setup(r => r.GetAssignedBrandsIdsByUserEmailOrGroupName(It.Is<UserInformation>(userEmailOrGroupName => userEmailOrGroupName.DisplayName == EXAMPLE_ID_1))).Returns(new Task<List<string>>(() => { return new List<string> { EXAMPLE_ID_1 }; }));
            GroupUserBrandRepositoryMock.Setup(r => r.GetAssignedBrandsIdsByUserEmailOrGroupName(It.Is<UserInformation>(userEmailOrGroupName => userEmailOrGroupName.DisplayName != EXAMPLE_ID_1))).Returns(new Task<List<string>>(() => { return new List<string>(); }));
            GroupUserBrandRepositoryMock.Setup(r => r.Add(It.IsAny<GroupUserBrand>()));
            GroupUserBrandRepositoryMock.Setup(r => r.Update(It.IsAny<GroupUserBrand>()));
            GroupUserBrandRepositoryMock.Setup(r => r.GetUserGroupByEmailOrGroupName(It.Is<string>(userEmailOrGroupName => userEmailOrGroupName == EXAMPLE_ID_1))).Returns(Example1GroupUserBrand);
            GroupUserBrandRepositoryMock.Setup(r => r.GetUserGroupByEmailOrGroupName(It.Is<string>(userEmailOrGroupName => userEmailOrGroupName != EXAMPLE_ID_1))).Returns(Example2GroupUserBrand);

            BrandDataRepositoryMock = new Mock<IBrandDataRepository>();
            BrandDataRepositoryMock.Setup(r => r.Get(It.IsAny<string>())).Returns(ExampleBrandDataModel);
            BrandDataRepositoryMock.Setup(r => r.GetAll()).Returns(new List<BrandDataModel> { ExampleBrandDataModel });
            BrandDataRepositoryMock.Setup(r => r.Add(It.IsAny<BrandDataModel>()));
            BrandDataRepositoryMock.Setup(r => r.GetByIds(It.IsAny<IList<string>>())).Returns(new List<BrandDataModel> { ExampleBrandDataModel });
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new CirBrandService(GroupUserBrandRepositoryMock.Object, BrandDataRepositoryMock.Object);
        }

        [TestMethod]
        public void Get_ReturnsBrandObject()
        {
            var brand = _sut.Get(EXAMPLE_ID_1);

            Assert.AreEqual(brand.Name, EXAMPLE_BRAND_NAME);
        }

        [TestMethod]
        public void GetAll_ReturnsBrandCollection()
        {
            var brands = _sut.GetAll();

            brands.ToList().ForEach(brand => Assert.AreEqual(brand.Name, EXAMPLE_BRAND_NAME));

            Assert.IsTrue(brands.Count() == 1);
        }

        //[TestMethod]
        //public async Task GetAllByUserId_ReturnsBrandCollection()
        //{
        //    var brands = await _sut.GetAllByUserId(EXAMPLE_ID_1);

        //    brands.ToList().ForEach(brand => Assert.AreEqual(brand.Name, EXAMPLE_BRAND_NAME));

        //    Assert.IsTrue(brands.Count() == 1);
        //}

        //[TestMethod]
        //public async Task GetAllByUserId_ReturnsEmptyBrandCollection()
        //{
        //    var brands = await _sut.GetAllByUserId(EXAMPLE_ID_2);

        //    Assert.IsFalse(brands.Any());
        //}

        [TestMethod]
        public void AssignBrandToUserGroup_ReturnsBrandObject()
        {
            var groupUser = _sut.AssignBrandToUserGroup(EXAMPLE_ID_1, EXAMPLE_ID_1);

            Assert.AreEqual(groupUser.Id, EXAMPLE_ID_1);
            Assert.IsTrue(groupUser.Brands.Any(b => b == EXAMPLE_ID_1));
            Assert.IsTrue(groupUser.Brands.Any(b => b == EXAMPLE_ID_2));
        }

        [TestMethod]
        public void UnassignBrandFromUserGroup_ReturnsBrandObject()
        {
            var groupUser = _sut.UnassignBrandFromUserGroup(EXAMPLE_ID_2, EXAMPLE_ID_2);

            Assert.AreEqual(groupUser.Id, EXAMPLE_ID_2);
            Assert.IsTrue(groupUser.Brands.Any(b => b == EXAMPLE_ID_1));
            Assert.IsFalse(groupUser.Brands.Any(b => b == EXAMPLE_ID_2));
        }
    }
}
