using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.RepositortAbstracts;
using InventoryApp.Repositories;

namespace InventoryApp.WinUi.view.ProductUnit
{
    class List : Framwork.ViewBase
    {
        RepositortAbstracts.IProductUnit ProUnit;
        Framwork.GirdControl<Entities.ProductUnit> grid;
        public List(RepositortAbstracts.IProductUnit ProductUnitRepository)
        {
            this.ProUnit = ProductUnitRepository;
            ViewTitle = "نمایش واحد";
        }
        protected override void OnLoad(EventArgs e)
        {
            AddAction("ویرایش", btn =>
            {
                var result = viewEngine.ViewInForm<view.ProductUnit.Editor>(editor =>
                {
                    editor.Entity = grid.CurrentItem;

                }, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    IProductUnit productUnit = new ProductUnitRepository();
                    if (productUnit.Update(result.Entity))
                    {
                        MessageBox.Show("واحد با موفقیت ویرایش شد", "پیام سیستم");
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ویرایش واحد به وجود آمد", "پیام سیستم");
                    }
                    grid.ResetBindings();
                }
            });
            AddAction("حذف", btn =>
            {
                if (grid.CurrentItem == null)
                    return;
                if (MessageBox.Show("آیا میخواهید حذف کنید ؟", "پیام سیستم", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    IProductUnit productUnit = new ProductUnitRepository();
                    if (productUnit.Delete(grid.CurrentItem.ProductUnitId))
                    {
                        MessageBox.Show("واحد با موفقیت حذف شد", "پیام سیستم");
                        grid.RemoveCurrent();
                        grid.ResetBindings();
                    }
                    else
                    {
                        MessageBox.Show("مشکل در حذف واحد به وجود آمد", "پیام سیستم");
                    }
                }
               
            });
            grid = new Framwork.GirdControl<Entities.ProductUnit>(this);
            grid.AddTextBoxColumn(p => p.ProductUnitId, "شناسه");
            grid.AddTextBoxColumn(p => p.Title, "نام انبار");
            grid.AddTextBoxColumn(p => p.Description, "توضیحات");
            grid.SetDataSource(ProUnit.GetAll());
            base.OnLoad(e);
        }
    }
}
