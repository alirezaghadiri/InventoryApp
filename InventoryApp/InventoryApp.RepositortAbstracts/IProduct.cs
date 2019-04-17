using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IProduct
    {
        bool Add(Product _Product);
        bool Update(Product _Product);
        bool Delete(int id);
        Product Find(int id);
        ICollection<Product> GetAll(int PoroductCategoryId=0);
        int CanDelete(int Id);
        decimal Capacity(int CategoryId);
    }
}
