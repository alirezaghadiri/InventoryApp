using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IUser
    {
        bool Add(User _User);
        bool Update(User _User);
        bool Delete(int id);
        User Find(int id);
        ICollection<User> GetAll();
    }
}
