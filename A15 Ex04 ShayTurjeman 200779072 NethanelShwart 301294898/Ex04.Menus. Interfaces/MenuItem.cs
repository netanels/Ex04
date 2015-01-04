using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces.Interfaces;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuItem
    {
        private readonly IMenuActivation r_MenuActivation;
        private readonly IMenuItem r_FatherMenuItem;
        private readonly string r_Name;
        private List<IMenuItem> m_SubItems;

        string IMenuItem.Name
        {
            get { return r_Name; }
        }

        IMenuItem IMenuItem.FatherMenuItem
        {
            get { return r_FatherMenuItem; }
        }

        List<IMenuItem> IMenuItem.SubItems
        {
            get { return m_SubItems; }
        }

        internal MenuItem(string i_MenuItemName, IMenuActivation i_MenuActivation, IMenuItem i_FatherMenuItem)
        {
            r_MenuActivation = i_MenuActivation;
            r_FatherMenuItem = i_FatherMenuItem;
            r_Name = i_MenuItemName;
        }

        public MenuItem AddItem(string i_MenuItemName)
        {
            if (!HasSubItems)
            {
                m_SubItems = new List<IMenuItem>();
                m_SubItems.Add(new MenuItem(MenuLogic.eSpecialValues.Back.ToString(), r_MenuActivation, r_FatherMenuItem));
            }
            MenuItem newMenuItem = new MenuItem(i_MenuItemName, r_MenuActivation, this);
            m_SubItems.Add(newMenuItem);
            return newMenuItem;
        }

        internal void ItemSelected()
        {
            if (HasSubItems)
            {
                MenuLogic.SelectItemsLogic(this);
            }
            else
            {
                r_MenuActivation.MenuItemSelected(r_Name);
            }
        }

        internal bool HasSubItems
        {
            get { return m_SubItems != null; }
        }
    }
}
