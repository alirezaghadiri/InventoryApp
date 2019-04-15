using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class ProductCategoryRepository : IProductCategory
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public ProductCategoryRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(ProductCategory _ProductCategory)
        {
            try
            {
                _ProductCategory.CreatedDate = DateTime.Now;
                _ProductCategory.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.ProductCategorys
                .Add(_ProductCategory);
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
                var _contaxt = contaxt.ProductCategorys
                .Where(p => p.ProductCategoryId == id).FirstOrDefault();
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
        public ProductCategory Find(int id)
        {
            try
            {
                return contaxt.ProductCategorys
                .Where(p => p.ProductCategoryId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(ProductCategory _ProductCategory)
        {
            try
            {
                var _contaxt = contaxt.ProductCategorys
                .Where(p => p.ProductCategoryId == _ProductCategory.ProductCategoryId).FirstOrDefault();
                _contaxt = _ProductCategory;
                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = DatabaseTools.GetUserID; contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<ProductCategory> GetAll()
        {
            return contaxt.ProductCategorys
            .Where(p => p.Deleted == false).ToList();
        }
    }
}
