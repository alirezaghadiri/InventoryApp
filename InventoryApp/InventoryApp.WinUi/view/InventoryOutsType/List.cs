using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.InventoryOutsType
{
    public class List : Framwork.ViewBase
    {
        RepositortAbstracts.IInventoryOutsType Outstype;
        Framwork.GirdControl<Entities.InventoryOutsType> grid;
        public List(RepositortAbstracts.IInventoryOutsType Outstype)
        {
            this.Outstype = Outstype;
        }
        protected override void OnLoad(EventArgs e)
        {
            AddAction("افزودن", btn =>
            {
                var result = viewEngine.ViewInForm<view.InventoryOutsType.Editor>(null, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    if (Outstype.Add(result.Entity))
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
                var result = viewEngine.ViewInForm<view.InventoryOutsType.Editor>(editor =>
                {
                    editor.Entity = grid.CurrentItem;

                }, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    if (Outstype.Update(result.Entity))
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

                    int dn = Outstype.CanDelete(grid.CurrentItem.InventoryOutsTypeId);
                    if (dn != 0)
                        MessageBox.Show("این مورد به علت وابستگی به" + dn + "مواردامکان پاک شدن ندارد", "پیام سیستم");
                    else
                    {
                        if (Outstype.Delete(grid.CurrentItem.InventoryOutsTypeId))
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
            grid = new Framwork.GirdControl<Entities.InventoryOutsType>(this);
            grid.AddTextBoxColumn(p => p.Title, "عنوان رسید");
            grid.AddTextBoxColumn(p => p.Description, "توضیحات");
            grid.SetDataSource(Outstype.GetAll());
            base.OnLoad(e);
        }
    }
}
