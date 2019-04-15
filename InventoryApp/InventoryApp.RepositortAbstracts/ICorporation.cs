using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface ICorporation
    {
        bool Add(Corporation _Corporation);
        bool Update(Corporation _Corporation);
        bool Delete(int id);
        Corporation Find(int id);
        ICollection<Corporation> GetAll();
        int CanDelete(int Id);
        
    }
}
