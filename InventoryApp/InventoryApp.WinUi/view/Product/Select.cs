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
        public int? ProductCategoryId { get; set; }
        Framwork.GirdControl<Entities.Product> grid;

        public Select(RepositortAbstracts.IProduct pro, RepositortAbstracts.IProductParameterValue pvalue)
        {
            this.pro = pro;
            this.pvalue = pvalue;
            AddAction("انتخاب", btn =>
            {
                var result = viewEngine.ViewInForm<view.Product.Editor>(null, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    if (pro.Add(result.Entity))
                    {
                        if (Addparamervalue(result.parameterControls, result.Entity.ProductId))
                        {
                            MessageBox.Show("محصول با موفقیت ثبت شد", "پیام سیستم");
                            grid.AddItem(result.Entity);
                            grid.ResetBindings();
                        }
                        else
                        {
                            MessageBox.Show("مشکل در محصول  به وجود آمد", "پیام سیستم");
                        }
                    }

                    else
                    {
                        MessageBox.Show("مشکل در محصول  به وجود آمد", "پیام سیستم");
                    }
                }

            });
           
           
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
        public bool Addparamervalue(Dictionary<Entities.ProductParameter, TextBox> param, int id)
        {
            try
            {
                pvalue.Delete(id);
                foreach (var item in param)
                {
                    pvalue.Add(new Entities.ProductParameterValue
                    {
                        ProductId = id,
                        ProductParameterId = item.Key.ProductParameterId,
                        Value = item.Value.Text,
                    });
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Updateparamervalue(Dictionary<Entities.ProductParameter, TextBox> param, int id)
        {
            try
            {
                foreach (var item in param)
                {
                    pvalue.Update(new Entities.ProductParameterValue
                    {
                        ProductId = id,
                        ProductParameterId = item.Key.ProductParameterId,
                        Value = item.Value.Text,
                    });
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
