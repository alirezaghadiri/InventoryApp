using InventoryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.RepositortAbstracts
{
    public interface IProductUnit
    {
        bool Add(ProductUnit unit);
        bool Delete(int id);
        bool Update(ProductUnit unit);
        ProductUnit Find(int id);
        ICollection<ProductUnit> GetAll();
        ICollection<ProductUnit> Search(ProductUnitSearchType SearchType, string value);
    }
    public enum ProductUnitSearchType
    {
        All = 0,
        id = 1,
        title = 2,
        
    }
}
