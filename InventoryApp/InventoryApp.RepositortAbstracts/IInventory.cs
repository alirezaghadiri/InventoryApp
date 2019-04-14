using InventoryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.RepositortAbstracts
{
    public interface IInventory
    {
        bool Add(Inventory inventory);
        bool Update(Inventory inventory);
        bool Delete(int id);
        Inventory Find(int id);
        ICollection<Inventory> GetAll();
        ICollection<Inventory> Search(InventorySearchType SearchType, string value);
    }
    public enum InventorySearchType
    {
        All = 0,
        inventoryId = 1,
        Address = 2,
        Telephone = 3,
        title=4
    }

}
