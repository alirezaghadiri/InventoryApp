using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.Inventory
{
    public class Editor : Framwork.EntityEditor<Entities.Inventory>
    {
        RepositortAbstracts.IInventory Invs;
        RepositortAbstracts.ICorporation Corps;
        public Editor(RepositortAbstracts.IInventory InventoryRepository, RepositortAbstracts.ICorporation CorporationRepository)
        {
            this.Invs = InventoryRepository;
            this.Corps = CorporationRepository;
            if (Entity.InventoryId == 0)
                ViewTitle = "تعریف انبار";
            else
                ViewTitle = "ویرایش انبار " + Entity.InventoryId;
        }
        protected override void OnLoad(EventArgs e)
        {
            TextBox(p => p.Title, "نام انبار");
            ComboBox(inv => inv.CorporationId, "شرکت/موسسه", Corps.GetAll().ToList(), Corp => Corp.Title, corp => corp.CorporationId);
            TextBox(p => p.Telephone, "شماره تماس");
            TextBox(p => p.Address, "آدرس");
            TextBox(p => p.Description, "توضیحات", true);
            AdjustControls();
            base.OnLoad(e);
        }

    }
}
