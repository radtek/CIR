using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cir.Data.Multibrand.Database.Integration.Tests
{
    [TestClass]
    public class DatabaseConsistencyTests
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
        //public void AreAllTemplatesWithMatchingBrandObjectAndCollectionName()
        //{
        //    var cirTemplateRepository = MultibrandDatabase.CirTemplateRepository;
        //    var allTemplatesIds = MultibrandDatabase.AllTemplatesIds;
        //   // var templates = cirTemplateRepository.GetTemplates(allTemplatesIds);

        //    templates.ForEach(template =>
        //        Assert.IsTrue(template.CirBrandCollectionName.Contains(template.CirBrand.Name)));
        //}
    }
}
