using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Principal;
namespace InventoryApp.Repositories.Tests
{

    [TestClass()]
    public class ProductParameterValueRepositoryTests
    {
        RepositortAbstracts.IProductParameterValue _ProductParameterValue;
        Entities.ProductParameterValue EProductParameterValue;
        public ProductParameterValueRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;
            _ProductParameterValue = new Repositories.ProductParameterValueRepository();
            EProductParameterValue = new Entities.ProductParameterValue()
            {
                ProductId = 1,
                ProductParameterId = 1,
                Value = "Value",
            };
        }
        [TestMethod()]
        public void AddProductParameterValueTest()
        {
            var result = _ProductParameterValue.Add(EProductParameterValue);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void UpdateProductParameterValueTest()
        {
            var result = _ProductParameterValue.Add(EProductParameterValue);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void DeleteProductParameterValueTest()
        {
            var result = _ProductParameterValue.Delete(2);
            Assert.AreEqual(true, result);
        }
    }
}
