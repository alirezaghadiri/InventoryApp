using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface IProductParameterValue
    {
        bool Add(ProductParameterValue _ProductParameterValue);
        bool Update(ProductParameterValue _ProductParameterValue);
        ICollection<ProductParameterValue> GetAll(int ProductId);
        bool Delete(int ProductId);
    }
}
