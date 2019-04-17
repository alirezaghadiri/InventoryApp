using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.WinUi.view.Inventory
{
    public partial class InventoryReport : Form
    {
        RepositortAbstracts.IProduct pro;
        RepositortAbstracts.IInventory invs;
        RepositortAbstracts.IProductCategory ProCat;
        RepositortAbstracts.IInventoryInsHeader invh;
        RepositortAbstracts.IInventoryInsDeatil invd;

        RepositortAbstracts.IInventoryOutsHeader Outh;
        RepositortAbstracts.IInventoryOutsDeatil Outd;

        public InventoryReport()
        {
            pro = new Repositories.ProductRepository();
            invs = new Repositories.InventoryRepository();
            ProCat = new Repositories.ProductCategoryRepository();
            invh = new Repositories.InventoryInsHeaderRepository();
            invd = new Repositories.InventoryInsDeatilRepository();
            Outh = new Repositories.InventoryOutsHeaderRepository();
            Outd = new Repositories.InventoryOutsDeatilRepository();
            InitializeComponent();
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            comboInventory.DataSource = invs.GetAll();
            comboInventory.DisplayMember = "Title";
            comboInventory.ValueMember = "InventoryId";
            comboInventory.SelectedIndexChanged += ComboInventory_SelectedIndexChanged;

            comoboCategory.DataSource = ProCat.GetByInventory((int)comboInventory.SelectedValue);
            comoboCategory.DisplayMember = "Title";
            comoboCategory.ValueMember = "ProductCategoryId";
            comoboCategory.SelectedIndexChanged += ComoboCategory_SelectedIndexChanged;
            lblinfo.Text = report((int)comoboCategory.SelectedValue);
        }

        private void ComoboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)((ComboBox)sender).SelectedValue;
            lblinfo.Text = report(id);
        }

        private void ComboInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            comoboCategory.DataSource = ProCat.GetByInventory((int)comboInventory.SelectedValue);
            comoboCategory.DisplayMember = "Title";
            comoboCategory.ValueMember = "ProductCategoryId";
        }

        public string report(int categoryId)
        {
            List<Entities.Product> Pdata = new List<Entities.Product>();
            Pdata = pro.GetAll(categoryId).ToList();
            decimal TotalUse = 0;
            foreach (var item in Pdata)
            {
                TotalUse+=pro.GetAmount(item.ProductId);
            }
            decimal Capacity = ProCat.Find(categoryId).Capacity;

            string info = string.Empty;
            info += "ظرفیت کل : " + Capacity + Environment.NewLine;
            info += "ظرفیت استفاده شده : " + TotalUse + Environment.NewLine;
            info += "ظرفیت آزاد : " + (Capacity- TotalUse) + Environment.NewLine;

            info += "کالا ها :" + Environment.NewLine;
            foreach (var item in Pdata)
            {
                    info += "  " + item.Title + "  مقدار ("+ pro.GetAmount(item.ProductId)+")";
            }
            return info;
        }
    }
}
