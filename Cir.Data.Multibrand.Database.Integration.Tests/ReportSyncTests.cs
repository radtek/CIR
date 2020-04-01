using Cir.Data.Access.Models;
using Cir.Data.Access.Services;
using Cir.Data.Access.Services.Integration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Cir.Data.Access.Models.Authorization;
using Cir.Data.Access.DataAccess;
using System.Threading.Tasks;

namespace Cir.Data.Multibrand.Database.Integration.Tests
{
    [TestClass]
    public class ReportSyncTests
    {
        private static DatabaseGenerator MultibrandDatabase;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            MultibrandDatabase = new DatabaseGenerator();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            MultibrandDatabase.Dispose();
        }

        //[TestMethod]
        //public async Task SyncRequest_RecognizeReportToBeUpdatedInDatabase()
        //{
        //    var emailUser1 = MultibrandDatabase.EmailUser1;
        //    var cirSubmissionDataDynamicRepository = MultibrandDatabase.CirSubmissionDataDynamicRepository;
        //    var mockValidationService = new Mock<ICirValidationService>();
        //    var mockInspecToolsService = new Mock<IInspecToolsIntegrationService>();
        //    var mockCirTemplateService = new Mock<ICirTemplateService>();
        //    var mockGroupUserBrandRepository = new Mock<IGroupUserBrandRepository>();
        //    var cirLockService = new Mock<ICirLockService>();

        //    mockValidationService.Setup(v => v.ValidateData(It.IsAny<CirSubmissionData>())).Returns(new List<string>());
        //    mockValidationService.Setup(v => v.IsSchemaTemplateValid(It.IsAny<CirSubmissionData>())).Returns(true);

        //    ICirSubmissionService cirSubmissionService = new CirSubmissionService(
        //        mockCirTemplateService.Object,
        //        MultibrandDatabase.CirTemplateRepository,
        //        mockValidationService.Object,
        //        cirSubmissionDataDynamicRepository,
        //        MultibrandDatabase.CirHistoryRepository,
        //        mockInspecToolsService.Object, 
        //        MultibrandDatabase.CirIdRepository,
        //        mockGroupUserBrandRepository.Object,
        //        cirLockService.Object);

        //    var example1CollectionName = MultibrandDatabase.Example1CollectionName;
        //    var reportsToSync = cirSubmissionDataDynamicRepository.GetAllRelatedToUser(emailUser1, new List<string> { example1CollectionName });
        //    var oldDataToVerifySyncUpdateAgainst = reportsToSync.Select(r => r.ModifiedOn).ToList();

        //    foreach (var report in reportsToSync)
        //    {
        //        report.ModifiedOn = report.ModifiedOn.AddDays(2.0).AddHours(2.0);
        //    }

        //    //Test
        //    var resultReports = (await cirSubmissionService.SyncRequest(new UserInformation { DisplayName = emailUser1 }, reportsToSync)).ToList();

        //    CollectionAssert.AreNotEqual(reportsToSync, resultReports);
        //    CollectionAssert.AreEqual(reportsToSync.Select(r => r.Id).ToList(), resultReports.Select(r => r.Id).ToList());
        //}

        [TestMethod]
        public void SyncUpdate_UpdatedReportInDatabase()
        {
            var emailUser1 = MultibrandDatabase.EmailUser1;
            var cirSubmissionDataDynamicRepository = MultibrandDatabase.CirSubmissionDataDynamicRepository;
            var mockValidationService = new Mock<ICirValidationService>();
            var mockInspecToolsService = new Mock<IInspecToolsIntegrationService>();
            var mockCirTemplateService = new Mock<ICirTemplateService>();
            var mockGroupUserBrandRepository = new Mock<IGroupUserBrandRepository>();
            var cirLockService = new Mock<ICirLockService>();

            mockValidationService.Setup(v => v.ValidateData(It.IsAny<CirSubmissionData>())).Returns(new List<string>());
            mockValidationService.Setup(v => v.IsSchemaTemplateValid(It.IsAny<CirSubmissionData>())).Returns(true);

            //ICirSubmissionService cirSubmissionService = new CirSubmissionService(
            //    mockCirTemplateService.Object,
            //    MultibrandDatabase.CirTemplateRepository,
            //    mockValidationService.Object,
            //    cirSubmissionDataDynamicRepository,
            //    MultibrandDatabase.CirHistoryRepository,
            //    mockInspecToolsService.Object,
            //    MultibrandDatabase.CirIdRepository);

            var vestasGearboxReportExampleId = MultibrandDatabase.VestasGearboxReportExampleId;
            var example1CollectionName = MultibrandDatabase.Example1CollectionName;
            var report = cirSubmissionDataDynamicRepository.Get(vestasGearboxReportExampleId, example1CollectionName);
            var oldDataToVerifySyncUpdateAgainst = report.ModifiedOn;

            report.ModifiedOn = report.ModifiedOn.AddDays(2.0).AddHours(2.0);

            //Test
            //cirSubmissionService.SyncUpdate(report, string.Empty);

            // var updatedReports = cirSubmissionDataDynamicRepository.GetAllRelatedToUser(emailUser1, new List<string> { example1CollectionName });
            var updatedReports = cirSubmissionDataDynamicRepository.GetAllRelatedToUser(emailUser1,  example1CollectionName );
            var newValueToVerifySyncUpdateAgainst = updatedReports.Select(r => r.ModifiedOn).ToList().First();

            Assert.IsFalse(Equals(oldDataToVerifySyncUpdateAgainst, newValueToVerifySyncUpdateAgainst));
            Assert.IsTrue(Equals(report.ModifiedOn, newValueToVerifySyncUpdateAgainst));
        }
    }
}


