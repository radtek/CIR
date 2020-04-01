using System;
using System.Linq;
using Cir.Data.Access.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cir.Data.Multibrand.Database.Integration.Tests
{
    [TestClass]
    public class CirRevisionTests
    {
        private static DatabaseGenerator _multibrandDatabase;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _multibrandDatabase = new DatabaseGenerator();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _multibrandDatabase.Dispose();
        }

        private static CirSubmissionData GetCir()
        {
            return new CirSubmissionData
            {
                CirTemplateId = Guid.NewGuid().ToString(),
                CirCollectionName = _multibrandDatabase.Example1CollectionName,
                State = CirState.Draft,
                Schema = "test",
                Data = "test",
                CreatedOn = DateTime.Now,
                CreatedBy = "test",
                ModifiedOn = DateTime.Now,
                ModifiedBy = "test"
            };
        }

       // [TestMethod]
        //public void CirRevision_Add_StoresRevision()
        //{
        //    var cir = GetCir();

        //    _multibrandDatabase.CirSubmissionDataDynamicRepository.Add(cir, cir.CirCollectionName);

        //    var revisions = _multibrandDatabase.CirHistoryRepository.GetAllCirsRevisionItems(cir.CirId, cir.Id);

        //    Assert.IsTrue(revisions.Any(x => x.Id == cir.Id), "Adding CIR should store one revision");
        //}

        //[TestMethod]
        //public void CirRevision_AddTwo_StoresTwoRevisions()
        //{
        //    var cir = GetCir();

        //    _multibrandDatabase.CirSubmissionDataDynamicRepository.Add(cir, cir.CirCollectionName);

        //    var dbCir =
        //        _multibrandDatabase.CirSubmissionDataDynamicRepository.GetByCirId(cir.CirId, cir.CirCollectionName);

        //    _multibrandDatabase.CirSubmissionDataDynamicRepository.Update(dbCir, dbCir.CirCollectionName);

        //    var revisions = _multibrandDatabase.CirHistoryRepository.GetAllRevisionItems(dbCir.CirId, dbCir.Id);

        //    Assert.IsTrue(revisions.Count() == 2, "Adding and updating CIR should store two revisions");
        //}

        //[TestMethod]
        //public void CirRevision_GetCirRevision_ReturnsAddedRevision()
        //{
        //    var cir = GetCir();

        //    _multibrandDatabase.CirSubmissionDataDynamicRepository.Add(cir, cir.CirCollectionName);

        //    var dbCir =
        //        _multibrandDatabase.CirSubmissionDataDynamicRepository.GetByCirId(cir.CirId, cir.CirCollectionName);
        //    var revisions = _multibrandDatabase.CirHistoryRepository.GetAllRevisionItems(dbCir.CirId, dbCir.Id);

        //    var singleRevision = _multibrandDatabase.CirHistoryRepository.GetCirRevision(revisions.First().Id);

        //    Assert.IsTrue(singleRevision.CirSubmissionData.CirId == cir.CirId, "Getting single revision should return CIR with the same cirId");
        //}
    }
}
