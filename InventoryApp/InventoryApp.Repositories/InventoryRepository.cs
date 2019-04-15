using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

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
                contaxt.Inventories
                .Add(_Inventory);
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
                var _contaxt = contaxt.Inventories
                .Where(p => p.InventoryId == id).FirstOrDefault();
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
                var _contaxt = contaxt.Inventories
                .Where(p => p.InventoryId == _Inventory.InventoryId).FirstOrDefault();
                _contaxt = _Inventory;
                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = DatabaseTools.GetUserID; contaxt.SaveChanges();
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
    }
}
