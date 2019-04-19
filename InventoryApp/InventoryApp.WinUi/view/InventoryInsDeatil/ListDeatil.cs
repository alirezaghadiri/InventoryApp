using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.WinUi.view.InventoryInsDeatil
{
    public partial class ListDeatil : Form
    {
        public int Id ;
        public int IsOut;
        RepositortAbstracts.IProduct pro;
        RepositortAbstracts.IInventory inv;
        RepositortAbstracts.IInventoryInsDeatil ind;
        RepositortAbstracts.IInventoryInsHeader inh;
        RepositortAbstracts.IInventoryOutsDeatil outd;
        RepositortAbstracts.IInventoryOutsHeader outh;
        RepositortAbstracts.IInventoryInsType inT;
        RepositortAbstracts.IInventoryOutsType outT;

        public ListDeatil(int id,int IsOut)
        {
            InitializeComponent();
            this.Id = id;
            this.IsOut = IsOut;

            pro = new Repositories.ProductRepository();
            inv = new Repositories.InventoryRepository();
            ind = new Repositories.InventoryInsDeatilRepository();
            inh = new Repositories.InventoryInsHeaderRepository();
            outd = new Repositories.InventoryOutsDeatilRepository();
            outh = new Repositories.InventoryOutsHeaderRepository();
            inT = new Repositories.InventoryInsTypeRepository();
            outT = new Repositories.InventoryOutsTypeRepository();
        }

        private void ListDeatil_Load(object sender, EventArgs e)
        {
            if (IsOut == 0)
            {
                Entities.InventoryInsHeader header=inh.Find(Id);
                lblType.Text = inT.Find(header.TypeId).Title;
                lbldDate.Text = header.Date.ToString();
                lblInventoryTitle.Text = inv.Find(header.InventoryId).Title;
                lblProducts.Text = string.Empty;
                foreach (var item in ind.GetAll().Where(p => p.InventoryInsHeaderId == header.InventoryInsHeaderId))
                {
                    lblProducts.Text += "نام کالا :      \t" + item.prodocut.Title + " مقدار : \t" + item.Amount + " \t" + item.prodocut.Unit.Title + Environment.NewLine;
                }

            }
            else
            {
                Entities.InventoryOutsHeader header = outh.Find(Id);
                lblType.Text = outT.Find(header.TypeId).Title;
                lbldDate.Text = header.Date.ToString();
                lblInventoryTitle.Text = inv.Find(header.InventoryId).Title;
                lblProducts.Text = string.Empty;
                foreach (var item in header.InventoryOutsDeatiles)
                {
                    lblProducts.Text += "نام کالا :      \t" + item.prodocut.Title + " مقدار : \t" + item.Amount + " " +item.prodocut.ProductUnitId+ Environment.NewLine;
                }
            }
        }
    }
}
