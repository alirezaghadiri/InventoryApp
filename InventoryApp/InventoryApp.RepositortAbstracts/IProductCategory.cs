using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IProductCategory
    {
        bool Add(ProductCategory _ProductCategory);
        bool Update(ProductCategory _ProductCategory);
        bool Delete(int id);
        ProductCategory Find(int id);
        ICollection<ProductCategory> GetAll();
        ICollection<ProductCategory> GetByParent(int id=0);
        ICollection<ProductCategory> GetByInventory(int id );
        int CanDelete(int Id);
    }
}
