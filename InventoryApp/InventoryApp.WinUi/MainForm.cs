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


            var menuBaseInfo = menu.addmenu("شرکت", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Corporation.List>(null, true));
          
            menuBaseInfo = menu.addmenu("انبار", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Inventory.List>(null, true));

            var menuProdocut = menu.addmenu("محصولات", null, Keys.None, null);
            menuProdocut.addmenu("واحداندازه گیری", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.ProductUnit.List>(null, true));
            menuProdocut.addmenu("دسته بندی محصولات", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Category.List>(null, true));

            menu.addSeparator();
            menu.addmenu("خروج", null, Keys.None, (obj, e) => Application.Exit());
        }
        
    }
}
