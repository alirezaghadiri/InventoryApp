using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class InventoryInsDeatilRepository : IInventoryInsDeatil
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public InventoryInsDeatilRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(InventoryInsDeatil _InventoryInsDeatil)
        {
            try
            {
                contaxt.InventoryInsDeatils.Add(_InventoryInsDeatil);
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
                var _contaxt = contaxt.InventoryInsDeatils.Remove(contaxt.InventoryInsDeatils.Where(p => p.InventoryInsDeatilId == id).FirstOrDefault());
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public InventoryInsDeatil Find(int id)
        {
            try
            {
                return contaxt.InventoryInsDeatils.Where(p => p.InventoryInsDeatilId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(InventoryInsDeatil _InventoryInsDeatil)
        {
            try
            {
                var _contaxt = contaxt.InventoryInsDeatils.Where(p => p.InventoryInsDeatilId == _InventoryInsDeatil.InventoryInsDeatilId).FirstOrDefault();
                _contaxt = _InventoryInsDeatil;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<InventoryInsDeatil> GetAll()
        {
            return contaxt.InventoryInsDeatils.ToList();
        }
    }
}
