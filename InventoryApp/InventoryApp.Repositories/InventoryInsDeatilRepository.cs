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
        public bool Delete(InventoryInsDeatil _InventoryInsDeatil)
        {
            try
            {
                var _contaxt = contaxt.InventoryInsDeatils.Remove(_InventoryInsDeatil);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(InventoryInsDeatil _InventoryInsDeatil)
        {
            try
            {
                var _contaxt = contaxt.InventoryInsDeatils.First(p => p.InventoryInsHeaderId == _InventoryInsDeatil.InventoryInsHeaderId & p.ProductId == _InventoryInsDeatil.ProductId);
                _contaxt.Amount = _InventoryInsDeatil.Amount;
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

        public object GetAmount(int ProductId)
        {
            try
            {
                decimal Count = 0;
                foreach (var item in contaxt.InventoryInsDeatils.Where(p => p.ProductId == ProductId).ToList())
                    if (contaxt.InventoryInsHeaders.First(p => p.InventoryInsHeaderId == item.InventoryInsHeaderId & p.Accepted == true) != null)
                        Count += item.Amount;
                return Count;
            }
            catch
            {
                return null;
            }


        }
    }
}
