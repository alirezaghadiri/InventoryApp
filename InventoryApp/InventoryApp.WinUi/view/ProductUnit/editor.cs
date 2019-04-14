using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.ProductUnit
{
    public class Editor : Framwork.EntityEditor<Entities.ProductUnit>
    {
        RepositortAbstracts.IProductUnit prouint;
        public Editor(RepositortAbstracts.IProductUnit ProductUnitRepository)
        {
            this.prouint = ProductUnitRepository;
            if (Entity.ProductUnitId == 0)
                ViewTitle = "تعریف واحد";
            else
                ViewTitle = "ویرایش واحد " + Entity.ProductUnitId;
        }
        protected override void OnLoad(EventArgs e)
        {
            TextBox(p => p.Title, "نام واحد");
            TextBox(p => p.Description, "توضیحات", true);
            AdjustControls();
            base.OnLoad(e);
        }

    }
}


