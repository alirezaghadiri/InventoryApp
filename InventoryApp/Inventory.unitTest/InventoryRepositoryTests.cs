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
    public class InventoryRepositoryTests
    {
        RepositortAbstracts.IInventory inve;
        Entities.Inventory EInve;
        public InventoryRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;

            inve = new InventoryRepository();
            EInve = new Entities.Inventory()
            {
                CorporationId = 1,
                Title = "Title",
                Address = "Address",
                Telephone = "Telephone",
                Description = "Description",
            };
        }
        [TestMethod()]
        public void AddInventoryTest()
        {
            var result = inve.Add(EInve);
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void DeleteInventoryTest()
        {
            var result = inve.Delete(1);
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void UpdateInventoryTest()
        {
            EInve.InventoryId = 1;
            var result = inve.Update(EInve);
            Assert.AreEqual(true, result);
        }
    }
}