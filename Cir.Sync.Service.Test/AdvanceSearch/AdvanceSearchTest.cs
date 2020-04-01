using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cir.Sync.Services.AdvanceSearch.Tests
{
    [TestClass()]
    public class AdvanceSearchTest
    {
        private const string EXAMPLE_BRAND_NAME = "exampleBrandName";
        Mock<Services.ServiceContracts.ISyncService> wcfMock = null;
        [TestInitialize]
        public void Init_CirData()
        {
            wcfMock = new Mock<Services.ServiceContracts.ISyncService>();
        }
        //[TestMethod()]
        //public void GetBrandListTest()
        //{
        //    List<Cir.Sync.Services.AdvanceSearch.Brand> brands = new List<Brand>();
        //    wcfMock.Setup<List<Cir.Sync.Services.AdvanceSearch.Brand>>(s => s.GetBrandList()).Returns(brands);
        //    // create object to register with IoC
        //    Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
        //    // register instance
        //    UnityHelper.IoC = new UnityContainer();
        //    UnityHelper.IoC.RegisterInstance(wcfMockObject);
        //    WCFServiceAgent serviceAgent = new WCFServiceAgent(true);
        //    brands = serviceAgent.GetBrandList();

        //    //brands.ForEach(brand => Assert.AreEqual(brand.BrandName, EXAMPLE_BRAND_NAME));

        //    Assert.IsNotNull(brands);
        //}
    }
}