using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IInventoryOutsDeatil
    {
        bool Add(InventoryOutsDeatil _InventoryOutsDeatil);
        bool Update(InventoryOutsDeatil _InventoryOutsDeatil);
        bool Delete(InventoryOutsDeatil _InventoryOutsDeatil);
        ICollection<InventoryOutsDeatil> GetAll();
        object GetAmount(int ProductId);
    }
}
