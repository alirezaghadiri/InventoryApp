using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryApp.Framwork
{
    public partial class MainFormBase : Form
    {
        private MenuHandler menuhandler;
        private ViewEngine viewengine;

        public Panel _panel;
        public MainFormBase()
        {
            InitializeComponent();
            timertime.Tick += (obj, e) =>
            {
                toolStripStatusLabelTime.Text = DateTime.Now.ToString("dd MMM yyyy hh:mm:ss");
            };
            timertime.Interval = 1000;
            timertime.Start();


            menuhandler = new MenuHandler(menuStrip.Items);
            _panel = Mainpanel;
        }
        public ViewEngine viewEngine
        {
            get
            {
                if (viewengine == null)
                    viewengine = new ViewEngine(TypesRegistry);
                return viewengine;
            }
        }
        protected StructureMap.Registry TypesRegistry { get; set; }

        private void lblexit_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("آیا میخواهید خارج شوید", "پیام سیستم", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblintask_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        protected MenuHandler addmenu(string title, Image img,Keys ShortcutKey, EventHandler evenhander)
        {
            return menuhandler.addmenu(title, img, ShortcutKey, evenhander);
        }
        private void MainFormBase_Load(object sender, EventArgs e)
        {
            toolStripStatusLabeluser.Text = "کاربر جاری : " + System.Threading.Thread.CurrentPrincipal.Identity.Name;
        }

        public void Setstatus(string Massege)
        {
            toolStripStatusLabel.Text = Massege;
        }
    }
   
}
