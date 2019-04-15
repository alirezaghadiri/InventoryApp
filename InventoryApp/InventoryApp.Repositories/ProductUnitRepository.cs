using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class ProductUnitRepository : IProductUnit
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public ProductUnitRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(ProductUnit _ProductUnit)
        {
            try
            {
                _ProductUnit.CreatedDate = DateTime.Now;
                _ProductUnit.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.ProductUnits
                .Add(_ProductUnit);
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
                var _contaxt = contaxt.ProductUnits
                .Where(p => p.ProductUnitId == id).FirstOrDefault();
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
        public ProductUnit Find(int id)
        {
            try
            {
                return contaxt.ProductUnits
                .Where(p => p.ProductUnitId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(ProductUnit _ProductUnit)
        {
            try
            {
                var _contaxt = contaxt.ProductUnits
                .Where(p => p.ProductUnitId == _ProductUnit.ProductUnitId).FirstOrDefault();
                _contaxt = _ProductUnit;
                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = DatabaseTools.GetUserID; contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<ProductUnit> GetAll()
        {
            return contaxt.ProductUnits
            .Where(p => p.Deleted == false).ToList();
        }

        public int CanDelete(int id)
        {
            return contaxt.Products.Where(p => p.Deleted == false & p.ProductUnitId == id).Count();
        }
    }
}
