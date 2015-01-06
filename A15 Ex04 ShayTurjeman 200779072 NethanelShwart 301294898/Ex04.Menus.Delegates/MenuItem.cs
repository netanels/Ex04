using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public delegate void MenuItemSelectedHandler();

    public class MenuItem
    {
        public event MenuItemSelectedHandler Selected;

        private readonly string r_Name;
        private List<MenuItem> m_SubItems;

        internal MenuItem(string i_MenuItemName)
        {
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
            MenuItem newMenuItem = new MenuItem(i_MenuItemName);
            if (!HasSubItems)
            {
                m_SubItems = new List<MenuItem>();
                MenuItem newSubMenuItem = new MenuItem(MenuLogic.eSpecialMenuItemsValues.Back.ToString());

                m_SubItems.Add(newSubMenuItem);
            }
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
                OnSelected();
            }
        }

        protected virtual void OnSelected()
        {
            if (Selected != null)
            {
                Selected.Invoke();
            }
        }
    }
}