using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;

namespace InventoryApp.Repositories
{
    public class ProductUnitRepository : IProductUnit
    {
        DataLayer.InventoryDBContext contaxt ;
        public ProductUnitRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(ProductUnit unit)
        {
            try
            {
                unit.CreatedByUserId = DatabaseTools.GetUserID;
                unit.CreatedDate = DateTime.Now;
                unit.Deleted = false;
                contaxt.ProductUnits.Add(unit);
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
                var unit = contaxt.ProductUnits.FirstOrDefault(p => p.ProductUnitId == id);
                unit.Deleted = true;
                unit.DeletedByUserId = DatabaseTools.GetUserID;
                unit.DeletedDate = DateTime.Now;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return true;
            }
        }
        public ProductUnit Find(int id)
        {
            try
            {
                return contaxt.ProductUnits.FirstOrDefault(p => p.ProductUnitId == id);
            }
            catch
            {
                return null;
            }
        }

        public ICollection<ProductUnit> GetAll()
        {
            return contaxt.ProductUnits.Where(p => p.Deleted == false).ToList();
        }

        public ICollection<ProductUnit> Search(ProductUnitSearchType SearchType, string value)
        {
            List<ProductUnit> List = new List<ProductUnit>();
            switch (SearchType)
            {
                case ProductUnitSearchType.id:
                    {
                        int id = 0;
                        if (int.TryParse(value, out id))
                        {
                            var _unit = contaxt.ProductUnits.Where(p => p.ProductUnitId == id).ToList();
                            List.AddRange(_unit);
                        }
                        return List;
                    }

                case ProductUnitSearchType.title:
                    {
                        var _unit = contaxt.ProductUnits.Where(p => p.Title.Contains(value)).ToList();
                        List.AddRange(_unit);
                        return List;
                    }
                case ProductUnitSearchType.All:
                    {
                        var _unit = contaxt.ProductUnits.Where(p => p.Title.Contains(value)).ToList();
                        List.AddRange(_unit);
                        int id = 0;
                        if (int.TryParse(value, out id))
                        {
                            _unit = contaxt.ProductUnits.Where(p => p.ProductUnitId == id).ToList();
                            List.AddRange(_unit);
                        }

                        return List;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
        public bool Update(ProductUnit unit)
        {
            try
            {
                var _unit = contaxt.ProductUnits.FirstOrDefault(p => p.ProductUnitId == unit.ProductUnitId);
                _unit = unit;
                _unit.ChangedByUserId = DatabaseTools.GetUserID;
                _unit.ChangedDate = DateTime.Now;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return true;
            }
        }

    }
}
