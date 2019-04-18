using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class InventoryInsHeaderRepository : IInventoryInsHeader
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public InventoryInsHeaderRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(InventoryInsHeader _InventoryInsHeader)
        {
            try
            {
                _InventoryInsHeader.CreatedDate = DateTime.Now;
                _InventoryInsHeader.Accepted = false;
                _InventoryInsHeader.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.InventoryInsHeaders.Add(_InventoryInsHeader);
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
                var _contaxt = contaxt.InventoryInsHeaders
                .Where(p => p.InventoryInsHeaderId == id).FirstOrDefault();
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
        public InventoryInsHeader Find(int id)
        {
            try
            {
                return contaxt.InventoryInsHeaders
                .Where(p => p.InventoryInsHeaderId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(InventoryInsHeader _InventoryInsHeader)
        {
            try
            {
                var _contaxt = contaxt.InventoryInsHeaders
                .Where(p => p.InventoryInsHeaderId == _InventoryInsHeader.InventoryInsHeaderId).FirstOrDefault();

                _contaxt.InventoryInsHeaderId = _InventoryInsHeader.InventoryInsHeaderId;
                _contaxt.InventoryId = _InventoryInsHeader.InventoryId;
                _contaxt.TypeId = _InventoryInsHeader.TypeId;
                _contaxt.Title = _InventoryInsHeader.Title;
                _contaxt.Description = _InventoryInsHeader.Description;
                _contaxt.Date = _InventoryInsHeader.Date;

                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = DatabaseTools.GetUserID; contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<InventoryInsHeader> GetAll()
        {
            return contaxt.InventoryInsHeaders
            .Where(p => p.Deleted == false).ToList();
        }

        public int AddReturnId(InventoryInsHeader _InventoryInsHeader)
        {
            try
            {
                _InventoryInsHeader.CreatedDate = DateTime.Now;
                _InventoryInsHeader.Accepted = false;
                _InventoryInsHeader.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.InventoryInsHeaders.Add(_InventoryInsHeader);
                contaxt.SaveChanges();
                return _InventoryInsHeader.InventoryInsHeaderId;
            }
            catch
            {
                return 0;
            }
        }
    }
}
