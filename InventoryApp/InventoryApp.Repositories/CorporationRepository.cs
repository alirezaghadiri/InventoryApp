﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.RepositortAbstracts;

namespace InventoryApp.Repositories
{
    public class CorporationRepository : RepositortAbstracts.ICorporation
    {
        public bool Add(Entities.Corporation corporation)
        {
            try
            {
                var contaxt = new DataLayer.InventoryDBContext();
                corporation.CreatedDate = DateTime.Now;
                corporation.CreatedByUserId = DatabaseTools.GetUserID;
                contaxt.Corporations.Add(corporation);
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
                var contaxt = new DataLayer.InventoryDBContext();
                var corporation = contaxt.Corporations.Where(p => p.CorporationId == id).FirstOrDefault();
                corporation.Deleted = true;
                corporation.DeletedDate = DateTime.Now;
                corporation.DeletedByUserId = DatabaseTools.GetUserID;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Entities.Corporation Find(int id)
        {
            try
            {
                var contaxt = new DataLayer.InventoryDBContext();
                return contaxt.Corporations.Where(p => p.CorporationId == id).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public ICollection<Entities.Corporation> Search(CorporationSearchType SearchType, string value)
        {
            List<Entities.Corporation> List = new List<Entities.Corporation>();
            var contaxt = new DataLayer.InventoryDBContext();
            switch (SearchType)
            {
                case CorporationSearchType.All:
                    {
                        //search by address
                        var _corporation = contaxt.Corporations.Where(p => p.Address == value).ToList();
                        List.AddRange(_corporation);

                        //search by title
                        _corporation = contaxt.Corporations.Where(p => p.Title == value).ToList();
                        List.AddRange(_corporation);

                        //search by Telephone
                        _corporation = contaxt.Corporations.Where(p => p.Telephone == value).ToList();
                        List.AddRange(_corporation);

                        //search by id
                        int id = 0;
                        if (int.TryParse(value, out id))
                        {
                            _corporation = contaxt.Corporations.Where(p => p.CorporationId == id).ToList();
                            List.AddRange(_corporation);
                        }
                        return List;
                    }
                case CorporationSearchType.CorporationId :
                    {
                        //search by id
                        int id = 0;
                        if (int.TryParse(value, out id))
                        {
                            var _corporation = contaxt.Corporations.Where(p => p.CorporationId == id).ToList();
                            List.AddRange(_corporation);
                        }
                        return List;
                    }
                case CorporationSearchType.Title:
                    {
                        //search by title
                        var _corporation = contaxt.Corporations.Where(p => p.Title == value).ToList();
                        List.AddRange(_corporation);
                        return List;
                    }
                case CorporationSearchType.Address:
                    {
                        //search by address
                        var _corporation = contaxt.Corporations.Where(p => p.Address == value).ToList();
                        List.AddRange(_corporation);
                        return List;
                    }
                case CorporationSearchType.Telephone:
                    {
                        //search by Telephone
                        var _corporation = contaxt.Corporations.Where(p => p.Telephone == value).ToList();
                        List.AddRange(_corporation);
                        return List;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public bool Update(Entities.Corporation corporation)
        {
            try
            {
                var contaxt = new DataLayer.InventoryDBContext();
                var _corporation = contaxt.Corporations.Where(p => p.CorporationId == corporation.CorporationId).FirstOrDefault();
                _corporation = corporation;
                _corporation.ChangedDate = DateTime.Now;
                _corporation.ChangedByUserId = DatabaseTools.GetUserID;
                contaxt.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
