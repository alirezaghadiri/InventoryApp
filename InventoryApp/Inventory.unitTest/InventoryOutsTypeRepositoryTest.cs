using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Principal;
namespace InventoryApp.Repositories.Tests
{

    [TestClass()]
    public class InventoryOutsTypeRepositoryTests
    {
        RepositortAbstracts.IInventoryOutsType _InventoryOutsType;
        Entities.InventoryOutsType EInventoryOutsType;
        public InventoryOutsTypeRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;
            _InventoryOutsType = new Repositories.InventoryOutsTypeRepository();
            EInventoryOutsType = new Entities.InventoryOutsType()
            {
                Title = "Title",
                Description = "Description",
            };
        }
        [TestMethod()]
        public void AddInventoryOutsTypeTest()
        {
            var result = _InventoryOutsType.Add(EInventoryOutsType);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void UpdateInventoryOutsTypeTest()
        {
            EInventoryOutsType.InventoryOutsTypeId = 1;
            var result = _InventoryOutsType.Add(EInventoryOutsType);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void DeleteInventoryOutsTypeTest()
        {
            var result = _InventoryOutsType.Delete(2);
            Assert.AreEqual(true, result);
        }
    }
}
