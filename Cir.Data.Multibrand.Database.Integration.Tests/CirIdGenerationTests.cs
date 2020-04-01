using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cir.Data.Multibrand.Database.Integration.Tests
{
    [TestClass]
    public class CirIdGenerationTests
    {
        private static DatabaseGenerator _multibrandDatabase;
        private static string _collectionName = "AnyCollection";

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _multibrandDatabase = new DatabaseGenerator();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            //_multibrandDatabase.Dispose();
        }

        [TestMethod]
        public void CirId_AreNotEqual()
        {
            var cirId = _multibrandDatabase.CirIdRepository.GetCirId(_collectionName);
            var incrementedCirId = _multibrandDatabase.CirIdRepository.GetCirId(_collectionName);

            Assert.AreNotEqual(cirId.CirId, incrementedCirId.CirId, "Generated CirIds cannot be equal.");
        }

        [TestMethod]
        public void CirId_AreIncremented()
        {
            var cirId = _multibrandDatabase.CirIdRepository.GetCirId(_collectionName);
            var secondCirId = _multibrandDatabase.CirIdRepository.GetCirId(_collectionName);
            var thirdCirId = _multibrandDatabase.CirIdRepository.GetCirId(_collectionName);

            Assert.AreEqual(cirId.CirId + 1, secondCirId.CirId, "First call to get CirId should return CirId incremented by one.");
            Assert.AreEqual(secondCirId.CirId + 1, thirdCirId.CirId, "Second call to get CirId should return CirId incremented by two.");
        }
    }
}
