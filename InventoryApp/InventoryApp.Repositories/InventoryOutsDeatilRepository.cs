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
        public bool Delete(InventoryOutsDeatil _InventoryOutsDeatil)
        {
            try
            {
                var _contaxt = contaxt.InventoryOutsDeatils.Remove(_InventoryOutsDeatil);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(InventoryOutsDeatil _InventoryOutsDeatil)
        {
            try
            {
                var _contaxt = contaxt.InventoryOutsDeatils.First(
                     p => p.InventoryOutsHeaderId == _InventoryOutsDeatil.InventoryOutsHeaderId & p.ProductId == _InventoryOutsDeatil.ProductId);
                _contaxt.InventoryOutsHeaderId = _InventoryOutsDeatil.InventoryOutsHeaderId;
                _contaxt.ProductId = _InventoryOutsDeatil.ProductId;
                _contaxt.Amount = _InventoryOutsDeatil.Amount;
                contaxt.SaveChanges();
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
        public object GetAmount(int ProductId)
        {
            try
            {
                decimal Count = 0;
                foreach (var item in contaxt.InventoryOutsDeatils.Where(p => p.ProductId == ProductId).ToList())
                    if (contaxt.InventoryOutsHeaders.First(p => p.InventoryOutsHeaderId == item.InventoryOutsHeaderId & p.Accepted == true) != null)
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
