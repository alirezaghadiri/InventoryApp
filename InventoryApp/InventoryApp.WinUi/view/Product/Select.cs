using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.Product
{
    public class Select : Framwork.ViewBase
    {
        RepositortAbstracts.IProduct pro;
        RepositortAbstracts.IProductParameterValue pvalue;
        public Entities.Product product;
        public int? ProductCategoryId { get; set; }
        Framwork.GirdControl<Entities.Product> grid;

        public Select(RepositortAbstracts.IProduct pro, RepositortAbstracts.IProductParameterValue pvalue)
        {
            this.pro = pro;
            this.pvalue = pvalue;
            AddAction("انتخاب", btn =>
            {
                product = grid.CurrentItem;
                CloseView(DialogResult.OK);
            });
            AddAction("صرفنظر", btn => CloseView(DialogResult.Cancel));
        }
        protected override void OnLoad(EventArgs e)
        {
            grid = new Framwork.GirdControl<Entities.Product>(this);
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
