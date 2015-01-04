using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        internal event Delegates.BackMenuItemSelectedHandler BackSelected;
        internal event Delegates.SubMenuItemSelectedHandler SubItemSelected;
        public event Delegates.MenuItemSelectedHandler Selected;


        private readonly string r_Name;
        private List<MenuItem> m_SubItems;

        internal MenuItem(string i_MenuItemName)
        {
            r_Name = i_MenuItemName;
        }

        public MenuItem AddItem(string i_MenuItemName)
        {
            MenuItem newMenuItem = new MenuItem(i_MenuItemName);

            newMenuItem.SubItemSelected += MenuLogic.menuItem_SubItemSelected;
            newMenuItem.BackSelected += newMenuItem_BackSelected;
            if (!HasSubItems)
            {
                m_SubItems = new List<MenuItem>();
                MenuItem newSubMenuItem = new MenuItem(MenuLogic.eSpecialValues.Back.ToString());
                m_SubItems.Add(newSubMenuItem);
                newSubMenuItem.BackSelected += newSubMenuItem_BackSelected;
            }
            m_SubItems.Add(newMenuItem);
            return newMenuItem;
        }

        void newMenuItem_BackSelected()
        {
            MenuLogic.menuItem_SubItemSelected(Name, SubItems);
        }

        private void newSubMenuItem_BackSelected()
        {
            if (BackSelected != null)
            {
                BackSelected.Invoke();
            }
        }

        internal string Name { get { return r_Name; } }

        internal List<MenuItem> SubItems { get { return m_SubItems; } }

        internal bool HasSubItems
        {
            get { return m_SubItems != null; }
        }

        internal void OnSelected()
        {
            if (HasSubItems)
            {
                if (SubItemSelected != null)
                {
                    SubItemSelected.Invoke(Name, SubItems);
                }
            }
            else
            {
                if (Selected != null)
                {
                    Selected.Invoke();
                }
            }
        }

        internal void OnBackSelected()
        {
            if (BackSelected != null)
            {
                BackSelected.Invoke();
            }
        }
    }
}
