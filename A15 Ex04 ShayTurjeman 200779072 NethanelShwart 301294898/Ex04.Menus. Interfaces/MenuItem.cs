using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private readonly IMenuActivation r_MenuActivation;
        private readonly string r_Name;
        private List<MenuItem> m_SubItems;

        internal MenuItem(string i_MenuItemName, IMenuActivation i_MenuActivation)
        {
            r_MenuActivation = i_MenuActivation;
            r_Name = i_MenuItemName;
        }

        public string Name
        {
            get { return r_Name; }
        }

        public bool HasSubItems
        {
            get { return m_SubItems != null; }
        }

        public MenuItem AddItem(string i_MenuItemName)
        {
            if (!HasSubItems)
            {
                m_SubItems = new List<MenuItem>();

                m_SubItems.Add(new MenuItem(MenuLogic.eSpecialMenuItemsValues.Back.ToString(), r_MenuActivation));
            }
            MenuItem newMenuItem = new MenuItem(i_MenuItemName, r_MenuActivation);
            m_SubItems.Add(newMenuItem);
            return newMenuItem;
        }

        internal void ItemSelectedLogic()
        {
            if (HasSubItems)
            {
                MenuLogic.SubItemsSelectedLogic(Name, m_SubItems);
            }
            else
            {
                r_MenuActivation.MenuItemSelected(r_Name);
            }
        }
    }
}