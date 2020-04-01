using Cir.Data.Access.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cir.Data.Multibrand.Database.Integration.Tests
{
    [TestClass]
    public class HotlistTests
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
        public void GetHotlist()
        {
            var hotlistService = new HotlistService(MultibrandDatabase.HotlistRepository, MultibrandDatabase.GroupUserBrandRepository);
            var id = MultibrandDatabase.Hotlists.First().Id;
            var hotItemId = MultibrandDatabase.Hotlists.First().HotItemId;

            //Test
            var hotlist = hotlistService.Get(id);

            Assert.IsTrue(hotlist.HotItemId == hotItemId);
        }

        [TestMethod]
        public void GetAllHotlist()
        {
            var hotlistService = new HotlistService(MultibrandDatabase.HotlistRepository, MultibrandDatabase.GroupUserBrandRepository);
            
            //Test
            var hotlists = hotlistService.GetAll();

            Assert.IsTrue(hotlists.Count() == MultibrandDatabase.Hotlists.Count());
        }

        [TestMethod]
        public void AddHotlist()
        {
            var hotlistToAdd = MultibrandDatabase.HotlistDataModelTestExample;
            var hotlistService = new HotlistService(MultibrandDatabase.HotlistRepository, MultibrandDatabase.GroupUserBrandRepository);
            var hotlistsBeforeAddition = hotlistService.GetAll();

            Assert.IsFalse(hotlistsBeforeAddition.Any(hotlist => Equals(hotlist.Id, hotlistToAdd.Id)));

            //Test
            hotlistService.Add(hotlistToAdd);

            var hotlistsAfterAddition = hotlistService.GetAll();

            Assert.IsTrue(hotlistsAfterAddition.Any(hotlist => Equals(hotlist.Id, hotlistToAdd.Id)));
            Assert.IsTrue(hotlistsBeforeAddition.Count() + 1 == hotlistsAfterAddition.Count());
        }

        [TestMethod]
        public void DeleteHotlist()
        {
            var hotlistService = new HotlistService(MultibrandDatabase.HotlistRepository, MultibrandDatabase.GroupUserBrandRepository);
            var hotlistToDelete = MultibrandDatabase.HotlistDataModelTestExample;
            var hotlistsBeforeDeletion = hotlistService.GetAll();

            if(!hotlistsBeforeDeletion.Any(hotlist => hotlist.Id == hotlistToDelete.Id))
            {
                hotlistService.Add(hotlistToDelete);
                hotlistsBeforeDeletion = hotlistService.GetAll();
            }

            hotlistService.Delete(hotlistToDelete.Id);

            var hotlistsAfterDeletion = hotlistService.GetAll();

            Assert.IsFalse(hotlistsAfterDeletion.Any(hotlist => Equals(hotlist.Id, hotlistToDelete.Id)));
            Assert.IsTrue(hotlistsBeforeDeletion.Count() == hotlistsAfterDeletion.Count() + 1);
        }

        [TestMethod]
        public void DeleteHotlistByHotItemId()
        {
            var hotlistService = new HotlistService(MultibrandDatabase.HotlistRepository, MultibrandDatabase.GroupUserBrandRepository);
            var hotlistToDelete = MultibrandDatabase.HotlistDataModelTestExample;
            var hotlistsBeforeDeletion = hotlistService.GetAll();

            if (!hotlistsBeforeDeletion.Any(hotlist => hotlist.Id == hotlistToDelete.Id))
            {
                hotlistService.Add(hotlistToDelete);
                hotlistsBeforeDeletion = hotlistService.GetAll();
            }

            hotlistService.DeleteByHotItemId(hotlistToDelete.HotItemId);

            var hotlistsAfterDeletion = hotlistService.GetAll();

            Assert.IsFalse(hotlistsAfterDeletion.Any(hotlist => Equals(hotlist.Id, hotlistToDelete.Id)));
            Assert.IsTrue(hotlistsBeforeDeletion.Count() == hotlistsAfterDeletion.Count() + 1);
        }

        [TestMethod]
        public void GetHotlistByHotItemId()
        {
            var hotlistService = new HotlistService(MultibrandDatabase.HotlistRepository, MultibrandDatabase.GroupUserBrandRepository);
            var id = MultibrandDatabase.Hotlists.First().Id;
            var hotItemId = MultibrandDatabase.Hotlists.First().HotItemId;

            //Test
            var hotlist = hotlistService.GetByHotItemId(hotItemId);

            Assert.IsTrue(hotlist.Id == id);
        }

        [TestMethod]
        public void UpdateHotlist()
        {
            var hotlistService = new HotlistService(MultibrandDatabase.HotlistRepository, MultibrandDatabase.GroupUserBrandRepository);
            var hotlistToUpdate = MultibrandDatabase.Hotlists.First();
            var hotItemIdToUpdatedValue = 123456;

            hotlistToUpdate.HotItemId = hotItemIdToUpdatedValue;

            //Test
            hotlistService.Update(hotlistToUpdate);

            var hotlistUpdated = hotlistService.Get(hotlistToUpdate.Id);

            Assert.IsTrue(hotlistUpdated.HotItemId == hotItemIdToUpdatedValue);
        }
    }
}
