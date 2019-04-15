using InventoryApp.Repositories;
using InventoryApp.RepositortAbstracts;
using System;
using System.Windows.Forms;

namespace InventoryApp.WinUi.view.Inventory
{
    public class List : Framwork.ViewBase
    {
        RepositortAbstracts.IInventory Invs;
        Framwork.GirdControl<Entities.Inventory> grid;
        public List(RepositortAbstracts.IInventory InventoryRepository)
        {
            this.Invs = InventoryRepository;
            ViewTitle = "تعریف شرکت";
        }
        protected override void OnLoad(EventArgs e)
        {
            AddAction("افزودن",btn=> 
            {
                var result = viewEngine.ViewInForm<view.Inventory.Editor>(null, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    IInventory inventory = new InventoryRepository();
                    if (inventory.Add(result.Entity))
                    {
                        MessageBox.Show("انبار با موفقیت ثبت شد", "پیام سیستم");
                        grid.AddItem(result.Entity);
                        grid.ResetBindings();
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ثبت انبار به وجود آمد", "پیام سیستم");
                    }
                }
            });
            AddAction("ویرایش", btn =>
            {
                var result = viewEngine.ViewInForm<view.Inventory.Editor>(editor =>
                {
                    editor.Entity = grid.CurrentItem;

                }, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    IInventory inventory = new InventoryRepository();
                    if (inventory.Update(result.Entity))
                    {
                        MessageBox.Show("انبار با موفقیت ویرایش شد", "پیام سیستم");
                        grid.ResetBindings();
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ویرایش انبار به وجود آمد", "پیام سیستم");
                    }
                    
                }
            });
            AddAction("حذف", btn =>
            {
                if (grid.CurrentItem == null)
                    return;
                if (MessageBox.Show("آیا میخواهید حذف کنید ؟", "پیام سیستم", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    IInventory inventory = new InventoryRepository();
                    int dn = inventory.CanDelete(grid.CurrentItem.InventoryId);
                    if (dn != 0)
                        MessageBox.Show("این مورد به علت وابستگی به" + dn + "مواردامکان پاک شدن ندارد", "پیام سیستم");
                    else
                    {
                        if (inventory.Delete(grid.CurrentItem.InventoryId))
                        {

                            MessageBox.Show("انبار با موفقیت حذف شد", "پیام سیستم");
                            grid.RemoveCurrent();
                            grid.ResetBindings();
                        }
                        else
                        {
                            MessageBox.Show("مشکل در حذف انبار به وجود آمد", "پیام سیستم");
                        }
                    }
                }
            });
            grid = new Framwork.GirdControl<Entities.Inventory>(this);
            grid.AddTextBoxColumn(p => p.CorporationId, "شناسه");
            grid.AddTextBoxColumn(p => p.Title, "نام انبار");
            grid.AddTextBoxColumn(p => p.CorporationId, "کد شرکت");
            grid.AddTextBoxColumn(p => p.Telephone, "شماره تماس");
            grid.AddTextBoxColumn(p => p.Address, "نشانی");
            grid.AddTextBoxColumn(p => p.Description, "توضیحات");
            grid.SetDataSource(Invs.GetAll());
            base.OnLoad(e);
        }
    }
}
