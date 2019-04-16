using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.InventoryInsType
{
    public class Editor :Framwork.EntityEditor<Entities.InventoryInsType>
    {
        public Editor()
        {
            if (Entity.InventoryInsTypeId == 0)
                ViewTitle = "تعریف نوع رسید";
            else
                ViewTitle = "ویرایش نوع رسید " + Entity.InventoryInsTypeId;
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
