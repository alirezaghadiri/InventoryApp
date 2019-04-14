using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.Framwork
{
    public partial class ViewBase : UserControl
    {
        public ViewBase()
        {
            InitializeComponent();
        }
       public DialogResult DialogResult { get; set; }
        public string ViewTitle { get; set; }

        public virtual string ViewIdentifier
        {
            get
            {
                return this.GetType().FullName;
            }
        }
        protected Button AddAction(string title, Action<Button> onClick)
        {
            if (!ButtonBar.Visible)
                ButtonBar.Visible = true;
            var button = new Button();
            button.Text = title;
            button.Click += (obj, e) =>
            {
                onClick(button); ;
            };
            var totalButtons = ButtonBar.Controls.Count;
            var left = ((totalButtons + 1) * 5) + (totalButtons * 85);
            button.Location = new Point(left, 7);
            ButtonBar.Controls.Add(button);
            return button;
        }
        protected void CloseView(DialogResult? dialogResult=null)
        {
            viewEngine.CloseView(this,dialogResult);
        }
        public ViewEngine viewEngine { get; internal set; }
        
    }
}
