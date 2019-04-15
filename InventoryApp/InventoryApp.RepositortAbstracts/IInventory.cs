using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IInventory
    {
        bool Add(Inventory _Inventory);
        bool Update(Inventory _Inventory);
        bool Delete(int id);
        Inventory Find(int id);
        ICollection<Inventory> GetAll();
    }
}
