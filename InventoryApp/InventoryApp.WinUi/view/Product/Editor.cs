﻿using System;
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
        RepositortAbstracts.IProductParameterValue Pvalue;
        public Dictionary<Entities.ProductParameter,TextBox> parameterControls = new Dictionary<Entities.ProductParameter,TextBox>();
        public Editor(RepositortAbstracts.IProductCategory catrepo, RepositortAbstracts.IProductUnit unit, RepositortAbstracts.IProductParameter paramsRepo, RepositortAbstracts.IProductParameterValue Pvalue)
        {
            this.catrepo = catrepo;
            this.unit = unit;
            this.Pvalue = Pvalue;
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
            AddParameter(Entity.ProductCategoryId);
            AdjustControls();
            base.OnLoad(e); 
        }

        public void AddParameter(int ProductCategoryId)
        {
            if (Entity.ProductCategoryId > 0)
            {
                var param = paramsRepo.GetAll(Entity.ProductCategoryId);
                var value = Pvalue.GetAll(Entity.ProductId);
                foreach (var item in param)
                {
                    var txt = TextBox(item.Title, "param");
                    if(value.Count!=0)
                    txt.Text = value.First(p => p.ProductParameterId == item.ProductParameterId).Value;
                    parameterControls.Add(item, txt);
                }
            }
        }
        private void Com_SelectedIndexChanged(object sender, EventArgs e)
        {
            var control = this.Controls.Cast<Control>().Where(c => (string)c.Tag == "param").ToList();
            foreach (var item in control)
            {
                this.Controls.Remove(item);
                RemoveControls(item);
            }
            parameterControls.Clear();
            Entity.ProductCategoryId =(int)((ComboBox)sender).SelectedValue;
            AddParameter(Entity.ProductCategoryId);
            AdjustControls();
        }
    }
}
