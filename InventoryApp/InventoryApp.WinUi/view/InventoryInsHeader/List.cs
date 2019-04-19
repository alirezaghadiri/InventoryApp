using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.InventoryInsHeader
{
    public class List : Framwork.ViewBase
    {
        RepositortAbstracts.IInventoryInsHeader Invs;
        RepositortAbstracts.IInventoryInsDeatil invd;
        Framwork.GirdControl<Entities.InventoryInsHeader> grid;
        public List(RepositortAbstracts.IInventoryInsHeader InventoryInsHeaderRepository, RepositortAbstracts.IInventoryInsDeatil invd)
        {
            this.Invs = InventoryInsHeaderRepository;
            this.invd = invd;
        }
        protected override void OnLoad(EventArgs e)
        {
            //AddAction("افزودن", btn =>
            //{
            //    InventoryInsHeader IH = new InventoryInsHeader();
            //    if (IH.ShowDialog() == DialogResult.OK)
            //    {
            //        grid.AddItem(IH._InventoryInsHeader);
            //        grid.ResetBindings();
            //    }
            //});
            //AddAction("حذف", btn =>
            //{
            //    int id = grid.CurrentItem.InventoryInsHeaderId;
            //    if (Invs.Delete(id))
            //    {
            //        foreach (var item in invd.GetAll().Where(p => p.InventoryInsHeaderId == id).ToList())
            //        {
            //            invd.Delete(item);
            //        }
            //        grid.ResetBindings();
            //        MessageBox.Show("با موفقیت انجام شد", "پیام سیستم");
            //    }
            //    else
            //    {
            //        MessageBox.Show("مشکل در   به وجود آمد", "پیام سیستم");
            //    }
            //});

            grid = new Framwork.GirdControl<Entities.InventoryInsHeader>(this);
            grid.AddTextBoxColumn(p => p.InventoryInsHeaderId, "شناسه");
            grid.AddTextBoxColumn(p => p.Title, "عنوان");
            grid.AddTextBoxColumn(p => p.TypeId, "نوع رسید");
            grid.AddTextBoxColumn(p => p.Date, "تاریخ");
            grid.AddDropDownColumnTrueFalse(p => p.Accepted, "وضعیت");
            grid.SetDataSource(Invs.GetAll());
            base.OnLoad(e);
        }
    }

}
