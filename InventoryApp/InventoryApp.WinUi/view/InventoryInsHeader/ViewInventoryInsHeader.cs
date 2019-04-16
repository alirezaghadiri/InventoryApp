using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.WinUi.view.InventoryInsHeader
{
    public partial class ViewInventoryInsHeader : Framwork.ViewBase
    {
        RepositortAbstracts.IInventory invs;
        RepositortAbstracts.IInventoryInsType type;
        Framwork.GirdControl<Entities.InventoryInsDeatil> grid;
        public List<Entities.InventoryInsDeatil> ListDeatil = new List<Entities.InventoryInsDeatil>();
        public List<EntityEditorControl> createdControls = new List<EntityEditorControl>();
        public ViewInventoryInsHeader(RepositortAbstracts.IInventory invs, RepositortAbstracts.IInventoryInsType type)
        {
            this.invs = invs;
            this.type = type;
            InitializeComponent();

            //var comboInventory = new ComboBox();
            //comboInventory.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboInventory.DataSource = invs.GetAll();
            //comboInventory.DisplayMember = "Title";
            //comboInventory.ValueMember = "InventoryId";
            //var lablInventory = new Label();
            //lablInventory.Text = "انبار";
            //createdControls.Add(new EntityEditorControl()
            //{
            //    Label = lablInventory,
            //    Control = comboInventory,
            //    Priority = createdControls.Count + 1,
            //});
            //var combotype = new ComboBox();
            //combotype.DropDownStyle = ComboBoxStyle.DropDownList;
            //combotype.DataSource = type.GetAll();
            //combotype.DisplayMember = "Title";
            //combotype.ValueMember = "InventoryInsTypeId";
            //var labltype = new Label();
            //labltype.Text = "نوع رسید";
            //createdControls.Add(new EntityEditorControl()
            //{
            //    Label = labltype,
            //    Control = combotype,
            //    Priority = createdControls.Count + 1,
            //});
            //AdjustControls();

            //grid =new Framwork.GirdControl<Entities.InventoryInsDeatil>(bottompanel);
            //grid.AddTextBoxColumn(d => d.ProductId, "کد کالا");
            //grid.AddTextBoxColumn(d => d.Amount, "مقدار");
            //grid.SetDataSource(ListDeatil);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewEngine.ViewInForm<view.Product.Select>();
        }
        protected void AdjustControls()
        {
            ((Form)this.Parent).Width = 800;
            var currentTop = 10;
            var maximumlabalwith = createdControls.Select(c => c.Label).Max(l => l.Width);
            foreach (var item in createdControls.OrderBy(c => c.Priority))
            {
                item.Label.Left = (this.Width - item.Label.Width) - 10;
                item.Label.Top = (currentTop + 3);
                item.Control.Width = (this.Width) - 10 - maximumlabalwith - 20;
                item.Control.Left = 10;
                item.Control.Top = currentTop;
                currentTop += item.Control.Height + 10;
            }
          ((Form)this.Parent).Activated += (form, e) =>
          {
              createdControls.OrderBy(c => c.Priority).First().Control.Focus();
          };

            ((Form)this.Parent).Height = currentTop + 80;
        }
    }
    public class EntityEditorControl
    {
        public Label Label { get; set; }
        public Control Control { get; set; }
        public int Priority { get; set; }
    }
}
