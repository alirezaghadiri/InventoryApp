using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IInventoryOutsHeader
    {
        bool Add(InventoryOutsHeader _InventoryOutsHeader);
        int AddReturnId(InventoryOutsHeader _InventoryOutsHeader);
        bool Update(InventoryOutsHeader _InventoryOutsHeader);
        bool Delete(int id);
        InventoryOutsHeader Find(int id);
        ICollection<InventoryOutsHeader> GetAll();
    }
}
