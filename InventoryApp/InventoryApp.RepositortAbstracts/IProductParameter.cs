using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IProductParameter
    {
        bool Add(ProductParameter _ProductParameter);
        bool Update(ProductParameter _ProductParameter);
        bool Delete(int id);
        ProductParameter Find(int id);
        ICollection<ProductParameter> GetAll();
    }
}
