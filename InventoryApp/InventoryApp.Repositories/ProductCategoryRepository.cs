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
                contaxt.ProductCategorys.Add(_ProductCategory);
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
                return contaxt.ProductCategorys.First(p => p.Deleted == false & p.ProductCategoryId == id);
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

                _contaxt.ProductCategoryId = _contaxt.ProductCategoryId;
                _contaxt.SubProductCategoryID = _contaxt.SubProductCategoryID;
                _contaxt.InventoryId = _contaxt.InventoryId;
                _contaxt.Title = _contaxt.Title;
                _contaxt.Description = _contaxt.Description;
                _contaxt.Capacity = _contaxt.Capacity;

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
        public ICollection<ProductCategory> GetAll()
        {
            return contaxt.ProductCategorys.Where(p => p.Deleted == false).ToList();
        }

        public ICollection<ProductCategory> GetByParent(int id = 0)
        {
            return contaxt.ProductCategorys.Where(p => p.Deleted == false & p.SubProductCategoryID == id).ToList();
        }

        public int CanDelete(int Id)
        {
            var count = contaxt.Products.Where(p => p.Deleted == false & p.ProductCategoryId == Id).Count();
            count += contaxt.ProductParameters.Where(p => p.Deleted == false & p.ProductCategoryId == Id).Count();
            return count;
        }

        public ICollection<ProductCategory> GetByInventory(int id)
        {
            return contaxt.ProductCategorys.Where(p => p.Deleted == false & p.InventoryId == id).ToList();
        }
    }
}
