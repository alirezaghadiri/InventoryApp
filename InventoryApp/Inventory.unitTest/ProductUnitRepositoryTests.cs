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
    public class ProductUnitRepositoryTests
    {
        RepositortAbstracts.IProductUnit ProUnit;
        Entities.ProductUnit EProunit;
        public ProductUnitRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;

            ProUnit = new Repositories.ProductUnitRepository();
            EProunit = new Entities.ProductUnit()
            {
                Title = "Title",
                Description = "Description",
            };
        }

        [TestMethod()]
        public void AddProductUnitTest()
        {
            var result = ProUnit.Add(EProunit);
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void DeleteProductUnitTest()
        {
            var result = ProUnit.Delete(1);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void UpdateProductUnitTest()
        {
            EProunit.ProductUnitId = 1;
            var result = ProUnit.Update(EProunit);
            Assert.AreEqual(true, result);
        }


    }
}