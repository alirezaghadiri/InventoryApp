using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.WinUi.view.InventoryInsHeader
{
    public partial class InventoryInsHeader : Form
    {
        Entities.Product _product;
        RepositortAbstracts.IProduct pro;
        RepositortAbstracts.IInventory invs;
        RepositortAbstracts.IInventoryInsType type;
        RepositortAbstracts.IInventoryInsHeader invh;
        RepositortAbstracts.IInventoryInsDeatil invd;
        Framwork.GirdControl<Entities.InventoryInsDeatil> grid;
        public List<Entities.InventoryInsDeatil> ListDeatil = new List<Entities.InventoryInsDeatil>();
        public InventoryInsHeader()
        {
            pro = new Repositories.ProductRepository();
            invs = new Repositories.InventoryRepository();
            type = new Repositories.InventoryInsTypeRepository();
            invh = new Repositories.InventoryInsHeaderRepository();
            invd = new Repositories.InventoryInsDeatilRepository();
            InitializeComponent();
        }

        private void InventoryInsHeader_Load(object sender, EventArgs e)
        {
            comboInventory.DataSource = invs.GetAll();
            comboInventory.DisplayMember = "Title";
            comboInventory.ValueMember = "InventoryId";

            combotype.DataSource = type.GetAll();
            combotype.DisplayMember = "Title";
            combotype.ValueMember = "InventoryInsTypeId";
            grid = new Framwork.GirdControl<Entities.InventoryInsDeatil>(PanelProducts);
            grid.AddTextBoxColumn(d => d.ProductId, "کد کالا");
            grid.AddTextBoxColumn(d => d.Amount, "مقدار");
            grid.SetDataSource(ListDeatil);
        }

        private void btnchose_Click(object sender, EventArgs e)
        {
            IOC.TypesResgistry tr = new IOC.TypesResgistry();
            Framwork.ViewEngine f = new Framwork.ViewEngine(tr);
            var result = f.ViewInForm<view.Product.Select>(null, true);
            if (result.DialogResult == DialogResult.OK)
            {
                _product = result.product;
                txtProduct.Text = _product.Title;
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (txtamount.Text == string.Empty && txttitle.Text == string.Empty)
                MessageBox.Show("مقادیر را وارذ کنید", "پیام سیستم");
            else
            {
                decimal amount;
                if (decimal.TryParse(txtamount.Text, out amount))
                {
                    if (IsCapacity(_product.ProductId, _product.ProductCategoryId, amount))
                    {
                        var InentoryDeatiles = new Entities.InventoryInsDeatil()
                        {
                            Amount = amount,
                            ProductId = _product.ProductId,
                        };
                        grid.AddItem(InentoryDeatiles);
                        grid.ResetBindings();
                        txtamount.Text = string.Empty;
                        txttitle.Text = string.Empty;
                        txtProduct.Text = string.Empty;
                        txtdsc.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("انبار ظرفیت ندارد", "پیام سیستم");
                    }

                }
                else
                {
                    MessageBox.Show("مقادیر وارد شده نامتعبراست", "پیام سیستم");
                }






            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            bool result = true;
            foreach (var item in ListDeatil)
                if (result != invd.Add(item))
                {
                    result = false;
                    break;
                }
            if (result)
            {
                invh.Add(new Entities.InventoryInsHeader
                {
                    InventoryId = (int)comboInventory.SelectedValue,
                    TypeId = (int)combotype.SelectedValue,
                    Title = txttitle.Text,
                    Description = txtdsc.Text,
                    Date = DateTime.Now,
                });
                MessageBox.Show("با موفقیت ثبت شد", "پیام سیستم");
            }
            else
                MessageBox.Show("مشکل در ثبت به وجود امد", "پیام سیستم");
        }

        public bool IsCapacity(int ProductId, int CategoryId, decimal Amonut)
        {
            var ProductExist = invd.GetAmount(ProductId);
            var InventoryCapacity = pro.Capacity(CategoryId);

            var NewProductExist = ProductExist + Amonut;

            if (NewProductExist <= InventoryCapacity)
                return true;
            else
                return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            grid.RemoveCurrent();
            grid.ResetBindings();
        }
    }
}
