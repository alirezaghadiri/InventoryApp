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
                _contaxt.InventoryOutsHeaderId = _InventoryOutsHeader.InventoryOutsHeaderId;
                _contaxt.InventoryId = _InventoryOutsHeader.InventoryId;
                _contaxt.TypeId = _InventoryOutsHeader.TypeId;
                _contaxt.Title = _InventoryOutsHeader.Title;
                _contaxt.Description = _InventoryOutsHeader.Description;
                _contaxt.Date = _InventoryOutsHeader.Date;
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
        public ICollection<InventoryOutsHeader> GetAll(bool IsAccept = true)
        {
            return contaxt.InventoryOutsHeaders.Where(p => p.Deleted == false & p.Accepted==IsAccept).ToList();
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

        public bool Accept(int id)
        {
            try
            {
                var _contaxt = contaxt.InventoryOutsHeaders.Where(p => p.InventoryOutsHeaderId == id).FirstOrDefault();
                _contaxt.Accepted = true;
                _contaxt.AcceptedDate = DateTime.Now;
                _contaxt.AcceptedByUserId = DatabaseTools.GetUserID; contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
