using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.ProductParameter
{
    public class Editor:Framwork.EntityEditor<Entities.ProductParameter>
    {
        protected override void OnLoad(EventArgs e)
        {
            TextBox(p => p.Key, "کلید");
            TextBox(p => p.Title, "عنوان");
            TextBox(p => p.Description, "توضیحات",true);
            AdjustControls();
            base.OnLoad(e);
        }
    }
}
