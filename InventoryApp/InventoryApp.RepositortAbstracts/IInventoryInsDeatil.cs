using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IInventoryInsDeatil
    {
        bool Add(InventoryInsDeatil _InventoryInsDeatil);
        bool Update(InventoryInsDeatil _InventoryInsDeatil);
        bool Delete(int id);
        InventoryInsDeatil Find(int id);
        ICollection<InventoryInsDeatil> GetAll();
    }
}
