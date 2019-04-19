using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryApp.Repositories;
using InventoryApp.RepositortAbstracts;

namespace InventoryApp.WinUi
{
    public partial class MainForm : Framwork.MainFormBase
    {
        Framwork.GirdControl<QueueDetials> grid;
        RepositortAbstracts.IInventoryInsHeader inh;
        RepositortAbstracts.IInventoryOutsHeader outh;


        public MainForm()
        {
            InitializeComponent();
            TypesRegistry = new IOC.TypesResgistry();
            var menu = addmenu("اطلاعات پایه", null, Keys.None, null);


            var menuBaseInfo = menu.addmenu("شرکت", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Corporation.List>(null, true));

            menuBaseInfo = menu.addmenu("انبار", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Inventory.List>(null, true));

            var menuProdocut = menu.addmenu("محصولات", null, Keys.None, null);
            menuProdocut.addmenu("محصولات", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Product.List>(null, true));
            menuProdocut.addSeparator();
            menuProdocut.addmenu("واحداندازه گیری", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.ProductUnit.List>(null, true));
            menuProdocut.addmenu("دسته بندی محصولات", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Category.List>(null, true));

            var menuRepoType = menu.addmenu("رسید", null, Keys.None, null);
            menuRepoType.addmenu("تعریف نوع رسید ورودی", null, Keys.None, (obj, e) =>
            {
                viewEngine.ViewInForm<view.InventoryInsType.List>(null, true);
                MainForm_Load(null, null);
            });
            menuRepoType.addmenu("تعریف نوع رسید خروجی", null, Keys.None, (obj, e) =>
            {
                viewEngine.ViewInForm<view.InventoryOutsType.List>(null, true);
                MainForm_Load(null, null);
            });

            menu.addSeparator();
            menu.addmenu("خروج", null, Keys.None, (obj, e) => Application.Exit());


            var menu1 = addmenu("عملیات", null, Keys.None, null);
            menu1.addmenu("ورود", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.InventoryInsHeader.List>(null, true));

            menu1.addmenu("خروج", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.InventoryOutsHeader.List>(null, true));

            var menu2 = addmenu("گزارش", null, Keys.None, null);
            menu2.addmenu("انبار", null, Keys.None, (obj, e) =>
            {
                view.Inventory.InventoryReport ir = new view.Inventory.InventoryReport();
                ir.ShowDialog();
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            inh = new Repositories.InventoryInsHeaderRepository();
            outh = new Repositories.InventoryOutsHeaderRepository();
            grid = new Framwork.GirdControl<QueueDetials>(_panel);
            grid.AddTextBoxColumn(p => p.InventoryInsHeaderId, "شناسه");
            grid.AddTextBoxColumn(p => p.Title, "عنوان");
            grid.AddTextBoxColumn(p => p.TypeId, "نوع رسید");
            grid.AddTextBoxColumn(p => p.InventoryType, "ورودی / خروجی");
            grid.AddTextBoxColumn(p => p.Date, "تاریخ");
            grid.AddButtonColumn("جزییات", row =>
            {
                view.InventoryInsDeatil.ListDeatil ld = new view.InventoryInsDeatil.ListDeatil((int)row.Cells[0].Value, (int)row.Cells[3].Value);
                ld.ShowDialog();
            });
            grid.AddButtonColumn("تایید", row =>
             {
                 if (inh.Accept((int)row.Cells[0].Value))
                 {
                     MainForm_Load(null, null);
                     MessageBox.Show("با موفقیت انجام شد", "پیام سیستم");
                 }
                 else
                 {
                     MessageBox.Show("مشکل در تایید", "پیام سیستم");
                 }
             });
           
            List<QueueDetials> listData = new List<QueueDetials>();
            foreach (var item in inh.GetAll(false))
            {
                listData.Add(new QueueDetials()
                {
                    InventoryInsHeaderId = item.InventoryInsHeaderId,
                    InventoryType = 0,
                    InventoryId = item.InventoryId,
                    TypeId = item.TypeId,
                    Title = item.Title,
                    Date = item.Date,
                });
            }
            foreach (var item in outh.GetAll(false))
            {
                listData.Add(new QueueDetials()
                {
                    InventoryInsHeaderId = item.InventoryOutsHeaderId,
                    InventoryType = 1,
                    InventoryId = item.InventoryId,
                    TypeId = item.TypeId,
                    Title = item.Title,
                    Date = item.Date,
                });
            }
            if(listData!=null)
                grid.EditMode = DataGridViewEditMode.EditOnEnter;
            grid.SetDataSource(listData.OrderBy(p => p.Date));
        }


    }
    public class QueueDetials
    {
        public int InventoryInsHeaderId { get; set; }
        public int InventoryType { get; set; }
        public int InventoryId { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
