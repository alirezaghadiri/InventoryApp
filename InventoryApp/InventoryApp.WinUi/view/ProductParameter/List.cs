using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.ProductParameter
{
    public class List:Framwork.ViewBase
    {
        public int ParentCategoryId { get; set; }
        public RepositortAbstracts.IProductParameter paramsRepo;
        Framwork.GirdControl<Entities.ProductParameter> grid;
        
        public List(RepositortAbstracts.IProductParameter paramsRepo)
        {
            this.paramsRepo = paramsRepo;

            AddAction("افزودن", btn =>
            {
                var result = viewEngine.ViewInForm<view.ProductParameter.Editor>(null, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    result.Entity.ProductCategoryId = ParentCategoryId;
                    if (paramsRepo.Add(result.Entity))
                    {
                        MessageBox.Show("پارامتر با موفقیت ثبت شد", "پیام سیستم");
                        grid.AddItem(result.Entity);
                        grid.ResetBindings();
                    }
                    else
                    {
                        MessageBox.Show("مشکل در پارامتر شرکت به وجود آمد", "پیام سیستم");
                    }
                }

            });
            AddAction("ویرایش", btn =>
            {
                var result = viewEngine.ViewInForm<view.ProductParameter.Editor>(editor =>
                {
                    editor.Entity = grid.CurrentItem;

                }, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    if (paramsRepo.Update(result.Entity))
                    {
                        MessageBox.Show("پارامتر با موفقیت ویرایش شد", "پیام سیستم");
                        grid.ResetBindings();
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ویرایش پارامتر به وجود آمد", "پیام سیستم");
                    }
                   
                }
            });
            AddAction("حذف", btn =>
            {
                if (grid.CurrentItem == null)
                    return;
                if (MessageBox.Show("آیا میخواهید حذف کنید ؟", "پیام سیستم", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int dn = paramsRepo.CanDelete(grid.CurrentItem.ProductParameterId);
                    if (dn != 0)
                        MessageBox.Show("این مورد به علت وابستگی به" + dn + "مواردامکان پاک شدن ندارد", "پیام سیستم");
                    else
                    {
                        if (paramsRepo.Delete(grid.CurrentItem.ProductParameterId))
                        {

                            MessageBox.Show("پارامتر با موفقیت حذف شد", "پیام سیستم");
                            grid.RemoveCurrent();
                            grid.ResetBindings();
                        }
                        else
                        {
                            MessageBox.Show("مشکل در حذف پارامتر به وجود آمد", "پیام سیستم");
                        }
                    }
                }

            });

        }
        protected override void OnLoad(EventArgs e)
        {
            grid = new Framwork.GirdControl<Entities.ProductParameter>(this);
            grid.AddTextBoxColumn(p => p.Title, "عنوان");
            grid.AddTextBoxColumn(p => p.Key, "کلید");
            grid.SetDataSource(paramsRepo.GetAll(ParentCategoryId));
            base.OnLoad(e);
        }
    }
}
