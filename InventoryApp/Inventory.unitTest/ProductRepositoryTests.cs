using Microsoft.VisualStudio.TestTools.UnitTesting;
using InventoryApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace InventoryApp.Repositories.Tests
{
    [TestClass()]
    public class ProductRepositoryTests
    {
        RepositortAbstracts.IProduct pro;
        Entities.Product Epro;
        public ProductRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;

            pro = new ProductRepository();
            Epro = new Entities.Product()
            {
                Title = "Title",
                Description = "Description",
                Code=1,
                ProductCategoryId=2,
                ProductUnitId=2
            };

        }
        [TestMethod()]
        public void AddProductTest()
        {
            var result = pro.Add(Epro);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void DeleteProductTest()
        {
            var result = pro.Delete(1);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void UpdateProductTest()
        {
            Epro.ProductId = 2;
            var result = pro.Update(Epro);
            Assert.AreEqual(false, result);
        }
    }
}