using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class RoleRepository : IRole
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public RoleRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(Role _Role)
        {
            try
            {
                contaxt.Roles.Add(_Role);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(Role _Role)
        {
            try
            {
                var _contaxt = contaxt.Roles.Remove(_Role);
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Role Find(int id)
        {
            try
            {
                return contaxt.Roles
                .Where(p => p.RoleId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(Role _Role)
        {
            try
            {
                var _contaxt = contaxt.Roles
                .Where(p => p.RoleId == _Role.RoleId).FirstOrDefault();
                _contaxt = _Role;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<Role> GetAll()
        {
            return contaxt.Roles.ToList();
        }
    }
}
