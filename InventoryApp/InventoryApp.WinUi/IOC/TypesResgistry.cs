using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Repositories;
using InventoryApp.RepositortAbstracts;

namespace InventoryApp.WinUi.IOC
{
    public class TypesResgistry:StructureMap.Registry
    {
        public TypesResgistry()
        {
            For<ICorporation>().Use<CorporationRepository>();
            For<IProductUnit>().Use<ProductUnitRepository>();
        }
    }
}
