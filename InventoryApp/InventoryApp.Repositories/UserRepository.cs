using System;
using System.Linq;
using InventoryApp.Entities;
using InventoryApp.RepositortAbstracts;
using System.Collections.Generic;

namespace InventoryApp.Repositories
{
    public class UserRepository : IUser
    {
        private DataLayer.InventoryDBContext contaxt { get; set; }
        public UserRepository()
        {
            contaxt = new DataLayer.InventoryDBContext();
        }
        public bool Add(User _User)
        {
            try
            {
                contaxt.Users.Add(_User);
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
                var _contaxt = contaxt.Users.Where(p => p.UserId == id).FirstOrDefault();
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
        public User Find(int id)
        {
            try
            {
                return contaxt.Users
                .Where(p => p.UserId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }
        public bool Update(User _User)
        {
            try
            {
                var _contaxt = contaxt.Users.Where(p => p.UserId == _User.UserId).FirstOrDefault();
                _contaxt = _User;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ICollection<User> GetAll()
        {
            return contaxt.Users.Where(p => p.Deleted == false).ToList();
        }
    }
}
