using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class ProductParameterRepository : IProductParameter
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public ProductParameterRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(ProductParameter _ProductParameter)
        {
            try
            {
                _ProductParameter.CreatedDate = DateTime.Now;
                _ProductParameter.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.ProductParameters
                .Add(_ProductParameter);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var _contaxt = contaxt.ProductParameters
                .Where(p => p.ProductParameterId == id).FirstOrDefault();
                _contaxt.Deleted = true;
                _contaxt.DeletedDate = DateTime.Now;
                _contaxt.DeletedByUserId = DatabaseTools.GetUserID;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ProductParameter Find(int id)
        {
            try
            {
                return contaxt.ProductParameters
                .Where(p => p.ProductParameterId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(ProductParameter _ProductParameter)
        {
            try
            {
                var _contaxt = contaxt.ProductParameters
                .Where(p => p.ProductParameterId == _ProductParameter.ProductParameterId).FirstOrDefault();
                _contaxt = _ProductParameter;
                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = DatabaseTools.GetUserID; contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<ProductParameter> GetAll()
        {
            return contaxt.ProductParameters
            .Where(p => p.Deleted == false).ToList();
        }
    }
}
