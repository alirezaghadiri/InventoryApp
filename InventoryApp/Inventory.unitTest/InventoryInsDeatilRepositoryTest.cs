using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Principal;
namespace InventoryApp.Repositories.Tests
{

    [TestClass()]
    public class InventoryInsDeatilRepositoryTests
    {
        RepositortAbstracts.IInventoryInsDeatil _InventoryInsDeatil;
        Entities.InventoryInsDeatil EInventoryInsDeatil;
        public InventoryInsDeatilRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;
            _InventoryInsDeatil = new Repositories.InventoryInsDeatilRepository();
            EInventoryInsDeatil = new Entities.InventoryInsDeatil()
            {
                InventoryInsHeaderId = 1,
                ProductId = 1,
                Amount = 1,
            };
        }
        [TestMethod()]
        public void AddInventoryInsDeatilTest()
        {
            var result = _InventoryInsDeatil.Add(EInventoryInsDeatil);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void UpdateInventoryInsDeatilTest()
        {
           
            var result = _InventoryInsDeatil.Add(EInventoryInsDeatil);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void DeleteInventoryInsDeatilTest()
        {
            var result = _InventoryInsDeatil.Delete(EInventoryInsDeatil);
            Assert.AreEqual(false, result);
        }
    }
}
