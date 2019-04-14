using System;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryApp.Framwork
{
    public class MenuHandler
    {
        private ToolStripItemCollection item;
        public MenuHandler(ToolStripItemCollection item)
        {
            this.item = item;
        }
        public void addSeparator()
        {
            item.Add("-");
        }
        public MenuHandler addmenu(string title, Image img,Keys ShortcutKey, EventHandler evenhander)
        {
            var menu = (ToolStripMenuItem)item.Add(title, img, evenhander);
            menu.ShortcutKeys = ShortcutKey;
            return new MenuHandler(menu.DropDownItems);
        }
    }
}