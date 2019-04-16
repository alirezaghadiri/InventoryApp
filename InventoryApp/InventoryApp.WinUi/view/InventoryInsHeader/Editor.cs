using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.InventoryInsHeader
{
    public class Editor:Framwork.EntityEditor<Entities.InventoryInsHeader>
    {
        RepositortAbstracts.IInventory invs;
        RepositortAbstracts.IInventoryInsType type;
        public Editor(RepositortAbstracts.IInventory invs, RepositortAbstracts.IInventoryInsType type)
        {
            this.invs = invs;
            this.type = type;
        }
        protected override void OnLoad(EventArgs e)
        {
            ComboBox(inv => inv.InventoryId, "انبار", invs.GetAll().ToList(), p => p.Title, p => p.InventoryId);
            ComboBox(inv => inv.TypeId, "نوع رسید", type.GetAll().ToList(), p => p.Title, p => p.InventoryInsTypeId);
            TextBox(p => p.Title, "نام رسید");
            TextBox(p => p.Description, "توضیحات", true);
            AdjustControls();
            base.OnLoad(e);
        }
    }
}
