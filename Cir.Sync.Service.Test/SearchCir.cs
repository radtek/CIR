using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cir.Sync.Services.DAL;
using Cir.Sync.Services.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cir.Sync.Services.BLL;
using Cir.Sync.Services;
using Cir.Sync.Services.ServiceContracts;
//using Cir.Azure.MobileApp.Service.CirSyncService;

namespace Cir.Sync.Service.Test
{
    [TestClass]
    public class SearchCir
    {
        CirDataDetail cirDataDetail;
        ISyncService _ServiceClient;

        [TestInitialize]
        public void Init_CirData()
        {
            cirDataDetail = null;
            _ServiceClient = new SyncService();
        }

        //[TestMethod]
        //public void Search_Existing_Cir_By_CirId()
        //{
            
        //    //Arrange section
        //    long CirID = 306663;
        //    //Act section
        //    cirDataDetail=_ServiceClient.GetCirDataDetails(CirID);
        //    //Assert section
        //    Assert.IsNotNull(cirDataDetail);
        //}

        //[TestMethod]
        //public void Search_Non_Existing_Cir_By_CirId()
        //{
        //    //Arrange section
            
        //    CirDataDetail cirDataDetail;
        //    long CirID = 0;
        //    //Act section
        //    cirDataDetail = _ServiceClient.GetCirDataDetails(CirID);
        //    //Assert section
        //    Assert.IsNull(cirDataDetail);
        //}

       
        //[TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void Exception_Search_Cir_By_CirId()
        //{
        //    //Arrange section
        //    long CirID = 306663;
        //    CirDataDetail cirDataDetail;
        //    //Act section
        //    cirDataDetail = DACIRView.GetCirDataDetails(CirID);
        //    //Assert section
        //    Assert.IsNull(CirID);
        //}

        [TestCleanup]
        public void Clean_CirData()
        {
            cirDataDetail = null;
            _ServiceClient = null;
        }
    }
}
