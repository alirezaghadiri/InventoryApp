using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IRole
    {
        bool Add(Role _Role);
        bool Update(Role _Role);
        bool Delete(Role _Role);
        Role Find(int id);
        ICollection<Role> GetAll();
    }
}
