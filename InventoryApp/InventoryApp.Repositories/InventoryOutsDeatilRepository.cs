using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class InventoryOutsDeatilRepository : IInventoryOutsDeatil
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public InventoryOutsDeatilRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(InventoryOutsDeatil _InventoryOutsDeatil)
        {
            try
            {
                contaxt.InventoryOutsDeatils.Add(_InventoryOutsDeatil);
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
                var _contaxt = contaxt.InventoryOutsDeatils.Remove(contaxt.InventoryOutsDeatils.Where(p => p.InventoryOutsDeatilId == id).FirstOrDefault());
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public InventoryOutsDeatil Find(int id)
        {
            try
            {
                return contaxt.InventoryOutsDeatils.Where(p => p.InventoryOutsDeatilId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(InventoryOutsDeatil _InventoryOutsDeatil)
        {
            try
            {
                var _contaxt = contaxt.InventoryOutsDeatils
                .Where(p => p.InventoryOutsDeatilId == _InventoryOutsDeatil.InventoryOutsDeatilId).FirstOrDefault();
                _contaxt = _InventoryOutsDeatil;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<InventoryOutsDeatil> GetAll()
        {
            return contaxt.InventoryOutsDeatils.ToList();
        }
    }
}
