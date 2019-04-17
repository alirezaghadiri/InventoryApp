using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class ProductRepository : IProduct
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public ProductRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(Product _Product)
        {
            try
            {
                _Product.CreatedDate = DateTime.Now;
                _Product.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.Products.Add(_Product);
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
                var _contaxt = contaxt.Products
                .Where(p => p.ProductId == id).FirstOrDefault();
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
        public Product Find(int id)
        {
            try
            {
                return contaxt.Products
                .Where(p => p.ProductId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(Product _Product)
        {
            try
            {
                var _contaxt = contaxt.Products
                .Where(p => p.ProductId == _Product.ProductId).FirstOrDefault();
                _contaxt = _Product;
                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = DatabaseTools.GetUserID; contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<Product> GetAll(int PoroductCategoryId = 0)
        {
            if (PoroductCategoryId == 0)
                return contaxt.Products.Where(p => p.Deleted == false).ToList();
            else
                return contaxt.Products.Where(p => p.Deleted == false & p.ProductCategoryId== PoroductCategoryId).ToList();
        }
        public int CanDelete(int Id)
        {
            var count = contaxt.InventoryInsDeatils.Where(p =>p.ProductId==Id).Count();
            count += contaxt.InventoryOutsDeatils.Where(p => p.ProductId == Id).Count();
            return count;
        }

        public decimal Capacity(int CategoryId)
        {
            return contaxt.ProductCategorys.First(p => p.ProductCategoryId == CategoryId).Capacity;
        }
    }
}
