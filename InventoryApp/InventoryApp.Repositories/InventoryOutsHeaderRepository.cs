using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class InventoryOutsHeaderRepository : IInventoryOutsHeader
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public InventoryOutsHeaderRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(InventoryOutsHeader _InventoryOutsHeader)
        {
            try
            {
                _InventoryOutsHeader.CreatedDate = DateTime.Now;
                _InventoryOutsHeader.Accepted = false;
                _InventoryOutsHeader.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.InventoryOutsHeaders
                .Add(_InventoryOutsHeader);
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
                var _contaxt = contaxt.InventoryOutsHeaders
                .Where(p => p.InventoryOutsHeaderId == id).FirstOrDefault();
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
        public InventoryOutsHeader Find(int id)
        {
            try
            {
                return contaxt.InventoryOutsHeaders
                .Where(p => p.InventoryOutsHeaderId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(InventoryOutsHeader _InventoryOutsHeader)
        {
            try
            {
                var _contaxt = contaxt.InventoryOutsHeaders
                .Where(p => p.InventoryOutsHeaderId == _InventoryOutsHeader.InventoryOutsHeaderId).FirstOrDefault();
                _contaxt = _InventoryOutsHeader;
                _contaxt.ChangedDate = DateTime.Now;
                _contaxt.ChangedByUserId = DatabaseTools.GetUserID; contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<InventoryOutsHeader> GetAll()
        {
            return contaxt.InventoryOutsHeaders
            .Where(p => p.Deleted == false).ToList();
        }

        public int AddReturnId(InventoryOutsHeader _InventoryOutsHeader)
        {
            try
            {
                _InventoryOutsHeader.CreatedDate = DateTime.Now;
                _InventoryOutsHeader.Accepted = false;
                _InventoryOutsHeader.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.InventoryOutsHeaders.Add(_InventoryOutsHeader);
                contaxt.SaveChanges();
                return _InventoryOutsHeader.InventoryOutsHeaderId;
            }
            catch
            {
                return 0;
            }
        }
    }
}
