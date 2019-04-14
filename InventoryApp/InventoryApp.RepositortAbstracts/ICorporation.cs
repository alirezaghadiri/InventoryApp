using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Entities;

namespace InventoryApp.RepositortAbstracts
{
    public interface ICorporation
    {
        bool Add(Corporation corporation);
        bool Update(Corporation corporation);
        bool Delete(int id);
        Corporation Find(int id);
        ICollection<Corporation> GetAll();
       ICollection<Corporation> Search(CorporationSearchType SearchType, string value);
         int Count();
    }
    public enum CorporationSearchType
    {
        All=0,
        CorporationId=1,
        Title =2,
        Address=3,
        Telephone=4
    }
}
