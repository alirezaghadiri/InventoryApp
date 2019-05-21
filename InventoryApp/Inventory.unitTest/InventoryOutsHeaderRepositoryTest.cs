using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Principal;
namespace InventoryApp.Repositories.Tests
{

    [TestClass()]
    public class InventoryOutsHeaderRepositoryTests
    {
        RepositortAbstracts.IInventoryOutsHeader _InventoryOutsHeader;
        Entities.InventoryOutsHeader EInventoryOutsHeader;
        public InventoryOutsHeaderRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;
            _InventoryOutsHeader = new Repositories.InventoryOutsHeaderRepository();
            EInventoryOutsHeader = new Entities.InventoryOutsHeader()
            {
                InventoryId = 1,
                TypeId = 1,
                Title = "Title",
                Description = "Description",
            };
        }
        [TestMethod()]
        public void AddInventoryOutsHeaderTest()
        {
            var result = _InventoryOutsHeader.Add(EInventoryOutsHeader);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void UpdateInventoryOutsHeaderTest()
        {
            EInventoryOutsHeader.InventoryOutsHeaderId = 1;
            var result = _InventoryOutsHeader.Add(EInventoryOutsHeader);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void DeleteInventoryOutsHeaderTest()
        {
            var result = _InventoryOutsHeader.Delete(2);
            Assert.AreEqual(false, result);
        }
    }
}
