using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IInventoryOutsDeatil
    {
        bool Add(InventoryOutsDeatil _InventoryOutsDeatil);
        bool Update(InventoryOutsDeatil _InventoryOutsDeatil);
        bool Delete(int id);
        InventoryOutsDeatil Find(int id);
        ICollection<InventoryOutsDeatil> GetAll();
    }
}
