using System;
using System.Linq;
using Cir.Data.Access.Models;
using Cir.Data.Access.Services;
using Cir.Data.Access.Services.Integration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cir.Data.Multibrand.Database.Integration.Tests
{
    [TestClass]
    public class CirLockServiceTests
    {
        private static DatabaseGenerator _multibrandDatabase;
        private static ICirTosLockService _cirLockService;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _multibrandDatabase = new DatabaseGenerator();

            var inspecToolsServiceMock = new Mock<IInspecToolsIntegrationService>();

            _cirLockService = new CirTosLockService(_multibrandDatabase.CirSubmissionDataDynamicRepository,
                _multibrandDatabase.CirTemplateRepository, inspecToolsServiceMock.Object);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _multibrandDatabase.Dispose();
        }

        private static CirSubmissionData GetCir()
        {
            var template = _multibrandDatabase.CirTemplateRepository.Get(_multibrandDatabase.AllTemplatesIds.First());

            return new CirSubmissionData
            {
                CirTemplateId = template.Id,
                CirCollectionName = template.CirBrandCollectionName,
                State = CirState.Draft,
                Schema = "test",
                Data = "test",
                CreatedOn = DateTime.Now,
                CreatedBy = "test",
                ModifiedOn = DateTime.Now,
                ModifiedBy = "test"
            };
        }

        [TestMethod]
        public void CirLockService_IsCirLocked_ShouldReturnFalse()
        {
            var cir = GetCir();
            _multibrandDatabase.CirSubmissionDataDynamicRepository.Add(cir, cir.CirCollectionName);
            cir = _multibrandDatabase.CirSubmissionDataDynamicRepository.GetByCirId(cir.CirId, cir.CirCollectionName);

            var isLocked = _cirLockService.IsCirLocked(cir.Id, cir.CirTemplateId);

            Assert.IsFalse(isLocked, "Not locked cir should have isLockedByTos set to false");
        }

        [TestMethod]
        public void CirLockService_IsCirLocked_AfterLocking_ShouldReturnTrue()
        {
            var cir = GetCir();
            _multibrandDatabase.CirSubmissionDataDynamicRepository.Add(cir, cir.CirCollectionName);
            cir = _multibrandDatabase.CirSubmissionDataDynamicRepository.GetByCirId(cir.CirId, cir.CirCollectionName);

            _cirLockService.LockCirByTos(cir.Id, cir.CirTemplateId, string.Empty);

            var isLocked = _cirLockService.IsCirLocked(cir.Id, cir.CirTemplateId);

            Assert.IsTrue(isLocked, "Locked cir should have isLockedByTos set to true");
        }

        [TestMethod]
        public void CirLockService_LockCirByTos_ReturnsLockedCir()
        {
            var cir = GetCir();
            _multibrandDatabase.CirSubmissionDataDynamicRepository.Add(cir, cir.CirCollectionName);
            cir = _multibrandDatabase.CirSubmissionDataDynamicRepository.GetByCirId(cir.CirId, cir.CirCollectionName);

            var lockedCir = _cirLockService.LockCirByTos(cir.Id, cir.CirTemplateId, string.Empty);

            Assert.IsTrue(lockedCir.IsLockedByTos, "Locked cir should have isLockedByTos set to true");
        }

        [TestMethod]
        public void CirLockService_LockCirByTos_GetCir_ReturnsLockedCir()
        {
            var cir = GetCir();
            _multibrandDatabase.CirSubmissionDataDynamicRepository.Add(cir, cir.CirCollectionName);
            cir = _multibrandDatabase.CirSubmissionDataDynamicRepository.GetByCirId(cir.CirId, cir.CirCollectionName);

            _cirLockService.LockCirByTos(cir.Id, cir.CirTemplateId, string.Empty);

            var lockedCir =
                _multibrandDatabase.CirSubmissionDataDynamicRepository.GetByCirId(cir.CirId, cir.CirCollectionName);

            Assert.IsTrue(lockedCir.IsLockedByTos, "Locked cir should have isLockedByTos set to true");
        }

        [TestMethod]
        public void CirLockService_UnlockCirByTos_IsCirLocked_ReturnsFalse()
        {
            var cir = GetCir();
            _multibrandDatabase.CirSubmissionDataDynamicRepository.Add(cir, cir.CirCollectionName);
            cir = _multibrandDatabase.CirSubmissionDataDynamicRepository.GetByCirId(cir.CirId, cir.CirCollectionName);

            var lockedCir = _cirLockService.LockCirByTos(cir.Id, cir.CirTemplateId, string.Empty);

            _cirLockService.UnlockCirByTos(lockedCir.Id, lockedCir.CirTemplateId, string.Empty);

            var isLocked = _cirLockService.IsCirLocked(lockedCir.Id, lockedCir.CirTemplateId);

            Assert.IsFalse(isLocked, "After unclocking CIR IsCirLocked should return false");
        }
    }
}
