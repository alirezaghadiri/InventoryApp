using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IInventoryInsDeatil
    {
        bool Add(InventoryInsDeatil _InventoryInsDeatil);
        bool Update(InventoryInsDeatil _InventoryInsDeatil);
        bool Delete(InventoryInsDeatil _InventoryInsDeatil);
        ICollection<InventoryInsDeatil> GetAll();
        decimal GetAmount(int ProductId);
    }
}
