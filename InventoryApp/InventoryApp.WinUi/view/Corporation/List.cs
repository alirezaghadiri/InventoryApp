using System;
using System.Windows.Forms;
using InventoryApp.RepositortAbstracts;
using InventoryApp.Repositories;

namespace InventoryApp.WinUi.view.Corporation
{
    public class List : Framwork.ViewBase
    {
        RepositortAbstracts.ICorporation Corps;
        Framwork.GirdControl<Entities.Corporation> grid;
        public List(RepositortAbstracts.ICorporation CorporationRepository)
        {
            this.Corps = CorporationRepository;
            ViewTitle = "تعریف شرکت";
        }
        protected override void OnLoad(EventArgs e)
        {
            AddAction("افزودن", btn =>
            {
                var result = viewEngine.ViewInForm<view.Corporation.Editor>(null, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    ICorporation corporation = new CorporationRepository();
                    if (corporation.Add(result.Entity))
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
                var result = viewEngine.ViewInForm<view.Corporation.Editor>(editor =>
              {
                  editor.Entity = grid.CurrentItem;

              }, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    ICorporation corporation = new CorporationRepository();
                    if (corporation.Update(result.Entity))
                    {
                        MessageBox.Show("شرکت با موفقیت ویرایش شد", "پیام سیستم");
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ویرایش شرکت به وجود آمد", "پیام سیستم");
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
                    ICorporation corporation = new CorporationRepository();
                    int dn = corporation.CanDelete(grid.CurrentItem.CorporationId);
                    if (dn != 0)
                        MessageBox.Show("این مورد به علت وابستگی به" + dn + "مواردامکان پاک شدن ندارد", "پیام سیستم");
                    else
                    {
                        if (corporation.Delete(grid.CurrentItem.CorporationId))
                        {

                            MessageBox.Show("شرکت با موفقیت حذف شد", "پیام سیستم");
                            grid.RemoveCurrent();
                            grid.ResetBindings();
                        }
                        else
                        {
                            MessageBox.Show("مشکل در حذف شرکت به وجود آمد", "پیام سیستم");
                        }
                    }
                }
                
            });
            grid = new Framwork.GirdControl<Entities.Corporation>(this);
            grid.AddTextBoxColumn(p => p.CorporationId, "شناسه");
            grid.AddTextBoxColumn(p => p.Title, "نام شرکت");
            grid.AddTextBoxColumn(p => p.Telephone, "شماره تماس");
            grid.AddTextBoxColumn(p => p.Address, "نشانی");
            grid.AddTextBoxColumn(p => p.Description, "توضیحات");
            grid.SetDataSource(Corps.GetAll());
            base.OnLoad(e);
        }
    }
}
