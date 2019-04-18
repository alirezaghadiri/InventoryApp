using System;
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
        public GirdControl<TModel> AddDropDownColumn<TProperty, TComboItem>(Expression<Func<TModel, TProperty>> selector, string title, List<TComboItem> items,
          Expression<Func<TComboItem, string>> displaySelector, Expression<Func<TComboItem, TProperty>> ValueSelector)
        {
            var expressionHandler = new ExpressionHandler();
            var propertyName = new ExpressionHandler().GetPropertyName(selector);
            grid.Columns.Add(new DataGridViewComboBoxColumn()
            {
                HeaderText = title,
                DataSource = items,
                DisplayMember = expressionHandler.GetPropertyName(displaySelector),
                ValueMember = expressionHandler.GetPropertyName(ValueSelector),
                DataPropertyName = propertyName,

            });
            return this;
        }
        public GirdControl<TModel> AddDropDownColumnTrueFalse<TProperty>(Expression<Func<TModel,TProperty>> selector, string title)
        {
            var propertyName = new ExpressionHandler().GetPropertyName(selector);
            List<DatagridviewComboItem<bool>> items = new List<DatagridviewComboItem<bool>>();
            items.Add(new DatagridviewComboItem<bool> { Display = "بله", Value = true });
            items.Add(new DatagridviewComboItem<bool> { Display = "خیر", Value = false });
            grid.Columns.Add(new DataGridViewComboBoxColumn()
            {
                HeaderText = title,
                DataSource = items,
                DisplayMember = "Display",
                ValueMember = "Value",
                DataPropertyName = propertyName,
            });
            
            return this;
        }

        public GirdControl<TModel> SetDataSource(IEnumerable<TModel> dataSource)
        {
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataSource;
            grid.DataSource = bindingSource;
            bindingSource.ResetBindings(true);
            return this;
        }
        public void ResetBindings()
        {
            bindingSource?.ResetBindings(true);
            grid.DataSource = bindingSource;

        }
        public void RemoveCurrent()
        {
            bindingSource.RemoveCurrent();
            ResetBindings();
        }
        public void AddItem(TModel model)
        {
            bindingSource.Add(model);
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
    public class DatagridviewComboItem<Tvalue>
    {
        public string Display { get; set; }
        public Tvalue Value { get; set; }
    }
}
