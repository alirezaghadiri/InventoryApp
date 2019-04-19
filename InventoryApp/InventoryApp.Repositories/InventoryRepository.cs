using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;
using System.Data.Entity;

namespace InventoryApp.Repositories
{
    public class InventoryRepository : IInventory
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public InventoryRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(Inventory _Inventory)
        {
            try
            {
                _Inventory.CreatedDate = DateTime.Now;
                _Inventory.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.Inventories.Add(_Inventory);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var _contaxt = contaxt.Inventories.First(p => p.InventoryId == id);
                _contaxt.Deleted = true;
                _contaxt.DeletedDate = DateTime.Now;
                _contaxt.DeletedByUserId = DatabaseTools.GetUserID;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Inventory Find(int id)
        {
            try
            {
                return contaxt.Inventories
                .Where(p => p.InventoryId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(Inventory _Inventory)
        {
            try
            {
                var _contaxt = contaxt.Inventories.Where(p => p.InventoryId == _Inventory.InventoryId).FirstOrDefault();
                _contaxt.CorporationId = _Inventory.CorporationId;
                _contaxt.Title = _Inventory.Title;
                _contaxt.Address = _Inventory.Address;
                _contaxt.Telephone = _Inventory.Telephone;
                _contaxt.Description = _Inventory.Description;
                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = DatabaseTools.GetUserID;
                contaxt.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public ICollection<Inventory> GetAll()
        {
            return contaxt.Inventories
            .Where(p => p.Deleted == false).ToList();
        }
        public int CanDelete(int ID)
        {
            var count = contaxt.ProductCategorys.Where(p => p.Deleted == false & p.InventoryId == ID).Count();
            count += contaxt.InventoryOutsHeaders.Where(p => p.Deleted == false & p.InventoryId == ID).Count();
            count += contaxt.InventoryInsHeaders.Where(p => p.Deleted == false & p.InventoryId == ID).Count();
            return count;
        }

    }
}
