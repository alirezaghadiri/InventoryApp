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


            var menuBaseInfo = menu.addmenu("شرکت", null, Keys.None, null);
            menuBaseInfo.addmenu("افزودن", null, Keys.None, (obj, e) => {
                var result = viewEngine.ViewInForm<view.Corporation.Editor>(null, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    ICorporation corporation = new CorporationRepository();
                    if (corporation.Add(result.Entity))
                    {
                        MessageBox.Show("شرکت با موفقیت ثبت شد", "پیام سیستم");
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ثبت شرکت به وجود آمد", "پیام سیستم");
                    }
                }
            });
            menuBaseInfo.addmenu("نمایش", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Corporation.List>(null, true));
            menuBaseInfo.addmenu("ویرایش", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Corporation.List>(null, true));
            menuBaseInfo.addmenu("حذف", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Corporation.List>(null, true));

            menuBaseInfo = menu.addmenu("انبار", null, Keys.None, null);
            menuBaseInfo.addmenu("افزودن", null, Keys.None, (obj, e) => 
            {
                var result = viewEngine.ViewInForm<view.Inventory.Editor>(null, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    IInventory inventory = new InventoryRepository();
                    if (inventory.Add(result.Entity))
                    {
                        MessageBox.Show("انبار با موفقیت ثبت شد", "پیام سیستم");
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ثبت انبار به وجود آمد", "پیام سیستم");
                    }
                }
            });
            menuBaseInfo.addmenu("نمایش", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Inventory.List>(null, true));
            menuBaseInfo.addmenu("ویرایش", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Inventory.List>(null, true));
            menuBaseInfo.addmenu("حذف", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.Inventory.List>(null, true));

            menuBaseInfo = menu.addmenu("واحداندازه گیری", null, Keys.None, null);
            menuBaseInfo.addmenu("افزودن", null, Keys.None, (obj, e) =>
            {
                var result = viewEngine.ViewInForm<view.ProductUnit.Editor>(null, true);
                if (result.DialogResult == DialogResult.OK)
                {
                    IProductUnit productUnit = new ProductUnitRepository();
                    if (productUnit.Add(result.Entity))
                    {
                        MessageBox.Show("واحد با موفقیت ثبت شد", "پیام سیستم");
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ثبت واحد به وجود آمد", "پیام سیستم");
                    }
                }
            });
            menuBaseInfo.addmenu("نمایش", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.ProductUnit.List>(null, true));
            menuBaseInfo.addmenu("ویرایش", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.ProductUnit.List>(null, true));
            menuBaseInfo.addmenu("حذف", null, Keys.None, (obj, e) => viewEngine.ViewInForm<view.ProductUnit.List>(null, true));

            menu.addSeparator();
            menu.addmenu("خروج", null, Keys.None, (obj, e) => Application.Exit());
        }
        
    }
}
