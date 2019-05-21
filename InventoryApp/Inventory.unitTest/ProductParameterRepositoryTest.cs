using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security.Principal;
namespace InventoryApp.Repositories.Tests
{

    [TestClass()]
    public class ProductParameterRepositoryTests
    {
        RepositortAbstracts.IProductParameter _ProductParameter;
        Entities.ProductParameter EProductParameter;
        public ProductParameterRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;
            _ProductParameter = new Repositories.ProductParameterRepository();
            EProductParameter = new Entities.ProductParameter()
            {
                ProductCategoryId = 1,
                Key = "Key",
                Title = "Title",
                Description = "Description",

            };
        }
        [TestMethod()]
        public void AddProductParameterTest()
        {
            var result = _ProductParameter.Add(EProductParameter);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void UpdateProductParameterTest()
        {
            EProductParameter.ProductParameterId = 1;
            var result = _ProductParameter.Add(EProductParameter);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void DeleteProductParameterTest()
        {
            var result = _ProductParameter.Delete(2);
            Assert.AreEqual(true, result);
        }
    }
}
