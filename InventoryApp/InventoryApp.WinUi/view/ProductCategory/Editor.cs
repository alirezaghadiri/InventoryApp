using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.ProductCategory
{
    public class Editor : Framwork.EntityEditor<Entities.ProductCategory>
    {
        public Entities.ProductCategory ParentCategory;
        RepositortAbstracts.IInventory Inves;
        public Editor(RepositortAbstracts.IInventory Inves)
        {
            this.Inves = Inves;
        }
        protected override void OnLoad(EventArgs e)
        {
            if (ParentCategory != null)
            {
                int parentId = ParentCategory.ProductCategoryId;
                int invId = ParentCategory.InventoryId;
                Entity = new Entities.ProductCategory
                {
                    SubProductCategoryID = parentId,
                    InventoryId = invId,
                };


                var txt = TextBox("مسیر");
                txt.Enabled = false;
                txt.Text = ParentCategory.Title;

                var txt1 = TextBox("انبار");
                txt1.Enabled = false;
                txt1.Text = ParentCategory.Title;
            }
            else
            {
                var txt = TextBox("مسیر");
                txt.Enabled = false;
                txt.Text = "ریشه";
                var re = Inves.GetAll().ToList();
                ComboBox(cat => cat.InventoryId, "انبار",re , p => p.Title, p => p.InventoryId);
            }
            TextBox(cat => cat.Title, "عنوان");
            TextBox(cat => cat.Capacity, "ظرفیت");
            TextBox(cat => cat.Description, "توضیحات", true);
            AdjustControls();
            base.OnLoad(e);
        }
    }
}
