using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.InventoryOutsType
{
    public class Editor : Framwork.EntityEditor<Entities.InventoryOutsType>
    {
        public Editor()
        {
            if (Entity.InventoryOutsTypeId == 0)
                ViewTitle = "تعریف نوع رسید";
            else
                ViewTitle = "ویرایش نوع رسید " + Entity.InventoryOutsTypeId;
        }
        protected override void OnLoad(EventArgs e)
        {
            TextBox(p => p.Title, "عنوان");
            TextBox(p => p.Description, "توضیحات", true);
            AdjustControls();
            base.OnLoad(e);
        }
    }
}
