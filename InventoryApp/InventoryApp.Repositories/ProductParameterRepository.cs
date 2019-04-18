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
            catch (Exception ex)
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
           
                _contaxt.ProductParameterId = _ProductParameter.ProductParameterId;
                _contaxt.ProductCategoryId = _ProductParameter.ProductCategoryId;
                _contaxt.Key = _ProductParameter.Key;
                _contaxt.Title = _ProductParameter.Title;
                _contaxt.Description = _ProductParameter.Description;

                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = DatabaseTools.GetUserID;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<ProductParameter> GetAll(int ProductCategoryId = 0)
        {
            if (ProductCategoryId == 0)
            {
                return contaxt.ProductParameters.Where(p => p.Deleted == false).ToList();
            }
            else
            {
                return contaxt.ProductParameters.Where(p => p.Deleted == false & p.ProductCategoryId == ProductCategoryId).ToList();
            }

        }

        public int CanDelete(int Id)
        {
            return contaxt.ProductParsmeterValues.Where(p => p.ProductParameterId == Id).Count();
        }
    }
}
