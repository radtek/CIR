using Cir.Sync.Services.DAL;
using Cir.Sync.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cir.Sync.Services.BLL;
using Cir.Sync.Services;
using System;
using Moq;
using Microsoft.Practices.Unity;
using WCFClient;
using Cir.Sync.Services.ServiceContracts;
using System.Web;

namespace Cir.Sync.Service.Test
{
    //[TestClass]
    //public class DeleteCir
    //{
    //    // mock wcf interface
    //    Mock<Services.ServiceContracts.ISyncService> wcfMock = null;
    //    [TestInitialize]
    //    public void Init_CirData()
    //    {
    //        wcfMock = new Mock<Services.ServiceContracts.ISyncService>();
    //    }

    //    [TestMethod]
    //    public void delete_existing_cir()
    //    {
    //        //HttpContext.Current = new HttpContext(new HttpRequest(null, "http://tempuri.org", null), new HttpResponse(null));
    //        string Result = "Success";
    //        CirDataActionResponse objCirDataResponse=new CirDataActionResponse();
    //        // setup for wcf service GetData method
    //        wcfMock.Setup<CirDataActionResponse>(s => s.CirProcess(It.IsAny<CirDataDetail>())).Returns(objCirDataResponse);
    //        // create object to register with IoC
    //        Services.ServiceContracts.ISyncService wcfMockObject = wcfMock.Object;
    //        // register instance
    //        UnityHelper.IoC = new UnityContainer();
    //        UnityHelper.IoC.RegisterInstance(wcfMockObject);
    //        // create ServiceAgent object using parameterized constructor (for unit test)
    //        WCFServiceAgent serviceAgent = new WCFServiceAgent(true);

    //        //Arrange section
    //        CirDataDetail cirDataDetail = new CirDataDetail();
    //        cirDataDetail.CirDataId = 306850;
    //        cirDataDetail.comment = "Delete Cir";
    //        cirDataDetail.modifiedBy = "1";
    //        cirDataDetail.Progress = Convert.ToInt32(Progress.PendingDelete);
    //        //Act section
    //        objCirDataResponse = serviceAgent.CirProcess(cirDataDetail);
    //        // verify if the expected method called during test or not
    //        //wcfMock.Verify(s => s.CirProcess(It.IsAny<CirDataDetail>()), Times.Exactly(1));
    //        //Assert section
    //        //HTTP context object is not available in test case
    //        //Assert.AreEqual(Result.ToUpper(), objCirDataResponse.message.ToUpper());
    //    }

    //    [TestCleanup]
    //    public void Clean_CirData()
    //    {
    //        wcfMock = null;
    //    }
    //}
}
