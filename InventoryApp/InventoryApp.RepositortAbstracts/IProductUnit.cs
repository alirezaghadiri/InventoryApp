using System.Collections.Generic;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IProductUnit
    {
        bool Add(ProductUnit _ProductUnit);
        bool Update(ProductUnit _ProductUnit);
        bool Delete(int id);
        ProductUnit Find(int id);
        ICollection<ProductUnit> GetAll();
    }
}
