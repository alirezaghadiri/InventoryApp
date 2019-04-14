using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.Framwork
{
    public class ViewEngine
    {
        private StructureMap.Registry TypesRegistry;
        public ViewEngine(StructureMap.Registry TypesRegistry)
        {
            this.TypesRegistry = TypesRegistry; 
        }
        Dictionary<string, Form> openForm = new Dictionary<string, Form>();
        public T ViewInForm<T>(Action<T>initialzer=null, bool DisplayIsDialog = false) where T : ViewBase
        {
            var container = new StructureMap.Container(TypesRegistry);
            var viewInstance = container.GetInstance<T>();
            viewInstance.viewEngine = this;
            initialzer?.Invoke(viewInstance);
            if (openForm.ContainsKey(viewInstance.ViewIdentifier))
            {
                var currentform = openForm[viewInstance.ViewIdentifier];
                currentform.Activate();
                return (T)currentform.Controls.OfType<T>().First();
            }
            var form = new Form();
            form.Width = 800;
            form.Height = 600;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.RightToLeft = RightToLeft.Yes;
            form.Font = new System.Drawing.Font("Tahoma", 8);
            form.Text = viewInstance.ViewTitle;
            form.ShowInTaskbar = false;
            form.Controls.Add(viewInstance);
            form.FormClosed += ((obj, e) => openForm.Remove(viewInstance.ViewIdentifier));
            viewInstance.Dock = DockStyle.Fill;
            openForm.Add(viewInstance.ViewIdentifier, form);


            if (DisplayIsDialog)
                form.ShowDialog();
            else
                form.Show();

            return (T)viewInstance;
        }
       
        internal void CloseView(ViewBase viewBase, DialogResult? dialogResult = null)
        {
            if (openForm.ContainsKey(viewBase.ViewIdentifier))
            {
                if (dialogResult.HasValue)
                {
                    viewBase.DialogResult = dialogResult.Value;
                    openForm[viewBase.ViewIdentifier].DialogResult = dialogResult.Value;
                    if (!openForm[viewBase.ViewIdentifier].Modal)
                        openForm[viewBase.ViewIdentifier].Close();
                }
                else
                    openForm[viewBase.ViewIdentifier].Close();
                openForm.Remove(viewBase.ViewIdentifier);
            }
        }
    }
}
