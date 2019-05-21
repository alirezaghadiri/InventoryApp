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
    public class ProductCategoryRepositoryTests
    {
        RepositortAbstracts.IProductCategory procat;
        Entities.ProductCategory Eprocat;
        public  ProductCategoryRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;

            procat = new ProductCategoryRepository();
            Eprocat = new Entities.ProductCategory()
            {
                SubProductCategoryID=0,
                InventoryId=1,
                Title= "Title",
                Description= "Description",
                Capacity=1,
            };
        }

        [TestMethod()]
        public void AddProductCategoryTest()
        {
            var result = procat.Add(Eprocat);
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void DeleteProductCategoryTest()
        {
            var result = procat.Delete(1);
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void UpdateProductCategoryRepositoryTest()
        {
            Eprocat.ProductCategoryId = 1;
            var result = procat.Update(Eprocat);
            Assert.AreEqual(true, result);
        }
    }
}