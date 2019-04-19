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
        public Entities.InventoryInsHeader _InventoryInsHeader;
        RepositortAbstracts.IProduct pro;
        RepositortAbstracts.IInventory invs;
        RepositortAbstracts.IProductCategory ProCat;
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
            ProCat = new Repositories.ProductCategoryRepository();
            InitializeComponent();
        }

        private void InventoryInsHeader_Load(object sender, EventArgs e)
        {
            comboInventory.DataSource = invs.GetAll();
            comboInventory.DisplayMember = "Title";
            comboInventory.ValueMember = "InventoryId";
            comboInventory.SelectedIndexChanged += ComboInventory_SelectedIndexChanged;

            comoboCategory.DataSource = ProCat.GetByInventory((int)comboInventory.SelectedValue);
            comoboCategory.DisplayMember = "Title";
            comoboCategory.ValueMember = "ProductCategoryId";
            comoboCategory.SelectedIndexChanged += ComoboCategory_SelectedIndexChanged;
            combotype.DataSource = type.GetAll();
            combotype.DisplayMember = "Title";
            combotype.ValueMember = "InventoryInsTypeId";
            grid = new Framwork.GirdControl<Entities.InventoryInsDeatil>(PanelProducts);
            grid.AddTextBoxColumn(d => d.ProductId, "کد کالا");
            grid.AddTextBoxColumn(d => d.Amount, "مقدار");
            grid.SetDataSource(ListDeatil);
        }

        private void ComoboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = (int)comoboCategory.SelectedValue;
                ICollection<Entities.Product> Source = pro.GetAll(id);
                if (Source.Count != 0)
                {
                    btnchose.Enabled = true;
                }
                else
                {
                    btnchose.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("خطا پیش آمده", "پیام سیستم");
            }
        }

        private void ComboInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = (int)comboInventory.SelectedValue;
                ICollection<Entities.ProductCategory> Source = ProCat.GetByInventory(id);

                if (Source.Count != 0)
                {
                    comoboCategory.DataSource = ProCat.GetByInventory(id);
                    comoboCategory.DisplayMember = "Title";
                    comoboCategory.ValueMember = "ProductCategoryId";
                    comoboCategory.Enabled = true;
                }
                else
                {
                    comoboCategory.DataSource = null;
                }
            }
            catch
            {
                MessageBox.Show("خطا پیش آمده", "پیام سیستم");
            }
        }

        private void btnchose_Click(object sender, EventArgs e)
        {
            IOC.TypesResgistry tr = new IOC.TypesResgistry();
            Framwork.ViewEngine f = new Framwork.ViewEngine(tr);
            var result = f.ViewInForm<view.Product.Select>(editor=>
            {
                object id = comoboCategory.SelectedValue;
                if(id is int)
                {
                    editor.categoryId = (int)id;
                }
                else
                {
                    return;
                }
                

            }, true);
            if (result.DialogResult == DialogResult.OK)
            {
                if (result.product != default(Entities.Product))
                {
                    _product = result.product;
                    txtProduct.Text = _product.Title;
                }
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
                    object obj = pro.GetAmount(_product.ProductId);
                    if (obj is decimal)
                    {
                        var ProductExist = (decimal)obj;
                        var InventoryCapacity = pro.Capacity(_product.ProductCategoryId);
                        var NewProductExist = ProductExist + amount;
                        if (NewProductExist <= InventoryCapacity)
                        {
                            var InentoryDeatiles = new Entities.InventoryInsDeatil()
                            {
                                Amount = amount,
                                ProductId = _product.ProductId,
                            };
                            grid.AddItem(InentoryDeatiles);
                            grid.ResetBindings();
                            txtamount.Text = string.Empty;

                        }
                        else
                            MessageBox.Show("انبار ظرفیت ندارد", "پیام سیستم");
                    }
                    else
                        MessageBox.Show("مشکل در بررسی ظرفیت", "پیام سیستم");
                }
                else
                    MessageBox.Show("مقادیر وارد شده نامتعبراست", "پیام سیستم");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            _InventoryInsHeader = new Entities.InventoryInsHeader
            {
                InventoryId = (int)comboInventory.SelectedValue,
                TypeId = (int)combotype.SelectedValue,
                Title = txttitle.Text,
                Description = txtdsc.Text,
                Date = DateTime.Now,
            };
            int result = invh.AddReturnId(_InventoryInsHeader);

            if (result == 0)
                MessageBox.Show("مشکل در ثبت به وجود امد", "پیام سیستم");
            else
            {
                foreach (var item in ListDeatil)
                {
                    item.InventoryInsHeaderId = result;
                    if (!invd.Add(item))
                    {
                        MessageBox.Show("مشکل در ثبت به وجود امد", "پیام سیستم");
                        break;
                    }

                }
                MessageBox.Show("با موفقیت ثبت شد", "پیام سیستم");
            }
            DialogResult = DialogResult.OK;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            grid.RemoveCurrent();
            grid.ResetBindings();
        }
    }
}
