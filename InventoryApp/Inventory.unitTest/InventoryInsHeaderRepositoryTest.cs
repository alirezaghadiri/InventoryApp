using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Principal;
namespace InventoryApp.Repositories.Tests
{

    [TestClass()]
    public class InventoryInsHeaderRepositoryTests
    {
        RepositortAbstracts.IInventoryInsHeader _InventoryInsHeader;
        Entities.InventoryInsHeader EInventoryInsHeader;
        public InventoryInsHeaderRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;
            _InventoryInsHeader = new Repositories.InventoryInsHeaderRepository();
            EInventoryInsHeader = new Entities.InventoryInsHeader()
            {
                InventoryId = 1,
                TypeId = 1,
                Title = "Title",
                Description = "Description",
            };
        }
        [TestMethod()]
        public void AddInventoryInsHeaderTest()
        {
            var result = _InventoryInsHeader.Add(EInventoryInsHeader);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void UpdateInventoryInsHeaderTest()
        {
            EInventoryInsHeader.InventoryInsHeaderId = 1;
            var result = _InventoryInsHeader.Add(EInventoryInsHeader);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void DeleteInventoryInsHeaderTest()
        {
            var result = _InventoryInsHeader.Delete(2);
            Assert.AreEqual(false, result);
        }
    }
}
