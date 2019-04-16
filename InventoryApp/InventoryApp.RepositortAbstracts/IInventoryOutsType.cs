using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IInventoryOutsType
    {
        bool Add(InventoryOutsType _InventoryOutsType);
        bool Update(InventoryOutsType _InventoryOutsType);
        bool Delete(int id);
        InventoryOutsType Find(int id);
        ICollection<InventoryOutsType> GetAll();
        int CanDelete(int Id);
    }
}
