using InventoryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Repositories
{
    public class ProductParameterValueRepository : RepositortAbstracts.IProductParameterValue
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public ProductParameterValueRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(ProductParameterValue _ProductParameterValue)
        {
            try
            {
                contaxt.ProductParsmeterValues.Add(_ProductParameterValue);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(ProductParameterValue _ProductParameterValue)
        {
            try
            {
                var _contaxt = contaxt.ProductParsmeterValues.Where(p => p.ProductId == _ProductParameterValue.ProductId & p.ProductParameterId == _ProductParameterValue.ProductParameterId).FirstOrDefault();
                _contaxt.ProductId = _ProductParameterValue.ProductId;
                _contaxt.ProductParameterId = _ProductParameterValue.ProductParameterId;
                _contaxt.Value = _ProductParameterValue.Value;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int ProductId)
        {
            try
            {
                contaxt.ProductParsmeterValues.RemoveRange(contaxt.ProductParsmeterValues.Where(p => p.ProductId == ProductId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ICollection<ProductParameterValue> GetAll(int ProductId)
        {
            return contaxt.ProductParsmeterValues.Where(p => p.ProductId == ProductId).ToList();
        }
    }
}
