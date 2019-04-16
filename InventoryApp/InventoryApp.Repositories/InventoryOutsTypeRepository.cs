using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class InventoryOutsTypeRepository : IInventoryOutsType
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public InventoryOutsTypeRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(InventoryOutsType _InventoryOutsType)
        {
            try
            {
                _InventoryOutsType.CreatedDate = DateTime.Now;
                _InventoryOutsType.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.InventoryOutsTypes
                .Add(_InventoryOutsType);
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
                var _contaxt = contaxt.InventoryOutsTypes
                .Where(p => p.InventoryOutsTypeId == id).FirstOrDefault();
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
        public InventoryOutsType Find(int id)
        {
            try
            {
                return contaxt.InventoryOutsTypes
                .Where(p => p.InventoryOutsTypeId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(InventoryOutsType _InventoryOutsType)
        {
            try
            {
                var _contaxt = contaxt.InventoryOutsTypes
                .Where(p => p.InventoryOutsTypeId == _InventoryOutsType.InventoryOutsTypeId).FirstOrDefault();
                _contaxt = _InventoryOutsType;
                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = DatabaseTools.GetUserID; contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<InventoryOutsType> GetAll()
        {
            return contaxt.InventoryOutsTypes
            .Where(p => p.Deleted == false).ToList();
        }
    }
}