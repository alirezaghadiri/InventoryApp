using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IInventoryInsType
    {
        bool Add(InventoryInsType _InventoryInsType);
        bool Update(InventoryInsType _InventoryInsType);
        bool Delete(int id);
        InventoryInsType Find(int id);
        ICollection<InventoryInsType> GetAll();
        int CanDelete(int Id);
    }
}
