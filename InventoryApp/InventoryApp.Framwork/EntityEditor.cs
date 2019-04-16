using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.Framwork
{
    public class EntityEditor<TEntity> : ViewBase where TEntity : class, new()
    {
        public List<EntityEditorControl> createdControls = new List<EntityEditorControl>();
        public TEntity Entity { get; set; }

        public TEntity EntityCopy;
        public EntityEditor()
        {
            Entity = new TEntity();
            AddAction("تایید", btn => CloseView(DialogResult.OK));
            AddAction("صرفنظر", btn =>
            {
                var entityProperty = typeof(TEntity).GetProperties();
                CloseView(DialogResult.Cancel);
                foreach (var property in entityProperty)
                {
                    property.SetValue(Entity, property.GetValue(EntityCopy));
                }
            });
            Load += (sender, e) =>
            {
                EntityCopy = new TEntity();
                var entityProperty = typeof(TEntity).GetProperties();
                foreach (var property in entityProperty)
                {
                    property.SetValue(EntityCopy, property.GetValue(Entity));
                }
            };

        }
        protected TextBox TextBox<Tproperty>(Expression<Func<TEntity, Tproperty>> selector, string title, bool multiline = false)
        {
            var expressionHandler = new ExpressionHandler();
            var label = new Label();
            label.Text = title;
            var textbox = new TextBox();
            textbox.DataBindings.Add("Text", Entity, expressionHandler.GetPropertyName(selector));
            this.Controls.Add(label);
            this.Controls.Add(textbox);
            textbox.Left = 20;
            textbox.Top = 10;
            textbox.Width = 200;
            if (multiline)
            {
                textbox.Multiline = true;
                textbox.ScrollBars = ScrollBars.Vertical;
                textbox.Height = 150;
            }
            createdControls.Add(new EntityEditorControl
            {
                Label = label,
                Control = textbox,
                Priority = createdControls.Count + 1,
            });
            return textbox;
        }
        protected TextBox TextBox(string title, object tag = null, bool multiline = false)
        {
            var label = new Label();
            label.Text = title;
            label.Tag = tag;
            var textbox = new TextBox();
            textbox.Tag = tag;
            this.Controls.Add(label);
            this.Controls.Add(textbox);
            textbox.Left = 20;
            textbox.Top = 10;
            textbox.Width = 200;
            if (multiline)
            {
                textbox.Multiline = true;
                textbox.ScrollBars = ScrollBars.Vertical;
                textbox.Height = 150;
            }
            createdControls.Add(new EntityEditorControl
            {
                Label = label,
                Control = textbox,
                Priority = createdControls.Count + 1,
            });
            return textbox;
        }

        protected ComboBox ComboBox<TProperty, TComboItem>(Expression<Func<TEntity, TProperty>> selector, string title, List<TComboItem> items,
            Expression<Func<TComboItem, string>> displaySelector, Expression<Func<TComboItem, TProperty>> ValueSelector)
        {
            var expressionHandler = new ExpressionHandler();
            var label = new Label();
            label.Text = title;
            var combobox = new ComboBox();
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox.DataBindings.Add("SelectedValue", Entity, expressionHandler.GetPropertyName(selector));
            combobox.DataSource = items;
            combobox.DisplayMember = expressionHandler.GetPropertyName(displaySelector);
            combobox.ValueMember = expressionHandler.GetPropertyName(ValueSelector);
            this.Controls.Add(label);
            this.Controls.Add(combobox);
            createdControls.Add(new EntityEditorControl
            {
                Label = label,
                Control = combobox,
                Priority = createdControls.Count + 1,
            });
            return combobox;
        }
        protected ComboBox TrueFalseComboBox(Expression<Func<TEntity, bool>> selector, string title)
        {
            List<ComboItem<bool>> items = new List<ComboItem<bool>>();
            items.Add(new ComboItem<bool> { Display = "بله", Value = true });
            items.Add(new ComboItem<bool> { Display = "خیر", Value = false });
            return ComboBox(selector, title, items, item => item.Display, item => item.Value);
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
        protected void RemoveControls(Control control)
        {
            var t=createdControls.Where(p => p.Control.Tag== control.Tag).ToList();
            foreach (var item in t)
            {
                createdControls.Remove(item);
            }
            
        }
    }
    public class EntityEditorControl
    {
        public Label Label { get; set; }
        public Control Control { get; set; }
        public int Priority { get; set; }
    }

    public class ComboItem<Tvalue>
    {
        public string Display { get; set; }
        public Tvalue Value { get; set; }
    }
}
