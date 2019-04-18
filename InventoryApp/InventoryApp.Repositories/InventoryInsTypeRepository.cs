using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class InventoryInsTypeRepository : IInventoryInsType
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public InventoryInsTypeRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(InventoryInsType _InventoryInsType)
        {
            try
            {
                _InventoryInsType.CreatedDate = DateTime.Now;
                _InventoryInsType.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.InventoryInsTypes
                .Add(_InventoryInsType);
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
                var _contaxt = contaxt.InventoryInsTypes
                .Where(p => p.InventoryInsTypeId == id).FirstOrDefault();
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
        public InventoryInsType Find(int id)
        {
            try
            {
                return contaxt.InventoryInsTypes
                .Where(p => p.InventoryInsTypeId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(InventoryInsType _InventoryInsType)
        {
            try
            {
                var _contaxt = contaxt.InventoryInsTypes
                .Where(p => p.InventoryInsTypeId == _InventoryInsType.InventoryInsTypeId).FirstOrDefault();
                _contaxt.InventoryInsTypeId = _InventoryInsType.InventoryInsTypeId;
                _contaxt.Title = _InventoryInsType.Title;
                _contaxt.Description = _InventoryInsType.Description;
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
        public ICollection<InventoryInsType> GetAll()
        {
            return contaxt.InventoryInsTypes
            .Where(p => p.Deleted == false).ToList();
        }

        public int CanDelete(int Id)
        {
            return contaxt.InventoryInsHeaders.Where(p => p.Deleted == false & p.TypeId == Id).Count();
        }
    }
}
