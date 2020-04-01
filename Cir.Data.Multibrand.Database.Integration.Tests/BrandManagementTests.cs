using Cir.Data.Access.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Cir.Data.Multibrand.Database.Integration.Tests
{
    [TestClass]
    public class BrandManagementTests
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
        public async Task AddBrandToUser()
        {
            var emailUser1 = MultibrandDatabase.EmailUser1;
            var brandIdToAdd = MultibrandDatabase.Guids[1];
            var cirBrandService = new CirBrandService(MultibrandDatabase.GroupUserBrandRepository, MultibrandDatabase.BrandDataRepository);
            var brandsBeforeAddition = await cirBrandService.GetAllByUserId(emailUser1);

            Assert.IsFalse(brandsBeforeAddition.Any(b => Equals(b.Id, brandIdToAdd)));

            //Test
            cirBrandService.AssignBrandToUserGroup(emailUser1, brandIdToAdd);

            var brandsAfterAddition = await cirBrandService.GetAllByUserId(emailUser1);

            Assert.IsTrue(brandsAfterAddition.Any(b => Equals(b.Id, brandIdToAdd)));
            Assert.IsTrue(brandsBeforeAddition.Count() + 1 == brandsAfterAddition.Count());
        }

        [TestMethod]
        public async Task AddBrandToGroup()
        {
            var testGroupName = MultibrandDatabase.TestGroupName;
            var brandIdToAdd = MultibrandDatabase.Guids[1];

            var cirBrandService = new CirBrandService(MultibrandDatabase.GroupUserBrandRepository, MultibrandDatabase.BrandDataRepository);
            var brandsBeforeAddition = await cirBrandService.GetAllByUserId(testGroupName);

            Assert.IsFalse(brandsBeforeAddition.Any(b => Equals(b.Id, brandIdToAdd)));

            //Test
            cirBrandService.AssignBrandToUserGroup(testGroupName, brandIdToAdd);

            var brandsAfterAddition = await cirBrandService.GetAllByUserId(testGroupName);

            Assert.IsTrue(brandsAfterAddition.Any(b => Equals(b.Id, brandIdToAdd)));
            Assert.IsTrue(brandsBeforeAddition.Count() + 1 == brandsAfterAddition.Count());
        }

        [TestMethod]
        public async Task RemoveBrandFromUser()
        {
            var emailUser1 = MultibrandDatabase.EmailUser1;
            var brandIdToRemove = MultibrandDatabase.Guids[0];
            var cirBrandService = new CirBrandService(MultibrandDatabase.GroupUserBrandRepository, MultibrandDatabase.BrandDataRepository);
            var brandsBeforeDeletion = await cirBrandService.GetAllByUserId(emailUser1);

            Assert.IsTrue(brandsBeforeDeletion.Any(b => Equals(b.Id, brandIdToRemove)));

            //Test
            cirBrandService.UnassignBrandFromUserGroup(emailUser1, brandIdToRemove);

            var brandsAfterDeletion = await cirBrandService.GetAllByUserId(emailUser1);

            Assert.IsFalse(brandsAfterDeletion.Any(b => Equals(b.Id, brandIdToRemove)));
            Assert.IsTrue(brandsBeforeDeletion.Count() == brandsAfterDeletion.Count() + 1);
        }

        [TestMethod]
        public async Task RemoveBrandFromGroup()
        {
            var testGroupName = MultibrandDatabase.TestGroupName;
            var brandIdToRemove = MultibrandDatabase.Guids[0];
            var cirBrandService = new CirBrandService(MultibrandDatabase.GroupUserBrandRepository, MultibrandDatabase.BrandDataRepository);
            var brandsBeforeDeletion = await cirBrandService.GetAllByUserId(testGroupName);

            Assert.IsTrue(brandsBeforeDeletion.Any(b => Equals(b.Id, brandIdToRemove)));

            //Test
            cirBrandService.UnassignBrandFromUserGroup(testGroupName, brandIdToRemove);

            var brandsAfterDeletion = await cirBrandService.GetAllByUserId(testGroupName);

            Assert.IsFalse(brandsAfterDeletion.Any(b => Equals(b.Id, brandIdToRemove)));
            Assert.IsTrue(brandsBeforeDeletion.Count() == brandsAfterDeletion.Count() + 1);
        }
    }
}
