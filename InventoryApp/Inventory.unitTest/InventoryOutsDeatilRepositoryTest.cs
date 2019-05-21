using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Principal;
namespace InventoryApp.Repositories.Tests
{

    [TestClass()]
    public class InventoryOutsDeatilRepositoryTests
    {
        RepositortAbstracts.IInventoryOutsDeatil _InventoryOutsDeatil;
        Entities.InventoryOutsDeatil EInventoryOutsDeatil;
        public InventoryOutsDeatilRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;
            _InventoryOutsDeatil = new Repositories.InventoryOutsDeatilRepository();
            EInventoryOutsDeatil = new Entities.InventoryOutsDeatil()
            {
                InventoryOutsHeaderId = 1,
                ProductId = 1,
                Amount = 1,
            };
        }
        [TestMethod()]
        public void AddInventoryOutsDeatilTest()
        {
            var result = _InventoryOutsDeatil.Add(EInventoryOutsDeatil);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void UpdateInventoryOutsDeatilTest()
        {
            var result = _InventoryOutsDeatil.Add(EInventoryOutsDeatil);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void DeleteInventoryOutsDeatilTest()
        {
            var result = _InventoryOutsDeatil.Delete(EInventoryOutsDeatil);
            Assert.AreEqual(false, result);
        }
    }
}
