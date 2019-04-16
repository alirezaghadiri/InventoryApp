using System;
using System.Windows.Forms; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.InventoryInsType
{
    public class List : Framwork.ViewBase
    {
        RepositortAbstracts.IInventoryInsType instype;
        Framwork.GirdControl<Entities.InventoryInsType> grid;
        public List(RepositortAbstracts.IInventoryInsType instype)
        {
            this.instype = instype;
        }
        protected override void OnLoad(EventArgs e)
        {
            AddAction("افزودن", btn =>
            {
                var result = viewEngine.ViewInForm<view.InventoryInsType.Editor>(null, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    if (instype.Add(result.Entity))
                    {
                        MessageBox.Show("رسید با موفقیت ثبت شد", "پیام سیستم");
                        grid.AddItem(result.Entity);
                        grid.ResetBindings();
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ثبت رسید به وجود آمد", "پیام سیستم");
                    }
                }

            });
            AddAction("ویرایش", btn =>
            {
                var result = viewEngine.ViewInForm<view.InventoryInsType.Editor>(editor =>
                {
                    editor.Entity = grid.CurrentItem;

                }, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    if (instype.Update(result.Entity))
                    {
                        MessageBox.Show("رسید با موفقیت ویرایش شد", "پیام سیستم");
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ویرایش رسید به وجود آمد", "پیام سیستم");
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
                    
                    int dn = instype.CanDelete(grid.CurrentItem.InventoryInsTypeId);
                    if (dn != 0)
                        MessageBox.Show("این مورد به علت وابستگی به" + dn + "مواردامکان پاک شدن ندارد", "پیام سیستم");
                    else
                    {
                        if (instype.Delete(grid.CurrentItem.InventoryInsTypeId))
                        {

                            MessageBox.Show("رسید با موفقیت حذف شد", "پیام سیستم");
                            grid.RemoveCurrent();
                            grid.ResetBindings();
                        }
                        else
                        {
                            MessageBox.Show("مشکل در حذف رسید به وجود آمد", "پیام سیستم");
                        }
                    }
                }

            });
            grid = new Framwork.GirdControl<Entities.InventoryInsType>(this);
            grid.AddTextBoxColumn(p => p.Title, "عنوان رسید");
            grid.AddTextBoxColumn(p => p.Description, "توضیحات");
            grid.SetDataSource(instype.GetAll());
            base.OnLoad(e);
        }
    }
}
