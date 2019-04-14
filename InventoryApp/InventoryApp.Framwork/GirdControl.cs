﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.Framwork
{
    
   public class GirdControl<TModel>
    {
        DataGridView grid;
        BindingSource bindingSource;
        public GirdControl(Control container)
        {
            grid = new DataGridView();
            container.Controls.Add(grid);
            grid.Dock = DockStyle.Fill;
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToOrderColumns = true;
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public GirdControl<TModel> AddTextBoxColumn<TProperty>(Expression<Func<TModel,TProperty>> selector,string title)
        {
            var propertyName = new ExpressionHandler().GetPropertyName(selector);
            grid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = title,
                DataPropertyName = propertyName,
            });
            return this;
        }
        public GirdControl<TModel> SetDataSource(IEnumerable<TModel> dataSource)
        {
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataSource;
            bindingSource.ResetBindings(true);
            return this;
        }
        public void ResetBindings()
        {
            bindingSource?.ResetBindings(true);
        }
        public void RemoveCurrent()
        {
            bindingSource.ResetCurrentItem();
            ResetBindings();
        }
        public TModel CurrentItem
        {
            get
            {
                return (TModel)bindingSource?.Current;
            }
        }
    }
}
