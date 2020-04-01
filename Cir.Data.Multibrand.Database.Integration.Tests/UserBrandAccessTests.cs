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
using Cir.Data.Access.Helpers;

namespace Cir.Data.Multibrand.Database.Integration.Tests
{
    [TestClass]
    public class UserBrandAccessTests
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

        [TestMethod]
        public async Task User1HasAccessOnlyToAppointedReportsAndResources()
        {
            var emailUser1 = MultibrandDatabase.EmailUser1;
            var mockValidationService = new Mock<ICirValidationService>();
            var inspecToolsService = new Mock<IInspecToolsIntegrationService>();
            var mockCirTemplateService = new Mock<ICirTemplateService>();
            var groupUserBrandRepository = new Mock<IGroupUserBrandRepository>();
            var cirLockService = new Mock<ICirLockService>();
            var cirSyncLogRepository = new Mock<ICirSyncLogRepository>();
            var cirIdGeneratorService = new Mock<ICirIdGeneratorService>();

            var cirPDFStorageRepository = new Mock<ICirPDFStorageRepository>();
            var cirImageStorageRepository = new Mock<ICirImageStorageRepository>();
            var cirNotification = new Mock<ICirNotification>();
             
            mockValidationService.Setup(v => v.ValidateData(It.IsAny<CirSubmissionData>())).Returns(new List<string>());
            mockValidationService.Setup(v => v.IsSchemaTemplateValid(It.IsAny<CirSubmissionData>())).Returns(true);

            ICirSubmissionService cirSubmissionService = new CirSubmissionService(
                mockCirTemplateService.Object,
                MultibrandDatabase.CirTemplateRepository,
                mockValidationService.Object,
                MultibrandDatabase.CirSubmissionDataDynamicRepository,
                MultibrandDatabase.CirHistoryRepository,
                inspecToolsService.Object,
                MultibrandDatabase.CirIdRepository,
                cirLockService.Object,
                cirSyncLogRepository.Object,
                cirIdGeneratorService.Object, cirPDFStorageRepository.Object, cirImageStorageRepository.Object, cirNotification.Object);

            var testData = await cirSubmissionService.GetTableData(new List<CirSubmissionData>());

            Assert.IsNotNull(testData);
            Assert.IsTrue(testData.Count() == 1);
            Assert.IsInstanceOfType(testData.First(), typeof(CirSubmissionData));

            var tmp = testData.First() as CirSubmissionData;
            var example1CollectionName = MultibrandDatabase.Example1CollectionName;
            Assert.IsTrue(Equals(tmp.CirCollectionName, example1CollectionName));
        }
    }
}
