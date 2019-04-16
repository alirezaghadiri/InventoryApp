using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.Product
{
    public class List :Framwork.ViewBase
    {
        RepositortAbstracts.IProduct pro;
        public int? ProductCategoryId { get; set; }
        Framwork.GirdControl<Entities.Product> grid;

        public List(RepositortAbstracts.IProduct pro)
        {
            this.pro = pro;
            AddAction("افزودن", btn =>
            {
                var result = viewEngine.ViewInForm<view.Product.Editor>(null, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    if (pro.Add(result.Entity))
                    {
                        MessageBox.Show("شرکت با موفقیت ثبت شد", "پیام سیستم");
                        grid.AddItem(result.Entity);
                        grid.ResetBindings();
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ثبت شرکت به وجود آمد", "پیام سیستم");
                    }
                }

            });
            AddAction("ویرایش", btn =>
            {
                var result = viewEngine.ViewInForm<view.Product.Editor>(editor =>
                {
                    editor.Entity = grid.CurrentItem;

                }, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    if (pro.Update(result.Entity))
                    {
                        MessageBox.Show("محصول با موفقیت ویرایش شد", "پیام سیستم");
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ویرایش محصول به وجود آمد", "پیام سیستم");
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
                    int dn = pro.CanDelete(grid.CurrentItem.ProductId);
                    if (dn != 0)
                        MessageBox.Show("این مورد به علت وابستگی به" + dn + "مواردامکان پاک شدن ندارد", "پیام سیستم");
                    else
                    {
                        if (pro.Delete(grid.CurrentItem.ProductId))
                        {

                            MessageBox.Show("محصول با موفقیت حذف شد", "پیام سیستم");
                            grid.RemoveCurrent();
                            grid.ResetBindings();
                        }
                        else
                        {
                            MessageBox.Show("محصول در حذف شرکت به وجود آمد", "پیام سیستم");
                        }
                    }
                }

            });
        }
        protected override void OnLoad(EventArgs e)
        {
            grid=new Framwork.GirdControl<Entities.Product>(this);
            grid.AddTextBoxColumn(p => p.Code, "کد");
           
            grid.AddTextBoxColumn(p => p.Title, "عنوان محصول");

            if (ProductCategoryId.HasValue)
            {
                grid.SetDataSource(pro.GetAll(ProductCategoryId.Value));
            }
            else
            {
                grid.AddTextBoxColumn(p => p.ProductCategoryId, "دسته بندی");
                grid.SetDataSource(pro.GetAll());
            }
            base.OnLoad(e);
        }

    }
}
