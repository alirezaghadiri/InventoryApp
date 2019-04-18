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
        public MainForm()
        {
            InitializeComponent();
            TypesRegistry = new IOC.TypesResgistry();
            var menu = addmenu("اطلاعات پایه", null,Keys.None,null);


            var menuBaseInfo = menu.addmenu("شرکت", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Corporation.List>(null,true));
          
            menuBaseInfo = menu.addmenu("انبار", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Inventory.List>(null, true));

            var menuProdocut = menu.addmenu("محصولات", null, Keys.None, null);
            menuProdocut.addmenu("محصولات", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Product.List>(null, true));
            menuProdocut.addSeparator();
            menuProdocut.addmenu("واحداندازه گیری", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.ProductUnit.List>(null, true));
            menuProdocut.addmenu("دسته بندی محصولات", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Category.List>(null, true));

            var menuRepoType = menu.addmenu("رسید", null, Keys.None, null);
            menuRepoType.addmenu("تعریف نوع رسید ورودی", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.InventoryInsType.List>(null, true));
            menuRepoType.addmenu("تعریف نوع رسید خروجی", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.InventoryOutsType.List>(null, true));

            menu.addSeparator();
            menu.addmenu("خروج", null, Keys.None, (obj, e) => Application.Exit());


            var menu1 = addmenu("عملیات", null, Keys.None, null);
            menu1.addmenu("ورود", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.InventoryInsHeader.List>(null, true));

            menu1.addmenu("خروج", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.InventoryOutsHeader.List>(null, true));

            var menu2 = addmenu("گزارش", null, Keys.None, null);
            menu2.addmenu("انبار", null, Keys.None,(obj,e)=>{
                view.Inventory.InventoryReport ir = new view.Inventory.InventoryReport();
                ir.ShowDialog();
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        
    }
}
