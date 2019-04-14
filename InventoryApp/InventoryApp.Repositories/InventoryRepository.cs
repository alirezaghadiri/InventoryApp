using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;

namespace InventoryApp.Repositories
{
    public class InventoryRepository : RepositortAbstracts.IInventory
    {
        DataLayer.InventoryDBContext contaxt;
        public InventoryRepository()
        {
             contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(Inventory inventory)
        {
            try
            {
                inventory.Deleted = false;
                inventory.CreatedByUserId = DatabaseTools.GetUserID;
                inventory.CreatedDate = DateTime.Now;
                contaxt.Inventories.Add(inventory);
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
                var inventory = contaxt.Inventories.FirstOrDefault(p => p.InventoryId == id);
                inventory.Deleted = true;
                inventory.DeletedByUserId = DatabaseTools.GetUserID;
                inventory.DeletedDate = DateTime.Now;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return true;
            }
        }

        public Inventory Find(int id)
        {
            try
            {
                return contaxt.Inventories.FirstOrDefault(p => p.InventoryId == id);
            }
            catch
            {
                return null;
            }
        }

        public ICollection<Inventory> GetAll()
        {
            return contaxt.Inventories.Where(p => p.Deleted == false).ToList();
        }

        public ICollection<Inventory> Search(InventorySearchType SearchType, string value)
        {
            List<Inventory> List = new List<Inventory>();
            switch (SearchType)
            {
                case InventorySearchType.All:
                    {
                        //search by address
                        var _Inventory = contaxt.Inventories.Where(p => p.Address.Contains(value)).ToList();
                        List.AddRange(_Inventory);

                        //search by title
                        _Inventory = contaxt.Inventories.Where(p => p.Title.Contains(value)).ToList();
                        List.AddRange(_Inventory);

                        //search by Telephone
                        _Inventory = contaxt.Inventories.Where(p => p.Telephone.Contains(value)).ToList();
                        List.AddRange(_Inventory);

                        //search by id
                        int id = 0;
                        if (int.TryParse(value, out id))
                        {
                            _Inventory = contaxt.Inventories.Where(p => p.InventoryId == id).ToList();
                            List.AddRange(_Inventory);
                        }
                        return List;
                    }
                case InventorySearchType.inventoryId:
                    {
                        //search by id
                        int id = 0;
                        if (int.TryParse(value, out id))
                        {
                            var _Inventory = contaxt.Inventories.Where(p => p.InventoryId == id).ToList();
                            List.AddRange(_Inventory);
                        }
                        return List;
                    }
                case InventorySearchType.title:
                    {
                        //search by title
                        var _Inventory = contaxt.Inventories.Where(p => p.Title.Contains(value)).ToList();
                        List.AddRange(_Inventory);
                        return List;
                    }
                case InventorySearchType.Address:
                    {
                        //search by address
                        var _Inventory = contaxt.Inventories.Where(p => p.Address.Contains(value)).ToList();
                        List.AddRange(_Inventory);
                        return List;
                    }
                case InventorySearchType.Telephone:
                    {
                        //search by Telephone
                        var _Inventory = contaxt.Inventories.Where(p => p.Telephone.Contains(value)).ToList();
                        List.AddRange(_Inventory);
                        return List;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public bool Update(Inventory inventory)
        {
            try
            {
                var _inventory = contaxt.Inventories.FirstOrDefault(p => p.InventoryId == inventory.InventoryId);
                _inventory = inventory;
                _inventory.ChangedDate = DateTime.Now;
                _inventory.ChangedByUserId = DatabaseTools.GetUserID;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return true;
            }
        }
    }
}
