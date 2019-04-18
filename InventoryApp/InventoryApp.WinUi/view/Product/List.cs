using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.Product
{
    public class List : Framwork.ViewBase
    {
        RepositortAbstracts.IProduct pro;
        RepositortAbstracts.IProductParameterValue pvalue;
        public int? ProductCategoryId { get; set; }
        Framwork.GirdControl<Entities.Product> grid;

        public List(RepositortAbstracts.IProduct pro, RepositortAbstracts.IProductParameterValue pvalue)
        {
            this.pro = pro;
            this.pvalue = pvalue;
            AddAction("افزودن", btn =>
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
            AddAction("ویرایش", btn =>
            {
                var result = viewEngine.ViewInForm<view.Product.Editor>(editor =>
                {
                    editor.Entity = grid.CurrentItem;

                }, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    if (Updateparamervalue(result.parameterControls, result.Entity, result._OldParameterId))
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

                    else
                    {
                        MessageBox.Show("مشکل در ویرایش محصول به وجود آمد", "پیام سیستم");
                    }
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
                        if (pvalue.Delete(grid.CurrentItem.ProductId))
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
                }
                else
                {
                    MessageBox.Show("محصول در حذف شرکت به وجود آمد", "پیام سیستم");
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
        public bool Updateparamervalue(Dictionary<Entities.ProductParameter, TextBox> param, Entities.Product product, int OldCategoryid)
        {
            try
            {
                if (OldCategoryid == product.ProductCategoryId)
                {
                    foreach (var item in param)
                    {
                        pvalue.Update(new Entities.ProductParameterValue
                        {
                            ProductId = product.ProductId,
                            ProductParameterId = item.Key.ProductParameterId,
                            Value = item.Value.Text,
                        });
                    }
                }
                else
                {
                    if (pvalue.Delete(product.ProductId))
                    {
                        Addparamervalue(param, product.ProductId);
                    }
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
