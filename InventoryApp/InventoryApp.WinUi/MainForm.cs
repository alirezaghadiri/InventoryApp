using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.WinUi
{
    public partial class MainForm : Framwork.MainFormBase
    {
        public MainForm()
        {
            InitializeComponent();
            var menu = addmenu("اطلاعات پایه", null,Keys.None,null);
            var menuBaseInfo = menu.addmenu("شرکت", null, Keys.None, null);
            menuBaseInfo.addmenu("افزودن", null, Keys.None, null);
            menuBaseInfo.addmenu("نمایش", null, Keys.None, null);
            menuBaseInfo.addmenu("ویرایش", null, Keys.None, null);
            menuBaseInfo.addmenu("حذف", null, Keys.None, null);
        }
    }
}
