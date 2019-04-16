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


            var menuBaseInfo = menu.addmenu("شرکت", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Corporation.List>());
          
            menuBaseInfo = menu.addmenu("انبار", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Inventory.List>());

            var menuProdocut = menu.addmenu("محصولات", null, Keys.None, null);
            menuProdocut.addmenu("محصولات", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Product.List>());
            menuProdocut.addSeparator();
            menuProdocut.addmenu("واحداندازه گیری", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.ProductUnit.List>());
            menuProdocut.addmenu("دسته بندی محصولات", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Category.List>());

            var menuRepoType = menu.addmenu("رسید", null, Keys.None, null);
            menuRepoType.addmenu("تعریف نوع رسید ورودی", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.InventoryInsType.List>());
            menuRepoType.addmenu("تعریف نوع رسید خروجی", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.InventoryOutsType.List>());

            menu.addSeparator();
            menu.addmenu("خروج", null, Keys.None, (obj, e) => Application.Exit());


            var menu1 = addmenu("عملیات", null, Keys.None, null);
            menu1.addmenu("ورود", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.InventoryInsHeader.ViewInventoryInsHeader>());
            menu1.addmenu("خروج", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Corporation.List>());
        }
        
    }
}
