using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.Product
{
    public class Editor :Framwork.EntityEditor<Entities.Product>
    {
        RepositortAbstracts.IProductCategory catrepo;
        RepositortAbstracts.IProductUnit unit;
        RepositortAbstracts.IProductParameter paramsRepo;
        public Editor(RepositortAbstracts.IProductCategory catrepo, RepositortAbstracts.IProductUnit unit, RepositortAbstracts.IProductParameter paramsRepo)
        {
            this.catrepo = catrepo;
            this.unit = unit;
            this.paramsRepo = paramsRepo;
        }
        protected override void OnLoad(EventArgs e)
        {
            var com=ComboBox(p => p.ProductCategoryId, "دسته بندی", catrepo.GetAll().ToList(), p => p.Title, p => p.ProductCategoryId);
            com.SelectedIndexChanged += Com_SelectedIndexChanged;
            TextBox(p => p.Code,"کد");
            TextBox(p => p.Title, "عنوان");
            ComboBox(p => p.ProductUnitId, "واحد اندازه گیری", unit.GetAll().ToList(), p => p.Title, p => p.ProductUnitId);
            TextBox(p => p.Description, "توضیحات",true);
            if (Entity.ProductCategoryId > 0)
            {
                var param = paramsRepo.GetAll(Entity.ProductCategoryId);
                foreach (var item in param)
                {
                    var txt = TextBox(item.Title, "param");
                }
            }
            AdjustControls();
            base.OnLoad(e); 
        }

        private void Com_SelectedIndexChanged(object sender, EventArgs e)
        {
            var control = this.Controls.Cast<Control>().Where(c => (string)c.Tag == "param").ToList();
            foreach (var item in control)
            {
                this.Controls.Remove(item);
                RemoveControls(item);
            }
            
            Entity.ProductCategoryId =(int)((ComboBox)sender).SelectedValue;

            if (Entity.ProductCategoryId > 0)
            {
                var param = paramsRepo.GetAll(Entity.ProductCategoryId);
                foreach (var item in param)
                {
                    var txt = TextBox(item.Title);
                    txt.Tag = "param";
                }
            }
            AdjustControls();
        }
    }
}
