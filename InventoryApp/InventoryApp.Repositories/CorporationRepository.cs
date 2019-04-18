using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class CorporationRepository : ICorporation
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public CorporationRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(Corporation _Corporation)
        {
            try
            {
                _Corporation.CreatedDate = DateTime.Now;
                _Corporation.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.Corporations
                .Add(_Corporation);
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
                var _contaxt = contaxt.Corporations
                .Where(p => p.CorporationId == id).FirstOrDefault();
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
        public Corporation Find(int id)
        {
            try
            {
                return contaxt.Corporations
                .Where(p => p.CorporationId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(Corporation _Corporation)
        {
            try
            {
                var _contaxt = contaxt.Corporations
                .Where(p => p.CorporationId == _Corporation.CorporationId).FirstOrDefault();
                _contaxt.Title = _Corporation.Title;
                _contaxt.Description = _Corporation.Description;
                _contaxt.Address = _contaxt.Address;
                _contaxt.Telephone = _Corporation.Telephone;
                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = DatabaseTools.GetUserID; contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<Corporation> GetAll()
        {
            return contaxt.Corporations
            .Where(p => p.Deleted == false).ToList();
        }

        public int CanDelete(int Id)
        {
            return contaxt.Inventories.Where(p => p.CorporationId == Id & p.Deleted == false).Count();
        }
    }
}
