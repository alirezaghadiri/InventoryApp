﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.WinUi.view.InventoryOutsHeader
{
    public partial class InventoryOutsHeader : Form
    {
        public Entities.InventoryOutsHeader _InventoryOutsHeader;
        Entities.Product _product;
        RepositortAbstracts.IProduct pro;
        RepositortAbstracts.IInventory invs;
        RepositortAbstracts.IInventoryOutsType type;
        RepositortAbstracts.IProductCategory ProCat;
        RepositortAbstracts.IInventoryOutsHeader invh;
        RepositortAbstracts.IInventoryOutsDeatil invd;
        Framwork.GirdControl<Entities.InventoryOutsDeatil> grid;
        public List<Entities.InventoryOutsDeatil> ListDeatil = new List<Entities.InventoryOutsDeatil>();
        public InventoryOutsHeader()
        {
            pro = new Repositories.ProductRepository();
            invs = new Repositories.InventoryRepository();
            type = new Repositories.InventoryOutsTypeRepository();
            invh = new Repositories.InventoryOutsHeaderRepository();
            invd = new Repositories.InventoryOutsDeatilRepository();
            ProCat = new Repositories.ProductCategoryRepository();
            InitializeComponent();
        }
        private void InventoryOutsHeader_Load(object sender, EventArgs e)
        {
            comboInventory.DataSource = invs.GetAll();
            comboInventory.DisplayMember = "Title";
            comboInventory.ValueMember = "InventoryId";
            comboInventory.SelectedIndexChanged += ComboInventory_SelectedIndexChanged;



            comboCategory.DataSource = ProCat.GetByInventory((int)comboInventory.SelectedValue);
            comboCategory.DisplayMember = "Title";
            comboCategory.ValueMember = "ProductCategoryId";

            combotype.DataSource = type.GetAll();
            combotype.DisplayMember = "Title";
            combotype.ValueMember = "InventoryInsTypeId";
            grid = new Framwork.GirdControl<Entities.InventoryOutsDeatil>(PanelProducts);
            grid.AddTextBoxColumn(d => d.ProductId, "کد کالا");
            grid.AddTextBoxColumn(d => d.Amount, "مقدار");
            grid.SetDataSource(ListDeatil);
        }

        private void ComboInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboCategory.DataSource = ProCat.GetByInventory((int)comboInventory.SelectedValue);
            comboCategory.DisplayMember = "Title";
            comboCategory.ValueMember = "ProductCategoryId";
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
                MessageBox.Show("مقادیر را وارد کنید", "پیام سیستم");
            else
            {
                decimal amount;
                if (decimal.TryParse(txtamount.Text, out amount))
                {
                    object obj = invd.GetAmount(_product.ProductId);
                    if (obj is decimal)
                    {
                        var ProductExist = (decimal)obj;
                        var NewProductExist = ProductExist - amount;
                        if (NewProductExist >= 0)
                        {
                            var InentoryDeatiles = new Entities.InventoryOutsDeatil()
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
                invh.Add(new Entities.InventoryOutsHeader
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



        private void btnDelete_Click(object sender, EventArgs e)
        {
            grid.RemoveCurrent();
            grid.ResetBindings();
        }

        private void btnchose_Click_1(object sender, EventArgs e)
        {
            IOC.TypesResgistry tr = new IOC.TypesResgistry();
            Framwork.ViewEngine f = new Framwork.ViewEngine(tr);
            var result = f.ViewInForm<view.Product.Select>(editor =>
            {
                object id = comboCategory.SelectedValue;
                if (id is int)
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
                _product = result.product;
                txtProduct.Text = _product.Title;
            }
        }
    }
}
