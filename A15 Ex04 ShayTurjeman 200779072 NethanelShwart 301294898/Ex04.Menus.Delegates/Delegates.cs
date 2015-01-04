using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class Delegates
    {
        public delegate void BackMenuItemSelectedHandler();

        public delegate void MenuItemSelectedHandler();

        public delegate void SubMenuItemSelectedHandler(string i_SelectedMenuItemName, List<MenuItem> i_MenuItems);
    }
}
