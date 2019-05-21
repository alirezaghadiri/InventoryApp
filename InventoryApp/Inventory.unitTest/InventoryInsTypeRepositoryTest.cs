using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Principal;
namespace InventoryApp.Repositories.Tests
{

    [TestClass()]
    public class InventoryInsTypeRepositoryTests
    {
        RepositortAbstracts.IInventoryInsType _InventoryInsType;
        Entities.InventoryInsType EInventoryInsType;
        public InventoryInsTypeRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;
            _InventoryInsType = new Repositories.InventoryInsTypeRepository();
            EInventoryInsType = new Entities.InventoryInsType()
            {
                Title = "Title",
                Description = "Description",
            };
        }
        [TestMethod()]
        public void AddInventoryInsTypeTest()
        {
            var result = _InventoryInsType.Add(EInventoryInsType);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void UpdateInventoryInsTypeTest()
        {
            EInventoryInsType.InventoryInsTypeId = 1;
            var result = _InventoryInsType.Add(EInventoryInsType);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void DeleteInventoryInsTypeTest()
        {
            var result = _InventoryInsType.Delete(2);
            Assert.AreEqual(true, result);
        }
    }
}
