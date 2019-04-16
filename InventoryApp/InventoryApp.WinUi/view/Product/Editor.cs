using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.Product
{
    public class Editor :Framwork.EntityEditor<Entities.Product>
    {
        RepositortAbstracts.IProductCategory catrepo;
        RepositortAbstracts.IProductUnit unit;
        public Editor(RepositortAbstracts.IProductCategory catrepo, RepositortAbstracts.IProductUnit unit)
        {
            this.catrepo = catrepo;
            this.unit = unit;
        }
        protected override void OnLoad(EventArgs e)
        {
            ComboBox(p => p.ProductCategoryId, "دسته بندی", catrepo.GetAll().ToList(), p => p.Title, p => p.ProductCategoryId);
            TextBox(p => p.Code,"کد");
            TextBox(p => p.Title, "عنوان");
            ComboBox(p => p.ProductUnitId, "واحد اندازه گیری", unit.GetAll().ToList(), p => p.Title, p => p.ProductUnitId);
            TextBox(p => p.Description, "توضیحات",true);
            AdjustControls();
            base.OnLoad(e); 
        }
    }
}
