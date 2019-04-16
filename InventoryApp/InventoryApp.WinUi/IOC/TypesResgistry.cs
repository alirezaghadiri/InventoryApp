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
            For<IUser>().Use<UserRepository>();
            For<IRole>().Use<RoleRepository>();
            For<ICorporation>().Use<CorporationRepository>();
            For<IInventory>().Use<InventoryRepository>();
            For<IProductUnit>().Use<ProductUnitRepository>();
            For<IProduct>().Use<ProductRepository>();
            For<IInventoryInsDeatil>().Use<InventoryInsDeatilRepository>();
            For<IInventoryInsType>().Use<InventoryInsTypeRepository>();
            For<IInventoryInsHeader>().Use<InventoryInsHeaderRepository>();
            For<IInventoryOutsDeatil>().Use<InventoryOutsDeatilRepository>();
            For<IInventoryOutsType>().Use<InventoryOutsTypeRepository>();
            For<IInventoryOutsHeader>().Use<InventoryOutsHeaderRepository>();
            For<IProductCategory>().Use<ProductCategoryRepository>();
            For<IProductParameter>().Use<ProductParameterRepository>();
            For<IProductParameterValue>().Use<ProductParameterValueRepository>();
        }
    }
}
