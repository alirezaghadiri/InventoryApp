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
    public class CorporationRepositoryTests
    {
        RepositortAbstracts.ICorporation corp;
        Entities.Corporation ECorp;
        public CorporationRepositoryTests()
        {
            var contaxt = new DataLayer.InventoryDBContext();
            var relateduser = contaxt.Users.FirstOrDefault(u => u.Username.Equals("admin"));
            var identity = new GenericIdentity(relateduser.Username);
            var roles = relateduser.Roles.Select(p => p.Title).ToArray();
            var principal = new GenericPrincipal(identity, roles);
            System.Threading.Thread.CurrentPrincipal = principal;
            corp = new Repositories.CorporationRepository();
            ECorp = new Entities.Corporation()
            {
                Title = "Title",
                Address = "Address",
                Telephone = "Telephone",
                Description = "Description",
            };
        }


        [TestMethod()]
        public void AddCorporationTest()
        {
            var result = corp.Add(ECorp);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void UpdateCorporationTest()
        {
            ECorp.CorporationId = 3;
            var result = corp.Update(ECorp);
            Assert.AreEqual(true, result);
        }
        [TestMethod()]
        public void DeleteCorporationTest()
        {
            var result = corp.Delete(2);
            Assert.AreEqual(true, result);
        } 
    }
}