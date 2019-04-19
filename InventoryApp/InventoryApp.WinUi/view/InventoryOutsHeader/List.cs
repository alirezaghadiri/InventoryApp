using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.InventoryOutsHeader
{
   public  class List : Framwork.ViewBase
    {
        RepositortAbstracts.IInventoryOutsHeader Invs;
        Framwork.GirdControl<Entities.InventoryOutsHeader> grid;
        public List(RepositortAbstracts.IInventoryOutsHeader InventoryOutsHeaderRepository)
        {
            this.Invs = InventoryOutsHeaderRepository;
        }
        protected override void OnLoad(EventArgs e)
        {
            //AddAction("افزودن", btn =>
            //{
            //    InventoryOutsHeader IH = new InventoryOutsHeader();
            //    if (IH.ShowDialog() == DialogResult.OK)
            //    {
            //        grid.AddItem(IH._InventoryOutsHeader);
            //        grid.ResetBindings();
            //    }
     
            //});
            //AddAction("ویرایش", btn =>
            //{
            //    if (Invs.Update(grid.CurrentItem))
            //    {
            //        grid.ResetBindings();
            //        MessageBox.Show("با موفقیت ثبت شد", "پیام سیستم");
            //    }
            //    else
            //    {
            //        MessageBox.Show("مشکل در ویرایش  به وجود آمد", "پیام سیستم");
            //    }
            //});
            //AddAction("حذف", btn =>
            //{
            //    if (Invs.Delete(grid.CurrentItem.InventoryOutsHeaderId))
            //    {
            //        grid.ResetBindings();
            //        MessageBox.Show("با موفقیت انجام شد", "پیام سیستم");
            //    }
            //    else
            //    {
            //        MessageBox.Show("مشکل در   به وجود آمد", "پیام سیستم");
            //    }
            //});

            grid = new Framwork.GirdControl<Entities.InventoryOutsHeader>(this);
            grid.AddTextBoxColumn(p => p.InventoryOutsHeaderId, "شناسه");
            grid.AddTextBoxColumn(p => p.Title, "عنوان");
            grid.AddTextBoxColumn(p => p.TypeId, "نوع رسید");
            grid.AddTextBoxColumn(p => p.Date, "تاریخ");
            grid.AddDropDownColumnTrueFalse(p => p.Accepted, "وضعیت");
            grid.SetDataSource(Invs.GetAll());
            base.OnLoad(e);
        }
    }

}
