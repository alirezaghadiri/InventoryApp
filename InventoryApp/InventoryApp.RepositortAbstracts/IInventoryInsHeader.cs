using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IInventoryInsHeader
    {
        bool Add(InventoryInsHeader _InventoryInsHeader);
        int AddReturnId(InventoryInsHeader _InventoryInsHeader);
        bool Update(InventoryInsHeader _InventoryInsHeader);
        bool Delete(int id);
        InventoryInsHeader Find(int id);
        ICollection<InventoryInsHeader> GetAll(bool IsAccept=true);
        bool Accept(int id);
        

    }
}
